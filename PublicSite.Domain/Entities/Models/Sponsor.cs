using PublicSite.Domain.Entities.ValueObjects;
using PublicSite.Domain.Exceptions;
using Shared.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Domain.Entities.Models
{
    public class Sponsor : BaseEntity
    {
        public string Name { get; private set; } = default!;
        public Ressource? Logo { get; set;  }

        private Sponsor() { }

        private Sponsor(string name, Ressource? logo)
        {
            Name = name;
            Logo = logo;
        }
        public static Sponsor Create(string name, Ressource logo)
        {
            CheckStringValue(name);
            CheckRessourceValue(logo);
            return new Sponsor(name, logo);
        }
        public void Update(string? name = null, Ressource? logo = null)
        {
            if (!String.IsNullOrWhiteSpace(name))
                Name = name;
            if (logo != null)
            {
                CheckRessourceValue(logo);
                Logo = logo;
            }
        }
        public void SoftDeleteSponsor() => IsDeleted = true;

        public static void CheckStringValue(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new DomainException("Value cannot be empty");
        }

        public static void CheckRessourceValue(Ressource logo)
        {
            if (String.IsNullOrWhiteSpace(logo.Url))
                throw new DomainException("Ressource Url cannot be empty");
        }
    }
}
