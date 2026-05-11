using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PublicSite.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Infrastructure.Common.Configurations
{
    public class SloganConfiguration : IEntityTypeConfiguration<Slogan>
    {
        public void Configure(EntityTypeBuilder<Slogan> builder)
        {
            builder.ToTable("Slogans");
            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
