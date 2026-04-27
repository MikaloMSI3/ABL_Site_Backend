using PublicSite.Application.Dtos.Galleries;
using PublicSite.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Timelines.Query.GetAll
{
    public record GetAllTimelineResponse
    {
        public IEnumerable<TimelineItem>? Results { get; set; }
        public long TotalCount { get; set; }
    }
}
