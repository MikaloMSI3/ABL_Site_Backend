using MediatR;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace PublicSite.Application.Features.Users.Command.Create
{
    public record CreateUserCommand(string Email, string Password) : IRequest<CreateUserResponse>;
}
