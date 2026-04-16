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
        public async Task<(IEnumerable<Actuality> Result, long TotalCount)> GetAllActualityAsync(Guid? categoryId,int? limit = null)
        {
            IQueryable<Actuality> query = _news;
            
            if (categoryId.HasValue)
                query = query.Where(x => x.ActualityCategoryId == categoryId.Value && x.IsDeleted == false);
            
            var totalCount = query.Count();

            if (limit.HasValue)
                query = query.Take(limit.Value);

            return (await query.ToListAsync(), totalCount);
        }

        public async Task<Actuality> GetByIdActualityAsync(Guid id)
        {
            var entity = await _news.FindAsync(id);
            return entity ?? throw new Exception("Entity not found");
        }
    }
}
