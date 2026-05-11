using Microsoft.EntityFrameworkCore;
using PublicSite.Domain.Entities.Models;
using PublicSite.Domain.Interfaces.Repositories.Query;
using PublicSite.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Infrastructure.Persistence.Repositories.Query
{
    public class FaqRepositoryQuery(DBContext _context) : IFaqRepositoryQuery
    {
        private readonly DbSet<Faq> _faqs = _context.Faqs;
        public async Task<(IEnumerable<Faq> Result, long TotalCount)> GetAllFaqAsync(Guid? categoryId, int? limit = null, bool? orderByDate = false, bool? includeCategory = false)
        {
            IQueryable<Faq> query = _faqs;

            query = query.Where(x => x.IsDeleted == false).OrderByDescending(x => x.CreatedAt);

            if (categoryId.HasValue)
                query = query.Where(x => x.FaqCategoryId == categoryId.Value);

            var totalCount = query.Count();

            if (includeCategory.HasValue && includeCategory.Value == true)
                query = query.Include(x => x.Category);

            if (limit.HasValue)
                query = query.Take(limit.Value);

            return (await query.ToListAsync(), totalCount);
        }

        public async Task<Faq?> GetByIdFaqAsync(Guid id)
        {
            var entity = await _faqs.Include(x => x.Category).FirstOrDefaultAsync();
            return entity ?? null;
        }
    }
}
