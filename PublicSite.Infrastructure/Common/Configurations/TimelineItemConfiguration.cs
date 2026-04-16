using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PublicSite.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Infrastructure.Common.Configurations
{
    public class TimelineItemConfiguration : IEntityTypeConfiguration<TimelineItem>
    {
        public void Configure(EntityTypeBuilder<TimelineItem> builder)
        {
            builder.ToTable("TimelineItems");
        }
    }
}
