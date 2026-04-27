using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.FaqCategories.Query.GetAll
{
    public record GetAllFaqCatQuery(int? Limit = null, bool? IncludeFaq = false) : IRequest<GetAllFaqCatResponse>;
}
 