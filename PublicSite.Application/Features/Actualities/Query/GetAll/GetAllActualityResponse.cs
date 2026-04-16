using PublicSite.Application.Dtos.Actualities;
using PublicSite.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Actualities.Query.GetAll
{
    public record GetAllActualityResponse
    {
        public IEnumerable<ActualityDto>? Results { get; set; }
        public long TotalCount { get; set; }
    }
}
