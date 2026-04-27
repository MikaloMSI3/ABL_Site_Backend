using Microsoft.EntityFrameworkCore;
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

        public async Task<bool> SoftDeleteTimelineAsync(Guid id)
        {
            var entity = _query.GetByIdTimelineAsync(id);
            entity.Result.SoftDelete();
            return entity != null;
        }
    }
}
