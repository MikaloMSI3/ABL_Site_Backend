using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using PublicSite.Api.Models;
using PublicSite.Domain.Exceptions;
using System.ComponentModel.DataAnnotations;
using System.Data;
using ValidationException = FluentValidation.ValidationException;

namespace PublicSite.Api.Middleware
{
    public class ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        private readonly RequestDelegate _next = next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger = logger;

        public async Task InvokeAsync(HttpContext context)
        {
            string date = DateTime.UtcNow.ToString("dd/MM/yyyy HH:mm:ss");
            try
            {
                await _next(context);
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "[{date}] : Validation exception gérée :", date);
                await WriteResponseAsync(context, StatusCodes.Status400BadRequest, ex.Message, ex.Errors.Select(x => new
                {
                    x.PropertyName,
                    x.ErrorMessage
                }).ToString());
            }
            catch (DomainException ex)
            {
                _logger.LogWarning(ex, "[{date}] : API exception gérée", date);
                await WriteResponseAsync(context, 400, ex.Message);
            }
            catch (DuplicateNameException ex)
            {
                _logger.LogError(ex, "[{date}] : DuplicateNameException exception gérée", date);
                await WriteResponseAsync(context, StatusCodes.Status409Conflict, ex.Message);
            }
            catch (NotImplementedException ex)
            {
                _logger.LogError(ex, "[{date}] : NotImplemented exception gérée", date);
                await WriteResponseAsync(context, StatusCodes.Status500InternalServerError, "Not Implemented Action");
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex, "[{date}] : Argument exception gérée", date);
                await WriteResponseAsync(context, StatusCodes.Status400BadRequest, ex.Message);
            }
            catch (DbUpdateException ex) when (ex.InnerException is PostgresException pgEx)
            {
                _logger.LogError(ex, "[{date}] : DbUpdate exception gérée", date);
                string message;
                int statusCode;
                switch (pgEx.SqlState)
                {
                    case "23503": // foreign_key_violation
                        if (pgEx.MessageText.Contains("insert") || pgEx.MessageText.Contains("update"))

                            message = (pgEx.ConstraintName is not null && pgEx.ConstraintName.Contains('_')) ?
                                $"La valeur fournie pour {pgEx.ConstraintName.Split('_').Last()} n'existe pas" :
                                "La référence fournie est invalide : l'élément lié n'existe pas.";
                        else
                            message = "Impossible de supprimer cet élément car il est encore utilisé ailleurs.";

                        statusCode = StatusCodes.Status409Conflict;
                        break;

                    case "23505": // unique_violation
                        message = "Un enregistrement avec ces informations existe déjà.";
                        statusCode = StatusCodes.Status409Conflict;
                        break;

                    case "23502": // not_null_violation
                        message = $"Le champ '{pgEx.ColumnName}' est obligatoire.";
                        statusCode = StatusCodes.Status400BadRequest;
                        break;

                    case "23514": // check_violation
                        message = "Les données fournies ne respectent pas les contraintes définies.";
                        statusCode = StatusCodes.Status400BadRequest;
                        break;

                    case "22001": // string_data_right_truncation
                        message = "La valeur est trop longue pour ce champ.";
                        statusCode = StatusCodes.Status400BadRequest;
                        break;

                    default:
                        message = "Erreur de base de données.";
                        statusCode = StatusCodes.Status500InternalServerError;
                        break;
                }
                await WriteResponseAsync(context, statusCode, message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[{date}] : Exception non gérée", date);
                await WriteResponseAsync(context, StatusCodes.Status500InternalServerError, "Une erreur interne est survenue : " + ex.Message);
            }
        }

        private static async Task WriteResponseAsync(HttpContext context, int statusCode, string message, object? data = null)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            var response = new ApiResponse<object>
            {
                Success = false,
                Code = statusCode,
                Message = message,
            };
            if (data != null)
                response.Data = data;

            await context.Response.WriteAsJsonAsync(response);
        }
    }
}
