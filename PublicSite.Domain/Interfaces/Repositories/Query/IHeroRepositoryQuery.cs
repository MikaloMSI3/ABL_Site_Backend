using PublicSite.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Domain.Interfaces.Repositories.Query
{
    public interface IHeroRepositoryQuery
    {
        Task<Image> GetByIdHeroAsync(Guid id);
        Task<(IEnumerable<Image> Result, long TotalCount)> GetAllHeroAsync(int? limit = null);
    }
}
