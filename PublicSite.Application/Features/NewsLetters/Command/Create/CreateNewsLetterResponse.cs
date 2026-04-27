using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.NewsLetters.Command.Create
{
    public record CreateNewsLetterResponse
    (
        Guid Id,
        DateTime CreatedAt,
        string Email
    );
}
