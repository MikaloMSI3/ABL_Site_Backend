using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Faqs.Query.GetById
{
    public record GetByIdFaqQuery(Guid Id) : IRequest<GetByIdFaqResponse>;
}
