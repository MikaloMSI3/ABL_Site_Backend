using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Timelines.Command.Create
{
    public record CreateTimelineResponse
    (
        Guid Id,
        DateTime CreatedAt,
        string Title,
        string Description,
        int year
    );
}
