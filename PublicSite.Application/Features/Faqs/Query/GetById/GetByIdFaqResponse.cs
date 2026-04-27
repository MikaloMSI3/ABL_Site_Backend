using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Faqs.Query.GetById
{
    public record GetByIdFaqResponse
    (
        Guid Id,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        bool IsDeleted,
        string Question,
        string Answer,
        Guid? FaqCategoryId,
        string? FaqCategoryName
    );
}
