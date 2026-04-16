using PublicSite.Application.Dtos.Actualities;
using PublicSite.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Mappers
{
    public static class ActualityCategoryMapper
    {
        public static ActualityCategoryDto ToDto (ActualityCategory category)
        {
            return new ActualityCategoryDto
                (
                    Id : category.Id,
                    CreatedAt : category.CreatedAt,
                    Name : category.Name,
                    Actualities : category.Actualities?.Select(x => new ActualityWithCatDto(
                        Id : x.Id,
                        Date : x.Date,
                        Title : x.Title,
                        Description : x.Description,
                        Ressource : x.Ressource
                     ))
                );
        }
    }
}
