using PublicSite.Domain.Exceptions;
using Shared.Domain;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace PublicSite.Domain.Entities.Models
{
    public class User : BaseEntity
    {
        public string Email { get; private set; } = default!;
        public string Password { get; private set; } = default!;
        public string? Token { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpired { get; set; }

        private User() { }
        private User(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public static User Create(string email, string password) 
        {
            CheckEmail(email);
            return new User(email, password);
        }

        public void Update(string? email = null, string? password = null)
        {
            if (!String.IsNullOrWhiteSpace(email))
            {
                CheckEmail(email);
                Email = email;
            }

            if (!String.IsNullOrWhiteSpace(password))
                Password = password;

            UpdatedAt = DateTime.UtcNow;
        }

        public void SoftDelete() => IsDeleted = true;

        private static void CheckEmail(string email)
        {
            var pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            if (!System.Text.RegularExpressions.Regex.IsMatch(email, pattern))
                throw new DomainException("Invalid email format");
        }
    }
}
