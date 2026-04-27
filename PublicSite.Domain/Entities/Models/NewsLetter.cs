using PublicSite.Domain.Exceptions;
using Shared.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Domain.Entities.Models
{
    public class NewsLetter : BaseEntity
    {
        public string Email { get; private set; } = default!;

        private NewsLetter() { }
        private NewsLetter(string email) => Email = email;

        public static NewsLetter Create(string email)
        {
            CheckEmail(email);
            return new NewsLetter(email);
        }

        public void SoftDelete() => IsDeleted = true;

        public static void CheckStringValue(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new DomainException("Value cannot be empty");
        }

        private static void CheckEmail(string email)
        {
            CheckStringValue(email);

            var pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            if (!System.Text.RegularExpressions.Regex.IsMatch(email, pattern))
                throw new DomainException("Invalid email format");
        }

    }
}
