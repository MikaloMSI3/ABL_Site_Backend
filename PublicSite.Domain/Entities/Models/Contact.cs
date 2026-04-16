using PublicSite.Domain.Exceptions;
using Shared.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Domain.Entities.Models
{
    public class Contact : BaseEntity
    {
        public string Email { get; private set; } = default!;

        private Contact() { }

        private Contact(string email) => Email = email;

        public static Contact Create(string email)
        {
            CheckEmail(email);
            return new Contact(email);
        }

        public void SoftDeleteContact() => IsDeleted = true;

        public void UpdateEmail(string email)
        {
            CheckStringValue(email);
            Email = email;
        }

        public static void CheckStringValue(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new DomainException("Value cannot be empty");
        }

        private static void CheckEmail(string email)
        {
            CheckStringValue(email);

            var pattern = @"^[^@\\s]+@[^@\\s]+\\.[^@\\s]+$";

            if (!System.Text.RegularExpressions.Regex.IsMatch(email, pattern))
                throw new DomainException("Invalid email format");
        }
    }
}
