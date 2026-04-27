using Shared.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Domain.Entities.Models
{
    public class Slogan : BaseEntity
    {
        public string? Description { get; set; }
        public bool? IsActive { get; set; } = true;

        private Slogan() { }

        private Slogan(string? description, bool? isActive)
        {
            Description = description;
            IsActive = isActive;
        }

        public static Slogan Create(string? description, bool? isActive)
        {
            return new Slogan(description, isActive);
        }
        public void Deactivate() => IsActive = false;
        public void SoftDelete() => IsDeleted = true;
    }
}
