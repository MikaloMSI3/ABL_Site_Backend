using PublicSite.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Domain.Interfaces.Repositories.Query
{
    public interface IContactRepositoryQuery
    {
        Task<Contact> GetByIdContactAsync(Guid id);
        Task<(IEnumerable<Contact> Result, long TotalCount)> GetAllContactAsync(int? limit = null);
    }
}
