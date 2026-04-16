using PublicSite.Domain.Exceptions;
using Shared.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Domain.Entities.Models
{
    public class Album : BaseEntity
    {
        public string Name { get; private set; } = default!;
        public virtual ICollection<Gallery> Galleries { get; set; } = [];

        private Album() { }

        private Album(string name)
        {
            Name = name;
        }

        public static Album Create(string name)
        {
            CheckStringValue(name);
            return new Album(name);
        }

        public void Update(string name)
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
