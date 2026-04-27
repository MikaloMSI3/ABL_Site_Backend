using Microsoft.EntityFrameworkCore;
using PublicSite.Domain.Entities.Models;
using PublicSite.Domain.Interfaces.Repositories.Query;
using PublicSite.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Infrastructure.Persistence.Repositories.Query
{
    public class AlbumRepositoryQuery(DBContext _context) : IAlbumRepositoryQuery
    {
        private readonly DbSet<Album> _albums = _context.Albums;
        public async Task<(IEnumerable<Album> Result, long TotalCount)> GetAllAlbumAsync(int? limit = null, bool? includeGalleries = false)
        {
            IQueryable<Album> query = _albums;

            query = query.Where(x => x.IsDeleted == false).OrderByDescending(x => x.CreatedAt);

            var totalCount = query.Count();

            if (limit.HasValue)
                query = query.Take(limit.Value);

            if (includeGalleries.HasValue && includeGalleries == true)
                query = query.Include(x => x.Galleries);

            return (await query.ToListAsync(), totalCount);
        }

        public async Task<Album> GetByIdAlbumAsync(Guid id)
        {
            var entity = await _albums.FindAsync(id);
            return entity ?? throw new Exception("Entity not found");
        }
    }
}
