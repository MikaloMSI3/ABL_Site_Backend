using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PublicSite.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Infrastructure.Common.Configurations
{
    public class ValueConfiguration : IEntityTypeConfiguration<Value>
    {
        public void Configure(EntityTypeBuilder<Value> builder)
        {
            builder.ToTable("Values");
            builder.HasIndex(x => x.Title);

            builder.OwnsOne(a => a.Icon, file =>
            {
                file.Property(f => f.Url)
                .HasColumnName("Icon_Url")
                .HasMaxLength(500);

                file.Property(f => f.Name)
                    .HasColumnName("Icon_Name")
                    .HasMaxLength(255);

                file.Property(f => f.Extension)
                    .HasColumnName("Icon_Extension")
                    .HasMaxLength(10);

                file.Property(f => f.ContentType)
                    .HasColumnName("Icon_ContentType")
                    .HasMaxLength(100);

                file.Property(f => f.Size)
                    .HasColumnName("Icon_Size");
            });
        }
    }
}
