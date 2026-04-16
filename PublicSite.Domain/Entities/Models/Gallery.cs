using PublicSite.Domain.Entities.ValueObjects;
using PublicSite.Domain.Exceptions;
using Shared.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Domain.Entities.Models
{
    public class Gallery : BaseEntity
    {
        public DateTime Date { get; private set; }
        public string? Description { get; private set; } //alt
        public Ressource Ressource { get; private set; } = default!;
        public Guid? AlbumId { get; private set; }

        private Gallery() { }

        private Gallery(DateTime date, string? description, Ressource ressource)
        {
            Date = date;
            Description = description;
            Ressource = ressource;
        }

        public static Gallery Create(DateTime date, string? description, Ressource ressource)
        {
            CheckRessourceValue(ressource);
            return new Gallery(date, description, ressource);
        }

        public void Update(DateTime? date = null, string? description = null, Ressource? ressource = null)
        {
            if (date.HasValue)
                Date = date.Value;
            if (String.IsNullOrWhiteSpace(description))
                Description = description;
            if (ressource != null)
            {
                CheckRessourceValue(ressource);
                Ressource = ressource;
            }
        }
        public static void CheckStringValue(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new DomainException("Value cannot be empty");
        }
        public void SoftDeleteGallery() => IsDeleted = true;

        public static void CheckRessourceValue(Ressource logo)
        {
            if (String.IsNullOrWhiteSpace(logo.Url))
                throw new DomainException("Ressource Url cannot be empty");
        }
    }
}
