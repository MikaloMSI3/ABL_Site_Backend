using PublicSite.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Domain.Interfaces.Repositories.Query
{
    public interface ITimelineRepositoryQuery
    {
        Task<TimelineItem> GetByIdTimelineAsync(Guid id);
        Task<(IEnumerable<TimelineItem> Result, long TotalCount)> GetAllTimelineAsync(int? limit = null);
    }
}
