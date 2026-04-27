using Microsoft.EntityFrameworkCore;
using PublicSite.Domain.Entities.Models;
using PublicSite.Domain.Interfaces.Repositories.Query;
using PublicSite.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Infrastructure.Persistence.Repositories.Query
{
    public class FaqCatRepositoryQuery(DBContext _context) : IFaqCatRepositoryQuery
    {
        private readonly DbSet<FaqCategory> _categories = _context.FaqCategories;
        public async Task<(IEnumerable<FaqCategory> Result, long TotalCount)> GetAllActualityCategoryAsync(int? limit = null, bool? includeFaq = false)
        {
            IQueryable<FaqCategory> query = _categories;

            query = query.Where(x => x.IsDeleted == false).OrderByDescending(x => x.CreatedAt);

            var totalCount = query.Count();

            if (limit.HasValue)
                query = query.Take(limit.Value);

            if (includeFaq.HasValue && includeFaq == true)
                query = query.Include(x => x.Faqs);

            return (await query.ToListAsync(), totalCount);
        }

        public async Task<FaqCategory> GetByIdFaqCategoryAsync(Guid id)
        {
            var entity = await _categories.FindAsync(id);
            return entity ?? throw new Exception("Entity not found");
        }
    }
}
