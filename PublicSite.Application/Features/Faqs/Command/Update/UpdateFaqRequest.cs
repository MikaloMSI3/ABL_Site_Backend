using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Faqs.Command.Update
{
    public record UpdateFaqRequest
    (
        string? Question,
        string? Answer,
        Guid? FaqCategoryId
    );
}
