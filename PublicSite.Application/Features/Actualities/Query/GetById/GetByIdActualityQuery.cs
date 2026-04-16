using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Actualities.Query.GetById
{
    public record GetByIdActualityQuery(Guid Id) : IRequest<GetByIdActualityResponse>;
}
