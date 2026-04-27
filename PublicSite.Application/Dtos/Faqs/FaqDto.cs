using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Dtos.Faqs
{
    public record FaqDto
    (
        Guid Id,
        string Question,
        string Answer,
        Guid? FaqCategoryId,
        string? FaqCategoryName
    );
}
