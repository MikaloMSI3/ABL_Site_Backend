using MediatR;
using PublicSite.Application.Features.Actualities.Query.GetAll;
using PublicSite.Application.Mappers;
using PublicSite.Domain.Interfaces.Repositories.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Faqs.Query.GetAll
{
    public class GetAllFaqQueryHandler(IFaqRepositoryQuery _repository) : IRequestHandler<GetAllFaqQuery, GetAllFaqResponse>
    {
        public async Task<GetAllFaqResponse> Handle(GetAllFaqQuery request, CancellationToken cancellationToken)
        {
            var (Results, TotalCount) = await _repository.GetAllFaqAsync(request.CategoryId, request.Limit, request.OrderByDate, includeCategory: true);

            return new GetAllFaqResponse
            {
                Results = [.. Results.Select(x => FaqMapper.ToDto(x))],
                TotalCount = TotalCount
            };
        }
    }
}
