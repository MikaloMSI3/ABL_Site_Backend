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
    public class GalleryRepositoryCommand(DBContext _context, IGalleryRepositoryQuery _query) : IGalleryRepositoryCommand
    {
        private readonly DbSet<Gallery> _galleries = _context.Galleries;
        public async Task<Gallery> AddGalleryAsync(Gallery actuality)
        {
            var entity = Gallery.Create(actuality.Date, actuality.Description, actuality.AlbumId, actuality.Ressource);
            await _galleries.AddAsync(entity);
            return entity;
        }

        public async Task<bool> SoftDeleteGalleryAsync(Guid id)
        {
            var entity = _query.GetByIdGalleryAsync(id);
            entity.Result.SoftDeleteGallery();
            return entity != null;
        }

        public Task<Gallery> UpdateGalleryAsync(Guid id, Gallery actuality)
        {
            var entity = _query.GetByIdGalleryAsync(id);
            entity.Result.Update(actuality.Date, actuality.Description, actuality.AlbumId, actuality.Ressource);
            return entity;
        }
    }
}
