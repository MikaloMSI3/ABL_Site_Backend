using MediatR;
using Microsoft.Extensions.Configuration;
using PublicSite.Application.Features.Authentications.Command.Login;
using PublicSite.Application.Interfaces;
using PublicSite.Domain.Interfaces.Repositories;
using PublicSite.Domain.Interfaces.Repositories.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Authentications.Command.RefreshToken
{
    public class RefreshTokenCommandHandler(ITokenService _tokenService, IUserRepositoryQuery _queryRepo, IUnitOfWork _unitOfWork, IConfiguration _config) : IRequestHandler<RefreshTokenCommand, RefreshTokenResponse>
    {
        public async Task<RefreshTokenResponse> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var entity = await _queryRepo.GetByRefreshAsync(request.RefreshToken);

            if (entity == null)
                throw new ArgumentException("Refresh Token Expired or Invalid");

            var token = _tokenService.GenerateAccessToken(new Dtos.Authentication.TokenClaimDto(entity.Email));
            var refreshToken = _tokenService.GenerateRefreshToken(entity.Email!.GetHashCode().ToString("X"));

            int refreshDay = int.TryParse(_config["Jwt:RefreshTokenExpired:Days"], out var time) ? time : 7;
            int refreshHour = int.TryParse(_config["Jwt:RefreshTokenExpired:Hours"], out time) ? time : 0;

            entity.Token = token;
            entity.RefreshToken = refreshToken;
            entity.RefreshTokenExpired = entity.RefreshTokenExpired = DateTime.UtcNow.AddDays(refreshDay).AddHours(refreshHour);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new RefreshTokenResponse
            (
                entity.Token,
                entity.RefreshToken
            );
        }
    }
}
