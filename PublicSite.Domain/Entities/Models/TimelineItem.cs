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
        public DateTime Date { get; set; } //return year only

        private TimelineItem() { }

        private TimelineItem(string title, string? description, DateTime date)
        {
            Title = title;
            Description = description;
            Date = DateTime.SpecifyKind(date,DateTimeKind.Utc);
        }
        public static TimelineItem Create(string title, string? description, DateTime date)
        {
            CheckStringValue(title);
            return new TimelineItem(title, description, date);
        }

        public void Update(string? title = null, string? description = null, DateTime? date = null)
        {
            if (!String.IsNullOrWhiteSpace(title))
                Title = title;
            if (!String.IsNullOrWhiteSpace(description))
                Description = description;
            if (date.HasValue)
                Date = DateTime.SpecifyKind(date.Value,DateTimeKind.Utc);
        }

        public void SoftDeleteActuality() => IsDeleted = true;
        public static void CheckStringValue(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new DomainException("Value cannot be empty");
        }
    }
}
