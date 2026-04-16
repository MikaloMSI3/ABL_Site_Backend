using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Actualities.Query.GetAll
{
    public record GetAllActualityQuery(Guid? CategoryId = null, int? Limit = null, bool? OrderByDate = false) : IRequest<GetAllActualityResponse>; 
}
