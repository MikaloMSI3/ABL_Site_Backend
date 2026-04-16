using PublicSite.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Domain.Interfaces.Repositories.Query
{
    public interface IActualityCatRepositoryQuery
    {
        Task<ActualityCategory> GetByIdActualityCategoryAsync(Guid id);
        Task<(IEnumerable<ActualityCategory> Result, long TotalCount)> GetAllActualityCategoryAsync(int? limit = null, bool? includeActualities = false);
    }
}
