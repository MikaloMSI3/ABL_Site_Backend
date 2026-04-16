using PublicSite.Application.Dtos.Actualities;
using PublicSite.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Mappers
{
    public static class ActualityMapper
    {
        public static ActualityDto ToDto(Actuality actuality)
        {
            return new ActualityDto
            (
                Id: actuality.Id,
                Date: actuality.Date,
                Title: actuality.Title,
                Description: actuality.Description,
                Ressource: actuality.Ressource,
                ActualityCategoryId: actuality.ActualityCategoryId
            );
        }      
    }
}
