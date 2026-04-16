using PublicSite.Application.Dtos.Actualities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.ActualityCategories.Query.GetAll
{
    public record GetAllActualityCatResponse
    {
        public IEnumerable<ActualityCategoryDto>? Results { get; set; }
        public long TotalCount { get; set; }
    }

}
