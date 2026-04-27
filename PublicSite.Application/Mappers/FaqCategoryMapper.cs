using PublicSite.Application.Dtos.Faqs;
using PublicSite.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Mappers
{
    public static class FaqCategoryMapper
    {
        public static FaqCategoryDto ToDto(FaqCategory faqCategory)
        {
            return new FaqCategoryDto
                (
                    Id : faqCategory.Id,
                    CreatedAt : faqCategory.CreatedAt,
                    Name : faqCategory.Name,
                    Faqs : faqCategory.Faqs?.Select(x => new FaqWithCatDto
                    (
                        Id : x.Id,
                        Question : x.Question,
                        Answer : x.Answer
                    ))
                );
        }
    }
}
