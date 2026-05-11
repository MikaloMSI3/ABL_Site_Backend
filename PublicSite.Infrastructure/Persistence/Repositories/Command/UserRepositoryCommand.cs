using Microsoft.EntityFrameworkCore;
using PublicSite.Domain.Entities.Models;
using PublicSite.Domain.Interfaces.Repositories.Command;
using PublicSite.Domain.Interfaces.Repositories.Query;
using PublicSite.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Infrastructure.Persistence.Repositories.Command
{
    public class UserRepositoryCommand(DBContext _context, IUserRepositoryQuery _query) : IUserRepositoryCommand
    {
        private readonly DbSet<User> _users = _context.Users;
        public async Task<User> AddUserAsync(User user)
        {
            var entity = User.Create(user.Email, user.Password);
            await _users.AddAsync(entity);

            return entity;
        }

        public async Task<User> SoftDeleteUserAsync(Guid id)
        {
            var entity = await _query.GetByIdUserAsync(id);
            entity.SoftDelete();

            return entity;
        }

        public async Task<User> UpdateUserAsync(Guid id, User user)
        {
            var entity = await _query.GetByIdUserAsync(id);
            entity.Update(user.Email, user.Password);
            return entity;
        }
    }
}
