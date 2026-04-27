using PublicSite.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Domain.Interfaces.Repositories.Query
{
    public interface IFaqRepositoryQuery
    {
        Task<Faq> GetByIdFaqAsync(Guid id);
        Task<(IEnumerable<Faq> Result, long TotalCount)> GetAllFaqAsync(Guid? categoryId, int? limit = null, bool? orderByDate = false, bool? includeCategory = false);
    }
}
