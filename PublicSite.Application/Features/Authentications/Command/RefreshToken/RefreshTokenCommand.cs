using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Authentications.Command.RefreshToken
{
    public record RefreshTokenCommand(string RefreshToken) : IRequest<RefreshTokenResponse>;
}
