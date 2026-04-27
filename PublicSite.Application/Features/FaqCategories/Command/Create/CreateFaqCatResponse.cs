using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.FaqCategories.Command.Create
{
    public record CreateFaqCatResponse
    (
        Guid Id,
        DateTime CreatedAt,
        string Name
    );
}
