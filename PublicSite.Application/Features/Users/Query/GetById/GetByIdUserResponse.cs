using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Users.Query.GetById
{
    public record GetByIdUserResponse
    (
        Guid Id,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        string Email,
        string Password
    );
}
