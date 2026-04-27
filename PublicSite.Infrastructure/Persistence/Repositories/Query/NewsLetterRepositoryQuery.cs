using Microsoft.EntityFrameworkCore;
using PublicSite.Domain.Entities.Models;
using PublicSite.Domain.Interfaces.Repositories.Query;
using PublicSite.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Infrastructure.Persistence.Repositories.Query
{
    public class NewsLetterRepositoryQuery(DBContext _context) : INewsLetterRepositoryQuery
    {
        private readonly DbSet<NewsLetter> _newsLetters = _context.NewsLetters;
        public async Task<(IEnumerable<NewsLetter> Result, long TotalCount)> GetAllNewsLetterAsync(int? limit = null, bool? includeGalleries = false)
        {
            IQueryable<NewsLetter> query = _newsLetters;

            query = query.Where(x => x.IsDeleted == false).OrderBy(x => x.CreatedAt);

            var totalCount = query.Count();

            if (limit.HasValue)
                query = query.Take(limit.Value);

            return (await query.ToListAsync(), totalCount);
        }

        public async Task<NewsLetter> GetByIdNewsLetterAsync(Guid id)
        {
            var entity = await _newsLetters.FindAsync(id);
            return entity ?? throw new Exception("Entity not found");
        }
    }
}
