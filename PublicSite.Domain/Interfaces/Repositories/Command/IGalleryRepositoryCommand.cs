using PublicSite.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Domain.Interfaces.Repositories.Command
{
    public interface IGalleryRepositoryCommand
    {
        Task<Gallery> AddGalleryAsync(Gallery gallery);
        Task<List<Gallery>> AddManyGalleryAsync(List<Gallery> gallery);
        Task<Gallery> UpdateGalleryAsync(Guid id, Gallery gallery);
        Task<Gallery> SoftDeleteGalleryAsync(Guid id);
    }
}
