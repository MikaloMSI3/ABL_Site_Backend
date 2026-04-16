using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PublicSite.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Infrastructure.Common.Configurations
{
    public class SponsorConfiguration : IEntityTypeConfiguration<Sponsor>
    {
        public void Configure(EntityTypeBuilder<Sponsor> builder)
        {
            builder.ToTable("Sponsors");
            builder.HasIndex(x => x.Name);

            builder.OwnsOne(a => a.Logo, file =>
            {
                file.Property(f => f.Url)
                .HasColumnName("Logo_Url")
                .HasMaxLength(500);

                file.Property(f => f.Name)
                    .HasColumnName("Logo_Name")
                    .HasMaxLength(255);

                file.Property(f => f.Extension)
                    .HasColumnName("Logo_Extension")
                    .HasMaxLength(10);

                file.Property(f => f.ContentType)
                    .HasColumnName("Logo_ContentType")
                    .HasMaxLength(100);

                file.Property(f => f.Size)
                    .HasColumnName("Logo_Size");
            });
        }
    }
}
