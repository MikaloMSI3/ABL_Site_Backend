using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Users.Command.Create
{
    public record CreateUserResponse
    (
        Guid Id,
        DateTime CreatedAt,
        string Email,
        string Password
    );
}
