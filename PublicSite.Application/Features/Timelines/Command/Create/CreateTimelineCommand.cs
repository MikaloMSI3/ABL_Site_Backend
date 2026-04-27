using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Timelines.Command.Create
{
    public record CreateTimelineCommand
    (
        string Title,
        string? Description,
        int year
    ) : IRequest<CreateTimelineResponse>;
}
