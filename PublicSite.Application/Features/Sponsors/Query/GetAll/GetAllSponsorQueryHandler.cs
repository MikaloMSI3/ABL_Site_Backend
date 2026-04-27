using MediatR;
using PublicSite.Application.Features.Heros.Query.GetAll;
using PublicSite.Domain.Interfaces.Repositories.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Sponsors.Query.GetAll
{
    public class GetAllSponsorQueryHandler(ISponsorRepositoryQuery _repository) : IRequestHandler<GetAllSponsorQuery, GetAllSponsorResponse>
    {
        public async Task<GetAllSponsorResponse> Handle(GetAllSponsorQuery request, CancellationToken cancellationToken)
        {
            var (Results, TotalCount) = await _repository.GetAllSponsorAsync(request.Limit);

            return new GetAllSponsorResponse
            {
                Results = Results.ToList(),
                TotalCount = TotalCount
            };
        }
    }
}
