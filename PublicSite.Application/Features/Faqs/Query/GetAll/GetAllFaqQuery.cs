using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Faqs.Query.GetAll
{
    public record GetAllFaqQuery(Guid? CategoryId = null, int? Limit = null, bool? OrderByDate = false) : IRequest<GetAllFaqResponse>;

}
