using MediatR;
using PublicSite.Domain.Interfaces.Repositories.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Faqs.Query.GetById
{
    public class GetByIdFaqQueryHandler(IFaqRepositoryQuery _repository) : IRequestHandler<GetByIdFaqQuery, GetByIdFaqResponse>
    {
        public async Task<GetByIdFaqResponse> Handle(GetByIdFaqQuery request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdFaqAsync(request.Id);

            return new GetByIdFaqResponse
            (
                Id : entity.Id,
                CreatedAt : entity.CreatedAt,
                UpdatedAt : entity.UpdatedAt,
                IsDeleted : entity.IsDeleted,
                Question : entity.Question,
                Answer : entity.Answer,
                FaqCategoryId : entity.FaqCategoryId,
                FaqCategoryName : entity.Category?.Name
            );
        }
    }
}
