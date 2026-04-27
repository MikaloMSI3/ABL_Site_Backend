using Microsoft.EntityFrameworkCore;
using PublicSite.Domain.Entities.Models;
using PublicSite.Domain.Interfaces.Repositories.Query;
using PublicSite.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Infrastructure.Persistence.Repositories.Query
{
    public class TimelineRepositoryQuery(DBContext _context) : ITimelineRepositoryQuery
    {
        private readonly DbSet<TimelineItem> _timelineItems = _context.TimelineItems;
        public async Task<(IEnumerable<TimelineItem> Result, long TotalCount)> GetAllTimelineAsync(int? limit = null)
        {
            IQueryable<TimelineItem> query = _timelineItems;

            query = query.Where(x => x.IsDeleted == false).OrderBy(x => x.CreatedAt);

            var totalCount = query.Count();

            if (limit.HasValue)
                query = query.Take(limit.Value);

            return (await query.ToListAsync(), totalCount);
        }

        public async Task<TimelineItem> GetByIdTimelineAsync(Guid id)
        {
            var entity = await _timelineItems.FindAsync(id);
            return entity ?? throw new Exception("Entity not found");
        }
    }
}
