using Microsoft.EntityFrameworkCore;
using PublicSite.Domain.Entities.Models;
using PublicSite.Domain.Interfaces.Repositories.Command;
using PublicSite.Domain.Interfaces.Repositories.Query;
using PublicSite.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Infrastructure.Persistence.Repositories.Command
{
    public class HeroRepositoryCommand(DBContext _context, IHeroRepositoryQuery _query) : IHeroRepositoryCommand
    {
        private readonly DbSet<Image> _images = _context.Images;
        public async Task<Image> AddHeroAsync(Image image)
        {
            var entity = Image.Create(image.Ressource, image.Order);
            await _images.AddAsync(entity);
            return entity;
        }

        public async Task<Image> UpdateHeroAsync(Guid id, Image image)
        {
            var entity = await _query.GetByIdHeroAsync(id);
            entity.Update(image.Order, image.Ressource);
            return entity;
        }

        public async Task<Image> SoftDeleteHeroAsync(Guid id)
        {
            var entity = await _query.GetByIdHeroAsync(id);
            entity.SoftDelete();
            return entity;
        }
    }
}
