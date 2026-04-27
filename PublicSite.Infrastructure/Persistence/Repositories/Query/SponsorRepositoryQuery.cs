using Microsoft.EntityFrameworkCore;
using PublicSite.Domain.Entities.Models;
using PublicSite.Domain.Interfaces.Repositories.Query;
using PublicSite.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace PublicSite.Infrastructure.Persistence.Repositories.Query
{
    public class SponsorRepositoryQuery(DBContext _context) : ISponsorRepositoryQuery
    {
        private readonly DbSet<Sponsor> _sponsors = _context.Sponsors;
        public async Task<(IEnumerable<Sponsor> Result, long TotalCount)> GetAllSponsorAsync(int? limit = null)
        {
            IQueryable<Sponsor> query = _sponsors;

            query = query.Where(x => x.IsDeleted == false).OrderBy(x => x.CreatedAt);

            var totalCount = query.Count();

            if (limit.HasValue)
                query = query.Take(limit.Value);

            return (await query.ToListAsync(), totalCount);
        }

        public async Task<Sponsor> GetByIdSponsorAsync(Guid id)
        {
            var entity = await _sponsors.FindAsync(id);
            return entity ?? throw new Exception("Entity not found");
        }
    }
}
