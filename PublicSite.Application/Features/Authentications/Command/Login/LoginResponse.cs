using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Authentications.Command.Login
{
    public record LoginResponse(Guid Id,string Email, string Token, string RefreshToken);
}
