using PublicSite.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Domain.Interfaces.Repositories.Command
{
    public interface IUserRepositoryCommand
    {
        Task<User> AddUserAsync(User user);
        Task<User> UpdateUserAsync(Guid id, User user);
        Task<User> SoftDeleteUserAsync(Guid id);
    }
}
