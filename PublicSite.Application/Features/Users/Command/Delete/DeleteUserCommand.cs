using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Users.Command.Delete
{
    public record DeleteUserCommand(Guid Id) : IRequest<DeleteUserResponse>;
}
