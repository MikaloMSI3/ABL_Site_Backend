using PublicSite.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Domain.Interfaces.Repositories.Query
{
    public interface IUserRepositoryQuery
    {
        Task<User> GetByIdUserAsync(Guid id);
        Task<User?> GetByEmail(string email);
        Task<User?> GetByRefreshAsync(string refreshToken);
        Task<(IEnumerable<User> Result, long TotalCount)> GetAllUserAsync();
    }
}
