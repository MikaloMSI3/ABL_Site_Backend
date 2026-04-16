using PublicSite.Domain.Entities.ValueObjects;
using PublicSite.Domain.Exceptions;
using Shared.Domain;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace PublicSite.Domain.Entities.Models
{
    public class Actuality : BaseEntity
    {
        public DateTime? Date { get; private set; }
        public string Title { get; private set; } = default!;
        public string? Description { get; private set; }
        public Ressource? Ressource { get; private set; }
        public Guid? ActualityCategoryId { get; private set; }

        private Actuality() {}

        public Actuality(DateTime? date, string title, string? description, Guid? actualityCategoryId, Ressource? ressource = null)
        {
            if (date.HasValue)
                Date = DateTime.SpecifyKind(date.Value,DateTimeKind.Utc);
            Title = title;
            ActualityCategoryId = actualityCategoryId;
            Description = description;
            Ressource = ressource;
        }
        public static Actuality Create(DateTime? date, string title, string? description, Guid? actualityCategoryId, Ressource? ressource = null)
        {
            CheckStringValue(title);
            var actuality = new Actuality(date, title, description, actualityCategoryId, ressource);
            
            return actuality; 
        }

        public void Update(DateTime? date = null, string? title = null, string? description = null, Guid? actualityCategoryId = null, Ressource? ressource = null)
        {
            if (date.HasValue)
                Date = date;

            if (actualityCategoryId.HasValue || actualityCategoryId is not null)
                ActualityCategoryId = actualityCategoryId;

            if (!String.IsNullOrWhiteSpace(title))
                Title = title;
            if (!String.IsNullOrWhiteSpace(description))
                Description = description;
            if (ressource != null)
                Ressource = ressource;

            UpdatedAt = DateTime.UtcNow;
        }

        public void SoftDelete() => IsDeleted = true;

        //Verification helpers 
        public static void CheckStringValue(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new DomainException("Value cannot be empty");
        }

    }
}
