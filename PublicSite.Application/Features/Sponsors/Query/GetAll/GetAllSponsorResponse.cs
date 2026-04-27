using PublicSite.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Sponsors.Query.GetAll
{
    public record GetAllSponsorResponse
    {
        public IEnumerable<Sponsor>? Results { get; set; }
        public long TotalCount { get; set; }
    }
}
