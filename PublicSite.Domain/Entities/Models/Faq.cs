using PublicSite.Domain.Exceptions;
using Shared.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Domain.Entities.Models
{
    public class Faq : BaseEntity
    {
        public string Question { get; private set; } = default!;
        public string Answer { get; private set; } = default!;
        public Guid? FaqCategoryId { get; private set; }
        public virtual FaqCategory? Category { get; set; }

        private Faq() { }

        private Faq(string question, string answer, Guid? faqCategoryId)
        {
            Question = question;
            Answer = answer;
            FaqCategoryId = faqCategoryId;
        }

        public static Faq Create(string question, string answer, Guid? faqCategoryId)
        {
            CheckStringValue(question);
            CheckStringValue(answer);
            return new Faq(question, answer, faqCategoryId);
        }

        public void Update(string? question = null, string? answer = null, Guid? faqCategoryId = null)
        {
            if (!String.IsNullOrWhiteSpace(question))
                Question = question;
            if (!String.IsNullOrWhiteSpace(answer))
                Answer = answer;

            if (faqCategoryId.HasValue || faqCategoryId != null)
                FaqCategoryId = faqCategoryId;
        }

        public void SoftDeleteFaq() => IsDeleted = true;

        public static void CheckStringValue(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new DomainException("Value cannot be empty");
        }
    }
}
