using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Users.Query.GetAll
{
    public record GetAllUserQuery() : IRequest<GetAllUserResponse>;
}
