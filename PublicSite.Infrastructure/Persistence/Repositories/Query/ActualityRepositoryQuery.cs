using Microsoft.EntityFrameworkCore;
using PublicSite.Domain.Entities.Models;
using PublicSite.Domain.Interfaces.Repositories.Query;
using PublicSite.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Infrastructure.Persistence.Repositories.Query
{
    public class ActualityRepositoryQuery(DBContext _context) : IActualityRepositoryQuery
    {
        private readonly DbSet<Actuality> _news = _context.News;
        public async Task<(IEnumerable<Actuality> Result, long TotalCount)> GetAllActualityAsync(Guid? categoryId,int? limit = null, bool? orderByDate = false, bool? includeCategory = false)
        {
            IQueryable<Actuality> query = _news;

            query = query.Where(x => x.IsDeleted == false);

            if (categoryId.HasValue)
                query = query.Where(x => x.ActualityCategoryId == categoryId.Value);
            
            var totalCount = query.Count();

            if (includeCategory.HasValue && includeCategory.Value == true)
                query = query.Include(x => x.Category);

            if (limit.HasValue)
                query = query.Take(limit.Value);

            if (orderByDate.HasValue && orderByDate.Value == true)
                query = query.OrderByDescending(x => x.Date);
            else
                query = query.OrderByDescending(x => x.CreatedAt);

            return (await query.ToListAsync(), totalCount);
        }

        public async Task<Actuality> GetByIdActualityAsync(Guid id)
        {
            var entity = await _news.FindAsync(id);
            return entity ?? throw new Exception("Entity not found");
        }
    }
}
