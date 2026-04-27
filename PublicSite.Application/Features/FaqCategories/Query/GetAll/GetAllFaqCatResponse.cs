using PublicSite.Application.Dtos.Actualities;
using PublicSite.Application.Dtos.Faqs;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.FaqCategories.Query.GetAll
{
    public record GetAllFaqCatResponse
    {
        public IEnumerable<FaqCategoryDto>? Results { get; set; }
        public long TotalCount { get; set; }
    }
}
