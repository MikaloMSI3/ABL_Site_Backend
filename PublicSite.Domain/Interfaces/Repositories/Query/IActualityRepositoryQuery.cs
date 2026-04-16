using PublicSite.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Domain.Interfaces.Repositories.Query
{
    public interface IActualityRepositoryQuery
    {
        Task<Actuality> GetByIdActualityAsync(Guid id);
        Task<(IEnumerable<Actuality> Result, long TotalCount)> GetAllActualityAsync(Guid? categoryId, int? limit = null, bool? orderByDate = false);
    }
}
