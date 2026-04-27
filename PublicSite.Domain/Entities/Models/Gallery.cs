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
        public virtual Album? Album { get; set; }

        private Gallery() { }

        private Gallery(DateTime date, string? description, Guid? albumId, Ressource ressource)
        {
            Date = date;
            Description = description;
            Ressource = ressource;
            AlbumId = albumId;
        }

        public static Gallery Create(DateTime date, string? description, Guid? albumId, Ressource ressource)
        {
            CheckRessourceValue(ressource);
            return new Gallery(date, description, albumId, ressource);
        }

        public void Update(DateTime? date = null, string? description = null, Guid? albumId = null, Ressource? ressource = null)
        {
            if (date.HasValue)
                Date = date.Value;

            if (String.IsNullOrWhiteSpace(description))
                Description = description;

            if (albumId.HasValue || albumId is not null)
                AlbumId = albumId;

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
