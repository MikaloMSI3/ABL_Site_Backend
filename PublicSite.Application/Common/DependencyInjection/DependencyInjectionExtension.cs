using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using PublicSite.Application.Common.Behavior;
using PublicSite.Application.Features.Actualities.Command.Create;
using PublicSite.Application.Interfaces;
using PublicSite.Application.Services;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace PublicSite.Application.Common.DependencyInjection
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = config["Jwt:Issuer"],
                    ValidAudience = config["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:SecretKey"]))
                };
            });

            services.AddValidatorsFromAssemblyContaining<CreateActualityCommand>();
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.Scan(scan => scan.FromAssemblies(typeof(FileStorageService).Assembly)
            .AddClasses(s => s.Where(x => x.Name.EndsWith("Service")))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

            return services;
        }
    }
}
