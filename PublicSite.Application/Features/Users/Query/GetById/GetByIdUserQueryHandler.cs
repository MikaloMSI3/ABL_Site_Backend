using MediatR;
using PublicSite.Domain.Interfaces.Repositories.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Users.Query.GetById
{
    public class GetByIdUserQueryHandler(IUserRepositoryQuery _repository) : IRequestHandler<GetByIdUserQuery, GetByIdUserResponse>
    {
        public async Task<GetByIdUserResponse> Handle(GetByIdUserQuery request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdUserAsync(request.Id);

            return new GetByIdUserResponse
            (
                entity.Id,
                entity.CreatedAt,
                entity.UpdatedAt,
                entity.Email,
                entity.Password
            );
        }
    }
}
