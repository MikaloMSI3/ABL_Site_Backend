using PublicSite.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Domain.Interfaces.Repositories.Query
{
    public interface INewsLetterRepositoryQuery
    {
        Task<NewsLetter> GetByIdNewsLetterAsync(Guid id);
        Task<(IEnumerable<NewsLetter> Result, long TotalCount)> GetAllNewsLetterAsync(int? limit = null, bool? includeGalleries = false);
    }
}
