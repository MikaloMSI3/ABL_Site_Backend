using MediatR;
using PublicSite.Application.Features.ActualityCategories.Query.GetAll;
using PublicSite.Application.Mappers;
using PublicSite.Domain.Interfaces.Repositories.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.FaqCategories.Query.GetAll
{
    public class GetAllFaqCatQueryHandler(IFaqCatRepositoryQuery _repository) : IRequestHandler<GetAllFaqCatQuery, GetAllFaqCatResponse>
    {
        public async Task<GetAllFaqCatResponse> Handle(GetAllFaqCatQuery request, CancellationToken cancellationToken)
        {
            var (Result, TotalCount) = await _repository.GetAllActualityCategoryAsync(request.Limit, request.IncludeFaq);

            return new GetAllFaqCatResponse
            {
                Results = Result.Select(x => FaqCategoryMapper.ToDto(x)),
                TotalCount = TotalCount
            };
        }
    }
}
