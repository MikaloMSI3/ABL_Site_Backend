using Microsoft.EntityFrameworkCore;
using PublicSite.Domain.Entities.Models;
using PublicSite.Domain.Interfaces.Repositories.Query;
using PublicSite.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Infrastructure.Persistence.Repositories.Query
{
    public class HeroRepositoryQuery(DBContext _context) : IHeroRepositoryQuery
    {
        private readonly DbSet<Image> _images = _context.Images;
        public async Task<(IEnumerable<Image> Result, long TotalCount)> GetAllHeroAsync(int? limit = null)
        {
            IQueryable<Image> query = _images;

            query = query.Where(x => x.IsDeleted == false).OrderBy(x => x.CreatedAt);

            var totalCount = query.Count();

            if (limit.HasValue)
                query = query.Take(limit.Value);

            return (await query.ToListAsync(), totalCount);
        }

        public async Task<Image> GetByIdHeroAsync(Guid id)
        {
            var entity = await _images.FindAsync(id);
            return entity ?? throw new Exception("Entity not found");
        }
    }
}
