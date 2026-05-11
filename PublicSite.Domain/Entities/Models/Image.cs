using PublicSite.Domain.Entities.ValueObjects;
using PublicSite.Domain.Exceptions;
using Shared.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PublicSite.Domain.Entities.Models
{
    public class Image : BaseEntity
    {
        public int? Order { get; private set; }

        public Ressource Ressource { get; private set; } = default!;

        private Image() { }

        private Image(Ressource ressource, int? order = null)
        {
            Order = order;
            Ressource = ressource;
        }
        public static Image Create(Ressource ressource, int? order = null)
        {
            CheckRessourceValue(ressource);
            return new Image(ressource, order);
        }

        public void Update(int? order = null, Ressource? ressource = null)
        {
            if (order > 0 || order.HasValue)
                Order = order.Value;
            if (ressource != null)
            {
                CheckRessourceValue(ressource);
                Ressource = ressource;
            }

            UpdatedAt = DateTime.UtcNow;
        }

        public void SoftDelete() => IsDeleted = true;

        public static void CheckRessourceValue(Ressource logo)
        {
            if (String.IsNullOrWhiteSpace(logo.Url))
                throw new DomainException("Ressource Url cannot be empty");
        }

    }
}
