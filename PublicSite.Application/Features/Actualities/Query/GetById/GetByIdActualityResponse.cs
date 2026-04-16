using PublicSite.Domain.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Actualities.Query.GetById
{
    public record GetByIdActualityResponse
    (
        Guid Id,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        bool IsDeleted,
        DateTime? Date,
        string Title,
        string? Description,
        Ressource? Ressource,
        Guid? ActualityCategoryId
    );
}
