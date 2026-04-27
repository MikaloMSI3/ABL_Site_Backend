using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PublicSite.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Infrastructure.Common.Configurations
{
    public class FaqCategoryConfiguration : IEntityTypeConfiguration<FaqCategory>
    {
        public void Configure(EntityTypeBuilder<FaqCategory> builder)
        {
            builder.ToTable("FAQCategories");
            builder.HasIndex(x => x.Name).IsUnique();

            builder.HasMany(x => x.Faqs)
                .WithOne()
                .HasForeignKey(a => a.FaqCategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
