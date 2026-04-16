using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Actualities.Query.GetAll
{
    public record GetAllActualityQuery(Guid? Id = null, int? Limit = null) : IRequest<GetAllActualityResponse>; 
}
