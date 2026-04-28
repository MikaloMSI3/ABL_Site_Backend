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
        public string? SiteUrl { get; private set; }
        public Ressource? Logo { get; set;  }

        private Sponsor() { }

        private Sponsor(string name, Ressource? logo, string? siteUrl)
        {
            Name = name;
            Logo = logo;
            SiteUrl = siteUrl;
        }
        public static Sponsor Create(string name, Ressource? logo, string? siteUrl)
        {
            CheckStringValue(name);
            if (logo != null)
                CheckRessourceValue(logo);

            return new Sponsor(name, logo, siteUrl);
        }
        public void Update(string? name = null, Ressource? logo = null, string? siteUrl = null)
        {
            if (!String.IsNullOrWhiteSpace(name))
                Name = name;
            if (!String.IsNullOrWhiteSpace(siteUrl))
                SiteUrl = siteUrl;

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
