using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PublicSite.Domain.Entities.Models;
using PublicSite.Domain.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Infrastructure.Common.Configurations
{
    public class GalleryConfiguration : IEntityTypeConfiguration<Gallery>
    {
        public void Configure(EntityTypeBuilder<Gallery> builder)
        {
            builder.ToTable("Galleries");
            builder.HasIndex(x => x.AlbumId);

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

            builder.HasOne(x => x.Album)
                .WithMany(c => c.Galleries)
                .HasForeignKey(x => x.AlbumId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
