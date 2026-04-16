using PublicSite.Domain.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Actualities.Command.Update
{
    public record UpdateActualityResponse
    (
        Guid Id,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        DateTime? Date,
        string Title,
        string? Description,
        Ressource? Ressource,
        Guid? ActualityCategoryId
    );
}
