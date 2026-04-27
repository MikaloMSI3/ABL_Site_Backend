using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.NewsLetters.Query
{
    public record GetAllNewsLetterQuery(int? Limit = null) : IRequest<GetAllNewsLetterResponse>;
}
