using MediatR;
using PublicSite.Application.Features.Sponsors.Query.GetAll;
using PublicSite.Domain.Interfaces.Repositories.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Timelines.Query.GetAll
{
    public class GetAllTimelineQueryHandler(ITimelineRepositoryQuery _repository) : IRequestHandler<GetAllTimelineQuery, GetAllTimelineResponse>
    {
        public async Task<GetAllTimelineResponse> Handle(GetAllTimelineQuery request, CancellationToken cancellationToken)
        {
            var (Results, TotalCount) = await _repository.GetAllTimelineAsync(request.Limit);

            return new GetAllTimelineResponse
            {
                Results = Results.ToList(),
                TotalCount = TotalCount
            };
        }
    }
}
