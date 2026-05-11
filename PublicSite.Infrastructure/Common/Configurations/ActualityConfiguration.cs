using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PublicSite.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace PublicSite.Infrastructure.Common.Configurations
{
    public class ActualityConfiguration : IEntityTypeConfiguration<Actuality>
    {
        public void Configure(EntityTypeBuilder<Actuality> builder)
        {
            builder.ToTable("News");
            builder.HasIndex(x => x.ActualityCategoryId);
            builder.HasQueryFilter(x => !x.IsDeleted);

            builder.OwnsOne(a => a.Ressource, file =>
            {
                file.Property(f => f.Url)
                .HasColumnName("Ressource_Url")
                .HasMaxLength(500);

                file.Property(f => f.Name)
                    .HasColumnName("Ressource_Name")
                    .HasMaxLength(255);

                file.Property(f => f.Extension)
                    .HasColumnName("Ressource_Extension")
                    .HasMaxLength(10);

                file.Property(f => f.ContentType)
                    .HasColumnName("Ressource_ContentType")
                    .HasMaxLength(100);

                file.Property(f => f.Size)
                    .HasColumnName("Ressource_Size");
            });

            builder.HasOne(x => x.Category)
                .WithMany(c => c.Actualities)
                .HasForeignKey(x => x.ActualityCategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
