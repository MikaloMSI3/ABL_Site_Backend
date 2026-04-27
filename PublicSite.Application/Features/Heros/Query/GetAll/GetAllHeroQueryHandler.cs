using MediatR;
using PublicSite.Application.Features.Galleries.Query.GetAll;
using PublicSite.Application.Mappers;
using PublicSite.Domain.Interfaces.Repositories.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Heros.Query.GetAll
{
    public class GetAllHeroQueryHandler(IHeroRepositoryQuery _repository) : IRequestHandler<GetAllHeroQuery, GetAllHeroResponse>
    {
        public async Task<GetAllHeroResponse> Handle(GetAllHeroQuery request, CancellationToken cancellationToken)
        {
            var (Results, TotalCount) = await _repository.GetAllHeroAsync(request.Limit);

            return new GetAllHeroResponse
            {
                Results = Results.ToList(),
                TotalCount = TotalCount
            };
        }
    }
}
