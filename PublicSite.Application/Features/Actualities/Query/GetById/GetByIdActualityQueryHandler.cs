using MediatR;
using PublicSite.Domain.Interfaces.Repositories.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Actualities.Query.GetById
{
    public class GetByIdActualityQueryHandler(IActualityRepositoryQuery _repository) : IRequestHandler<GetByIdActualityQuery, GetByIdActualityResponse>
    {
        public async Task<GetByIdActualityResponse> Handle(GetByIdActualityQuery request, CancellationToken cancellationToken)
        {
            var actuality = await _repository.GetByIdActualityAsync(request.Id);

            return new GetByIdActualityResponse
                (
                    Id: actuality.Id,
                    CreatedAt: actuality.CreatedAt,
                    UpdatedAt: actuality.UpdatedAt,
                    IsDeleted : actuality.IsDeleted,
                    Date: actuality.Date,
                    Title: actuality.Title,
                    Description: actuality.Description,
                    Ressource: actuality.Ressource,
                    ActualityCategoryId: actuality.ActualityCategoryId
                );
        }
    }
}
