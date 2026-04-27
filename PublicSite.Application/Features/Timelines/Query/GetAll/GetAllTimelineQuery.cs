using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Timelines.Query.GetAll
{
    public record GetAllTimelineQuery(int? Limit = null) : IRequest<GetAllTimelineResponse>;
}
