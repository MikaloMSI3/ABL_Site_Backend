using Microsoft.EntityFrameworkCore;
using PublicSite.Domain.Entities.Models;
using PublicSite.Domain.Interfaces.Repositories.Query;
using PublicSite.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Infrastructure.Persistence.Repositories.Query
{
    public class UserRepositoryQuery(DBContext _context) : IUserRepositoryQuery
    {
        private readonly DbSet<User> _users = _context.Users;
        public async Task<(IEnumerable<User> Result, long TotalCount)> GetAllUserAsync()
        {
            IQueryable<User> query = _users;

            query = query.Where(x => x.IsDeleted == false).OrderByDescending(x => x.CreatedAt);

            var totalCount = query.Count();

            return (await query.ToListAsync(), totalCount);
        }

        public async Task<User?> GetByEmail(string email)
        {
            var entity = await _users.FirstOrDefaultAsync(x => x.Email == email);
            return entity ?? null;
        }

        public async Task<User> GetByIdUserAsync(Guid id)
        {
            var entity = await _users.FindAsync(id);
            return entity ?? throw new Exception("Entity not found");
        }
    }
}
