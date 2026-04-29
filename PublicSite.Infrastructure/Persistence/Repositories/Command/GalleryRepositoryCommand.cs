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
        public async Task<Gallery> AddGalleryAsync(Gallery gallery)
        {
            var entity = Gallery.Create(gallery.AlbumId, gallery.Ressource, gallery.Date, gallery.Description);
            await _galleries.AddAsync(entity);
            return entity;
        }

        public async Task<List<Gallery>> AddManyGalleryAsync(List<Gallery> galleries)
        {
            var galleryList = new List<Gallery>();
            foreach (var gallery in galleries)
            {
                galleryList.Add(Gallery.Create(gallery.AlbumId,gallery.Ressource));
            }
            await _galleries.AddRangeAsync(galleryList);
            return galleryList;
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
