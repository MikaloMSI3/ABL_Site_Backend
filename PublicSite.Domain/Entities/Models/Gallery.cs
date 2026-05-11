using PublicSite.Domain.Entities.ValueObjects;
using PublicSite.Domain.Exceptions;
using Shared.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PublicSite.Domain.Entities.Models
{
    public class Gallery : BaseEntity
    {
        public DateTime? Date { get; private set; }
        public string? Description { get; private set; } //alt
        public Ressource Ressource { get; private set; } = default!;
        public Guid? AlbumId { get; private set; }
        public virtual Album? Album { get; set; }

        private Gallery() { }

        private Gallery(Guid? albumId, Ressource ressource,DateTime? date = null, string? description = null)
        {
            Date = date;
            Description = description;
            Ressource = ressource;
            AlbumId = albumId;
        }

        public static Gallery Create(Guid? albumId, Ressource ressource, DateTime? date = null, string? description = null)
        {
            CheckRessourceValue(ressource);
            return new Gallery(albumId, ressource,date, description);
        }

        public void Update(DateTime? date = null, string? description = null, Guid? albumId = null, Ressource? ressource = null)
        {
            if (date.HasValue)
                Date = date.Value;

            if (System.String.IsNullOrWhiteSpace(description))
                Description = description;

            if (albumId.HasValue || albumId is not null)
                AlbumId = albumId;

            if (ressource != null)
            {
                CheckRessourceValue(ressource);
                Ressource = ressource;
            }

            UpdatedAt = DateTime.UtcNow;
        }
        public static void CheckStringValue(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new DomainException("Value cannot be empty");
        }
        public void SoftDeleteGallery() => IsDeleted = true;

        public static void CheckRessourceValue(Ressource logo)
        {
            if (System.String.IsNullOrWhiteSpace(logo.Url))
                throw new DomainException("Ressource Url cannot be empty");
        }
    }
}
