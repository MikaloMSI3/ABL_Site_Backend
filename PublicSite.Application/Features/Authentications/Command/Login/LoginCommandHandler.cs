using MediatR;
using Microsoft.Extensions.Configuration;
using PublicSite.Application.Interfaces;
using PublicSite.Domain.Entities.Models;
using PublicSite.Domain.Interfaces.Repositories;
using PublicSite.Domain.Interfaces.Repositories.Command;
using PublicSite.Domain.Interfaces.Repositories.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Authentications.Command.Login
{
    public class LoginCommandHandler(ITokenService _tokenService, IUserRepositoryQuery _queryRepo, IUnitOfWork _unitOfWork, IConfiguration _config) : IRequestHandler<LoginCommand, LoginResponse>
    {
        public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var entity = await _queryRepo.GetByEmail(request.Email);

            if (entity == null) 
                throw new ArgumentException("User not found");

            if (entity.Password != request.Password)
                throw new ArgumentException("Invalid password");

            var token = _tokenService.GenerateAccessToken(new Dtos.Authentication.TokenClaimDto(request.Email));
            var refreshToken = _tokenService.GenerateRefreshToken(entity.Email!.GetHashCode().ToString("X"));

            int refreshDay = int.TryParse(_config["Jwt:RefreshTokenExpired:Days"], out var time) ? time : 7;
            int refreshHour = int.TryParse(_config["Jwt:RefreshTokenExpired:Hours"], out time) ? time : 0;

            entity.Token = token;
            entity.RefreshToken = refreshToken;
            entity.RefreshTokenExpired = entity.RefreshTokenExpired = DateTime.UtcNow.AddDays(refreshDay).AddHours(refreshHour);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new LoginResponse
            (
                entity.Id,
                entity.Email,
                entity.Token,
                entity.RefreshToken
            );
            
        }
    }
}
