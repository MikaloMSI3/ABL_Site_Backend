using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Users.Command.Update
{
    public record UpdateUserCommand
    (
        Guid Id,
        string Email, 
        string Password
    ) : IRequest<UpdateUserResponse>;
}
