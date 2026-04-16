using Microsoft.EntityFrameworkCore;
using PublicSite.Domain.Entities.Models;
using PublicSite.Domain.Interfaces.Repositories.Query;
using PublicSite.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Infrastructure.Persistence.Repositories.Query
{
    public class ActualityCatRepositoryQuery(DBContext _context) : IActualityCatRepositoryQuery
    {
        private readonly DbSet<ActualityCategory> _categories = _context.ActualityCategories;
        public async Task<(IEnumerable<ActualityCategory> Result, long TotalCount)> GetAllActualityCategoryAsync(int? limit = null, bool? includeActualities = false)
        {
            IQueryable<ActualityCategory> query = _categories;

            query = query.Where(x => x.IsDeleted == false).OrderByDescending(x => x.CreatedAt);

            var totalCount = query.Count();

            if (limit.HasValue)
                query = query.Take(limit.Value);

            if (includeActualities.HasValue && includeActualities == true)
                query = query.Include(x => x.Actualities);

            return (await query.ToListAsync(), totalCount);
        }

        public async Task<ActualityCategory> GetByIdActualityCategoryAsync(Guid id)
        {
            var entity = await _categories.FindAsync(id);
            return entity ?? throw new Exception("Entity not found");
        }
    }
}
