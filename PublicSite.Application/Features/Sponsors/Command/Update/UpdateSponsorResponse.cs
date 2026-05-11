using Microsoft.AspNetCore.Http;
using PublicSite.Domain.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Sponsors.Command.Update
{
    public record UpdateSponsorResponse
    (
        Guid Id,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        string? Name,
        Ressource? Logo,
        string? SiteUrl
    );
}
