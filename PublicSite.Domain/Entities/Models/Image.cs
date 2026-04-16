using PublicSite.Domain.Entities.Enums;
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
        public int Order { get; private set; }

        [Column(TypeName = "text")]
        public ImageType Type { get; private set; }

        public Ressource? Ressource { get; private set; }

        private Image() { }

        private Image(int order, ImageType type, Ressource? ressource)
        {
            Order = order;
            Type = type;
            Ressource = ressource;
        }
        public static Image Create(int order, ImageType type, Ressource ressource)
        {
            CheckRessourceValue(ressource);
            return new Image(order, type, ressource);
        }

        public void Update(int? order = null, ImageType? type = null, Ressource? ressource = null)
        {
            if (order > 0 || order.HasValue)
                Order = order.Value;
            if (type.HasValue)
                Type = type.Value;
            if (ressource != null)
            {
                CheckRessourceValue(ressource);
                Ressource = ressource;
            }
        }

        public void SoftDeleteActuality() => IsDeleted = true;

        public static void CheckRessourceValue(Ressource logo)
        {
            if (String.IsNullOrWhiteSpace(logo.Url))
                throw new DomainException("Ressource Url cannot be empty");
        }

    }
}
