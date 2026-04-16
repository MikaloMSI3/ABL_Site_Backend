using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PublicSite.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Infrastructure.Persistence.Context
{
    public class DBContext(DbContextOptions<DBContext> options) : DbContext(options)
    {
        public DbSet<Actuality> News => Set< Actuality>();
        public DbSet<ActualityCategory> ActualityCategories => Set<ActualityCategory>();
        public DbSet<Contact> Contacts => Set<Contact>();
        public DbSet<Faq> Faqs => Set<Faq>();
        public DbSet<FaqCategory> FaqCategories => Set<FaqCategory>();
        public DbSet<Gallery> Galleries => Set<Gallery>();
        public DbSet<Image> Images => Set<Image>();
        public DbSet<Slogan> Slogans => Set<Slogan>();
        public DbSet<Sponsor> Sponsors => Set<Sponsor>();
        public DbSet<TimelineItem> TimelineItems => Set<TimelineItem>();
        public DbSet<Value> Values => Set<Value>();
        public DbSet<Album> Albums => Set<Album>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DBContext).Assembly);
        }
    }
}
