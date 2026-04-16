using PublicSite.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Actualities.Query.GetAll
{
    public record GetAllActualityResponse
    {
        public IEnumerable<Actuality> Results { get; set; }
        public long TotalCount { get; set; }
    }
}
