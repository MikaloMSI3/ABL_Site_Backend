using PublicSite.Domain.Exceptions;
using Shared.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace PublicSite.Domain.Entities.Models
{
    public class TimelineItem : BaseEntity
    {
        public string Title { get; set; } = default!;
        public string? Description { get; set; }
        public int Year { get; set; } //return year only

        private TimelineItem() { }

        private TimelineItem(string title, string? description, int year)
        {
            Title = title;
            Description = description;
            Year = year;
        }
        public static TimelineItem Create(string title, string? description, int year)
        {
            CheckStringValue(title);
            return new TimelineItem(title, description, year);
        }

        public void Update(string? title = null, string? description = null, int? year = null)
        {
            if (!String.IsNullOrWhiteSpace(title))
                Title = title;
            if (!String.IsNullOrWhiteSpace(description))
                Description = description;
            if (year.HasValue)
                Year = year.Value;
        }

        public void SoftDelete() => IsDeleted = true;
        public static void CheckStringValue(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new DomainException("Value cannot be empty");
        }
    }
}
