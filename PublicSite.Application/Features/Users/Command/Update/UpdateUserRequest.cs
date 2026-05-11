using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Users.Command.Update
{
    public record UpdateUserRequest
    (
        string Email,
        string Password
    );
}
