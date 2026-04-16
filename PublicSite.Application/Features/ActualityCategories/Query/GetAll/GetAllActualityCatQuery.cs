using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.ActualityCategories.Query.GetAll
{
    public record GetAllActualityCatQuery(int? Limit = null, bool? IncludeActualities = false) : IRequest<GetAllActualityCatResponse>;
}
