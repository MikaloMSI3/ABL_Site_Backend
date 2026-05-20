using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Authentications.Command.RefreshToken
{
    public record RefreshTokenResponse(string Token, string RefreshToken);
}
