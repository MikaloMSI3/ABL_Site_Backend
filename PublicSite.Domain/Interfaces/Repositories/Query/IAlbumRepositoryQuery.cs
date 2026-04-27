using PublicSite.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Domain.Interfaces.Repositories.Query
{
    public interface IAlbumRepositoryQuery
    {
        Task<Album> GetByIdAlbumAsync(Guid id);
        Task<(IEnumerable<Album> Result, long TotalCount)> GetAllAlbumAsync(int? limit = null, bool? includeGalleries = false);
    }
}
