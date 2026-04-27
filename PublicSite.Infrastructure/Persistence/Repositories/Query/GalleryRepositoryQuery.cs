using Microsoft.EntityFrameworkCore;
using PublicSite.Domain.Entities.Models;
using PublicSite.Domain.Interfaces.Repositories.Query;
using PublicSite.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Infrastructure.Persistence.Repositories.Query
{
    public class GalleryRepositoryQuery(DBContext _context) : IGalleryRepositoryQuery
    {
        private readonly DbSet<Gallery> _galleries = _context.Galleries;
        public async Task<(IEnumerable<Gallery> Result, long TotalCount)> GetAllGalleryAsync(Guid? albumId, int? limit = null, bool? orderByDate = false, bool? includeAlbum = false)
        {
            IQueryable<Gallery> query = _galleries;

            query = query.Where(x => x.IsDeleted == false);

            if (albumId.HasValue)
                query = query.Where(x => x.AlbumId == albumId.Value);

            var totalCount = query.Count();

            if (orderByDate.HasValue && orderByDate.Value == true)
                query = query.OrderByDescending(x => x.Date);
            else
                query = query.OrderByDescending(x => x.CreatedAt);

            if (includeAlbum.HasValue && includeAlbum.Value == true)
                query = query.Include(x => x.Album);

            if (limit.HasValue)
                query = query.Take(limit.Value);

            return (await query.ToListAsync(), totalCount);
        }

        public async Task<Gallery> GetByIdGalleryAsync(Guid id)
        {
            var entity = await _galleries.Include(x => x.Album).FirstOrDefaultAsync();

            return entity ?? throw new Exception("Entity not found");
        }
    }
}
