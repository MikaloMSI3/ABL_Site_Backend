using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Timelines.Command.Delete
{
    public record DeleteTimelineCommand(Guid Id) : IRequest<DeleteTimelineResponse>;
}
