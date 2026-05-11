using PublicSite.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Domain.Interfaces.Repositories.Command
{
    public interface IAlbumRepositoryCommand
    {
        Task<Album> AddAlbumAsync(Album actuality);
        Task<Album> SoftDeleteAlbumAsync(Guid id);
        Task<Album> UpdateAlbumAsync(Guid id, string name);
    }
}
