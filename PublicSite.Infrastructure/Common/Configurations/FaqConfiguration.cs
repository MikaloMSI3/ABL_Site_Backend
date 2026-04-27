using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PublicSite.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Infrastructure.Common.Configurations
{
    public class FaqConfiguration : IEntityTypeConfiguration<Faq>
    {
        public void Configure(EntityTypeBuilder<Faq> builder)
        {
            builder.ToTable("FAQs");
            builder.HasIndex(x => x.FaqCategoryId);

            builder.HasOne(x => x.Category)
                .WithMany(c => c.Faqs)
                .HasForeignKey(x => x.FaqCategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
