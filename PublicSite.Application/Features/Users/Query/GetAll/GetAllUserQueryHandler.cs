using MediatR;
using Microsoft.AspNetCore.Http;
using PublicSite.Domain.Interfaces.Repositories.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Users.Query.GetAll
{
    public class GetAllUserQueryHandler(IUserRepositoryQuery _repository) : IRequestHandler<GetAllUserQuery, GetAllUserResponse>
    {
        public async Task<GetAllUserResponse> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var (Result, TotalCount) = await _repository.GetAllUserAsync();

            return new GetAllUserResponse
            {
                Results = Result,
                TotalCount = TotalCount
            };
        }
    }
}
