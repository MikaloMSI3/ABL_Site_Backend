using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using PublicSite.Domain.Entities.Models;
using PublicSite.Domain.Interfaces.Repositories.Command;
using PublicSite.Domain.Interfaces.Repositories.Query;
using PublicSite.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace PublicSite.Infrastructure.Persistence.Repositories.Command
{
    public class TimelineRepositoryCommand(DBContext _context, ITimelineRepositoryQuery _query) : ITimelineRepositoryCommand
    {
        private readonly DbSet<TimelineItem> _timelineItems = _context.TimelineItems;
        public async Task<TimelineItem> AddTimelineAsync(TimelineItem timeline)
        {
            var entity = TimelineItem.Create(timeline.Title, timeline.Description, timeline.Year);
            await _timelineItems.AddAsync(entity);
            return entity;
        }

        public async Task<TimelineItem> SoftDeleteTimelineAsync(Guid id)
        {
            var entity = await _query.GetByIdTimelineAsync(id);
            entity.SoftDelete();
            return entity;
        }

        public async Task<TimelineItem> UpdateTimeLineAsync(Guid id, TimelineItem timelineItem)
        {
            var entity = await _query.GetByIdTimelineAsync(id);
            entity.Update(timelineItem.Title, timelineItem.Description, timelineItem.Year);

            return entity;
        }
    }
}
