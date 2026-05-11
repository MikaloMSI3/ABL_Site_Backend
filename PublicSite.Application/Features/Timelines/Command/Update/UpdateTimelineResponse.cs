using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Timelines.Command.Update
{
    public record UpdateTimelineResponse
    (
        Guid Id,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        string? Title,
        string? Description,
        int? Year
    );
}
