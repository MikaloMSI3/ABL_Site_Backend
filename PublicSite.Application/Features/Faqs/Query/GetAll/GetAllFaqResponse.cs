using PublicSite.Application.Dtos.Actualities;
using PublicSite.Application.Dtos.Faqs;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Faqs.Query.GetAll
{
    public record GetAllFaqResponse
    {
        public IEnumerable<FaqDto>? Results { get; set; }
        public long TotalCount { get; set; }
    };
}
