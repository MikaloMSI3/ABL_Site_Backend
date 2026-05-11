using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Users.Command.Update
{
    public record UpdateUserResponse
    (
        Guid Id,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        string Email,
        string Password
    );
}
