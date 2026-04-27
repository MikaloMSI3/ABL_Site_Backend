using PublicSite.Application.Dtos.Actualities;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace PublicSite.Application.Dtos.Faqs
{
    public record FaqCategoryDto
    (
        Guid Id,
        DateTime CreatedAt,
        string Name,
        IEnumerable<FaqWithCatDto>? Faqs
    );
}
