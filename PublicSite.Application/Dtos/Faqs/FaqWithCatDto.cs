using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Dtos.Faqs
{
    public record FaqWithCatDto
    (
        Guid Id,
        string Question,
        string Answer
    );
}
