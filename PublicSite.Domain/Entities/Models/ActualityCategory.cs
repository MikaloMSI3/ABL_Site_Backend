using PublicSite.Domain.Exceptions;
using Shared.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Domain.Entities.Models
{
    public class ActualityCategory : BaseEntity
    {
        public string Name { get; private set; } = default!;

        public virtual ICollection<Actuality> Actualities { get; set; } = [];

        private ActualityCategory() { }

        private ActualityCategory(string name) => Name = name;

        public static ActualityCategory Create(string name)
        {
            CheckStringValue(name);
            var actualityCategory = new ActualityCategory(name);

            return actualityCategory;
        }

        public void UpdateName(string name)
        {
            CheckStringValue(name);
            Name = name;
        }

        public void SoftDelete() => IsDeleted = true;

        public static void CheckStringValue(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new DomainException("Value cannot be empty");
        }
    }
}
