using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Faqs.Command.Update
{
    public record UpdateFaqResponse
    (
        Guid Id,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        string Question,
        string Answer,
        Guid? FaqCategoryId
    );
}
