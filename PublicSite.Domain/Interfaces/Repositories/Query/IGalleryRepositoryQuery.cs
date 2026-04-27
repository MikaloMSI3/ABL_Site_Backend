using PublicSite.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Domain.Interfaces.Repositories.Query
{
    public interface IGalleryRepositoryQuery
    {
        Task<Gallery> GetByIdGalleryAsync(Guid id);
        Task<(IEnumerable<Gallery> Result, long TotalCount)> GetAllGalleryAsync(Guid? albumId, int? limit = null, bool? orderByDate = false, bool? includeAlbum = false);
    }
}
