using Microsoft.EntityFrameworkCore;
using PublicSite.Domain.Entities.Models;
using PublicSite.Domain.Interfaces.Repositories.Query;
using PublicSite.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Infrastructure.Persistence.Repositories.Query
{
    public class ContactRepositoryQuery(DBContext _context) : IContactRepositoryQuery
    {
        private readonly DbSet<Contact> _contacts = _context.Contacts;
        public async Task<(IEnumerable<Contact> Result, long TotalCount)> GetAllContactAsync(int? limit = null)
        {
            IQueryable<Contact> query = _contacts;

            query = query.Where(x => x.IsDeleted == false).OrderBy(x => x.CreatedAt);

            var totalCount = query.Count();

            if (limit.HasValue)
                query = query.Take(limit.Value);

            return (await query.ToListAsync(), totalCount);
        }

        public async Task<Contact> GetByIdContactAsync(Guid id)
        {
            var entity = await _contacts.FindAsync(id);
            return entity ?? throw new Exception("Entity not found");
        }
    }
}
