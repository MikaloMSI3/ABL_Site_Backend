using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PublicSite.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Infrastructure.Common.Configurations
{
    public class AlbumConfiguration : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.ToTable("Albums");

            builder.HasMany(x => x.Galleries)
                .WithOne()
                .HasForeignKey(g => g.AlbumId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
