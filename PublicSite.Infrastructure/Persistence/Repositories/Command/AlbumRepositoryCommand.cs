using Microsoft.EntityFrameworkCore;
using PublicSite.Domain.Entities.Models;
using PublicSite.Domain.Interfaces.Repositories.Command;
using PublicSite.Domain.Interfaces.Repositories.Query;
using PublicSite.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Infrastructure.Persistence.Repositories.Command
{
    public class AlbumRepositoryCommand(DBContext _context, IAlbumRepositoryQuery _query) : IAlbumRepositoryCommand
    {
        private readonly DbSet<Album> _albums = _context.Albums;
        public async Task<Album> AddAlbumAsync(Album album)
        {
            var entity = Album.Create(album.Name);
            await _albums.AddAsync(entity);
            return entity;
        }

        public async Task<bool> SoftDeleteAlbumAsync(Guid id)
        {
            var entity = _query.GetByIdAlbumAsync(id);
            entity.Result.SoftDelete();
            return entity != null;
        }
    }
}
