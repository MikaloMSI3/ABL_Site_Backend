using MediatR;
using PublicSite.Application.Mappers;
using PublicSite.Domain.Interfaces.Repositories.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Actualities.Query.GetAll
{
    public class GetAllActualityQueryHandler(IActualityRepositoryQuery _repository) : IRequestHandler<GetAllActualityQuery, GetAllActualityResponse>
    {
        public async Task<GetAllActualityResponse> Handle(GetAllActualityQuery request, CancellationToken cancellationToken)
        {
            var (Results, TotalCount) = await _repository.GetAllActualityAsync(request.CategoryId, request.Limit, request.OrderByDate);

            return new GetAllActualityResponse
            {
                Results = [..Results.Select(x => ActualityMapper.ToDto(x))],
                TotalCount = TotalCount
            };
        }
    }
}
