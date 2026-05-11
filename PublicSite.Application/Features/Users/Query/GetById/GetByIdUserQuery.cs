using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Users.Query.GetById
{
    public record GetByIdUserQuery(Guid Id) : IRequest<GetByIdUserResponse>;
}
