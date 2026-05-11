using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PublicSite.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Infrastructure.Common.Configurations
{
    public class ActualityCategoryConfiguration : IEntityTypeConfiguration<ActualityCategory>
    {
        public void Configure(EntityTypeBuilder<ActualityCategory> builder)
        {
            builder.ToTable("ActualityCategories");
            builder.HasIndex(x => x.Name).IsUnique();
            builder.HasQueryFilter(x => !x.IsDeleted);

            builder.HasMany(x => x.Actualities)
                .WithOne()
                .HasForeignKey(a => a.ActualityCategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
