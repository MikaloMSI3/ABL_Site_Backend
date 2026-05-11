using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Timelines.Command.Update
{
    public record UpdateTimelineCommand
    (
        Guid Id,
        string? Title,
        string? Description,
        int? Year
    ) : IRequest<UpdateTimelineResponse>;
}
