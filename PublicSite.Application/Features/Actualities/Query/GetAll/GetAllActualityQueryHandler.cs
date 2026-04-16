using MediatR;
using PublicSite.Domain.Interfaces.Repositories.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Actualities.Query.GetAll
{
    public class GetAllActualityQueryHandler(IActualityRepositoryQuery _repository) : IRequestHandler<GetAllActualityQuery, GetAllActualityResponse>
    {
        public Task<GetAllActualityResponse> Handle(GetAllActualityQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
