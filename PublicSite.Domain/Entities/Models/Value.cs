using PublicSite.Domain.Entities.ValueObjects;
using PublicSite.Domain.Exceptions;
using Shared.Domain;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace PublicSite.Domain.Entities.Models
{
    public class Value : BaseEntity
    {
        public string Title { get; private set; } = default!;
        public string? Description { get; private set; }
        public Ressource? Icon { get; private set; }

        private Value() { }

        private Value(string title, string? description = null, Ressource? icon = null) 
        {
            Title = title;
            Icon = icon;
            Description = description;
        }
        public static Value Create(string title, string? description, Ressource? icon)
        {
            CheckStringValue(title);
            if (icon is not null)
                CheckRessourceValue(icon);
            return new Value(title, description, icon);
        }

        public void Update(string? title = null, string? description = null, Ressource? ressource = null)
        {
            if (!String.IsNullOrWhiteSpace(title))
                Title = title;
            if (!String.IsNullOrWhiteSpace(description))
                Description = description;
            if (ressource != null)
            {
                CheckRessourceValue(ressource);
                Icon = ressource;
            }
        }
        public void SoftDelete() => IsDeleted = true;
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
