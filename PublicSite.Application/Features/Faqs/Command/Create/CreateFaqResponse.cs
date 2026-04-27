using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Faqs.Command.Create
{
    public record CreateFaqResponse
    (
        Guid Id,
        DateTime CreatedAt,
        string Question,
        string Answer,
        Guid? FaqCategoryId
    );
}
