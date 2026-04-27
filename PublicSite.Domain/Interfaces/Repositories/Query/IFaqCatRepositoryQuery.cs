using PublicSite.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Domain.Interfaces.Repositories.Query
{
    public interface IFaqCatRepositoryQuery
    {
        Task<FaqCategory> GetByIdFaqCategoryAsync(Guid id);
        Task<(IEnumerable<FaqCategory> Result, long TotalCount)> GetAllActualityCategoryAsync(int? limit = null, bool? includeFaq = false);
    }
}
