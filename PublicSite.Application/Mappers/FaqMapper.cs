using PublicSite.Application.Dtos.Faqs;
using PublicSite.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Mappers
{
    public static class FaqMapper
    {
        public static FaqDto ToDto(Faq faq)
        {
            return new FaqDto
                (
                    Id : faq.Id,
                    Question : faq.Question,
                    Answer : faq.Answer,
                    FaqCategoryId : faq.FaqCategoryId,
                    FaqCategoryName : faq.Category?.Name
                );
        }
    }
}
