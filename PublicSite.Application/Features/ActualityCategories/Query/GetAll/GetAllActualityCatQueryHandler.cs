using MediatR;
using PublicSite.Application.Mappers;
using PublicSite.Domain.Interfaces.Repositories;
using PublicSite.Domain.Interfaces.Repositories.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.ActualityCategories.Query.GetAll
{
    public class GetAllActualityCatQueryHandler(IActualityCatRepositoryQuery _repository) : IRequestHandler<GetAllActualityCatQuery, GetAllActualityCatResponse>
    {
        public async Task<GetAllActualityCatResponse> Handle(GetAllActualityCatQuery request, CancellationToken cancellationToken)
        {
            var (Result, TotalCount) = await _repository.GetAllActualityCategoryAsync(request.Limit, request.IncludeActualities);

            return new GetAllActualityCatResponse
            {
                Results = Result.Select(x => ActualityCategoryMapper.ToDto(x)),
                TotalCount = TotalCount
            };
        }
    }
}
