using PublicSite.Domain.Exceptions;
using Shared.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PublicSite.Domain.Entities.Models
{
    public class FaqCategory : BaseEntity
    {
        public string Name { get; private set; } = default!;
        public virtual ICollection<Faq> Faqs { get; set; } = [];

        private FaqCategory() { }

        private FaqCategory(string name)
        {
            Name = name;
        }

        public static FaqCategory Create(string name)
        {
            CheckStringValue(name);
            return new FaqCategory(name);
        }

        public void UpdateName(string name)
        {
            CheckStringValue(name);
            Name = name;
            UpdatedAt = DateTime.UtcNow;
        }

        public static void CheckStringValue(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new DomainException("Value cannot be empty");
        }

        public void SoftDeleteFaqCategory() => IsDeleted = true;
    }
}
 