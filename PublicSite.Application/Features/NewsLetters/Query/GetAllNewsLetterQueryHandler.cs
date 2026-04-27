using MediatR;
using PublicSite.Application.Features.Albums.Query.GetAll;
using PublicSite.Application.Mappers;
using PublicSite.Domain.Interfaces.Repositories.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.NewsLetters.Query
{
    public class GetAllNewsLetterQueryHandler(INewsLetterRepositoryQuery _repository) : IRequestHandler<GetAllNewsLetterQuery, GetAllNewsLetterResponse>
    {
        public async Task<GetAllNewsLetterResponse> Handle(GetAllNewsLetterQuery request, CancellationToken cancellationToken)
        {
            var (Result, TotalCount) = await _repository.GetAllNewsLetterAsync(request.Limit);

            return new GetAllNewsLetterResponse
            {
                Results = Result.ToList(),
                TotalCount = TotalCount
            };
        }
    }
}
