using PublicSite.Application.Dtos.Authentication;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Interfaces
{
    public interface ITokenService
    {
        string GenerateAccessToken(TokenClaimDto claim);
        string GenerateRefreshToken(string code);
    }
}
