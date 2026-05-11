using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Timelines.Command.Update
{
    public record UpdateTimelineRequest
    (
        string? Title,
        string? Description,
        int? Year
    );
}
