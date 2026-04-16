using PublicSite.Application.Dtos;
using PublicSite.Domain.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Actualities.Command.Create
{
    public record CreateActualityResponse
    (
        Guid Id,
        DateTime CreatedAt,
        DateTime? Date,
        string Title,
        string? Description,
        Ressource? Ressource,
        Guid? ActualityCategoryId
    );
}
