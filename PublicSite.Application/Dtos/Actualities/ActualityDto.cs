using PublicSite.Domain.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Dtos.Actualities
{
    public record ActualityDto
    (
        Guid Id,
        DateTime? Date,
        string Title,
        string? Description,
        Ressource? Ressource,
        Guid? ActualityCategoryId
    );
        
}
