using PublicSite.Domain.Exceptions;
using Shared.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.WebRequestMethods;

namespace PublicSite.Domain.Entities.Models
{
    public class Contact : BaseEntity
    {
        public string? Lastname { get; private set; }
        public string Firstname { get; private set; } = default!;
        public string Email { get; private set; } = default!;
        public string Phone { get; private set;  } = default!;
        public string? ClubName { get; private set; }
        public string? OrganisationName { get; private set; }
        public string MailSubject { get; private set;  } = default!;
        public string MailBody { get; private set; } = default!;

        private Contact() { }

        private Contact(string? lastname, string firstname, string email, string phone, string? clubName, string? organisationName, string mailSubject, string mailBody)
        {
            Lastname = lastname;
            Firstname = firstname;
            Email = email;
            Phone = phone;
            ClubName = clubName;
            OrganisationName = organisationName;
            MailSubject = mailSubject;
            MailBody = mailBody;
        }

        public static Contact Create(string? lastname, string firstname, string email, string phone, string? clubName, string? organisationName, string mailSubject, string mailBody)
        {
            CheckEmail(email);
            return new Contact(lastname, firstname, email,phone, clubName, organisationName, mailSubject, mailBody);
        }

        public void SoftDeleteContact() => IsDeleted = true;

        public void UpdateContact(string? lastname = null, string? firstname = null, string? email = null, string? phone = null, string? clubName = null, string? organisationName = null, string? mailSubject = null, string? mailBody = null)
        {
            if (!String.IsNullOrWhiteSpace(lastname))
                Lastname = lastname;

            if (!String.IsNullOrWhiteSpace(firstname))
                Firstname = firstname;

            if (!String.IsNullOrWhiteSpace(email))
                Email = email;

            if (!String.IsNullOrWhiteSpace(phone))
                Email = phone;

            if (!String.IsNullOrWhiteSpace(clubName))
                ClubName = clubName;

            if (!String.IsNullOrWhiteSpace(organisationName))
                OrganisationName = organisationName;

            if (!String.IsNullOrWhiteSpace(mailSubject))
                MailSubject = mailSubject;

            if (!String.IsNullOrWhiteSpace(mailBody))
                MailBody = mailBody;

        }

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
