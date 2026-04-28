using PublicSite.Domain.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Sponsors.Command.Create
{
    public record CreateSponsorResponse
    (
        Guid Id,
        DateTime CreatedAt,
        string Name,
        Ressource? Logo,
        string? SiteUrl
    );
}
