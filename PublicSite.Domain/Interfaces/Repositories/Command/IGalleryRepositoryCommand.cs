using PublicSite.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Domain.Interfaces.Repositories.Command
{
    public interface IGalleryRepositoryCommand
    {
        Task<Gallery> AddGalleryAsync(Gallery actuality);
        Task<Gallery> UpdateGalleryAsync(Guid id, Gallery actuality);
        Task<bool> SoftDeleteGalleryAsync(Guid id);
    }
}
