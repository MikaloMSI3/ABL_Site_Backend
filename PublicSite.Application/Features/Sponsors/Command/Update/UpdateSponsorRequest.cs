using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Sponsors.Command.Update
{
    public record UpdateSponsorRequest
    (
        string? Name,
        IFormFile? Logo,
        string? SiteUrl
    );
}
