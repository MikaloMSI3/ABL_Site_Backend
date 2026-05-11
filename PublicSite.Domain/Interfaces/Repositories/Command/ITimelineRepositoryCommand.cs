using PublicSite.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Domain.Interfaces.Repositories.Command
{
    public interface ITimelineRepositoryCommand
    {
        Task<TimelineItem> AddTimelineAsync(TimelineItem actuality);
        Task<TimelineItem> SoftDeleteTimelineAsync(Guid id);
        Task<TimelineItem> UpdateTimeLineAsync(Guid id, TimelineItem timelineItem);
    }
}
