using PublicSite.Application.Dtos.Actualities;
using PublicSite.Application.Dtos.Galleries;
using PublicSite.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Mappers
{
    public static class AlbumMapper
    {
        public static AlbumDto ToDto(Album album)
        {
            return new AlbumDto
            (
                Id: album.Id,
                CreatedAt: album.CreatedAt,
                Name: album.Name,
                Galleries: album.Galleries?.Select(x => new GalleryWithAlbumDto(
                    Id: x.Id,
                    Date: x.Date,
                    Description: x.Description,
                    Ressource: x.Ressource,
                    AlbumId : x.AlbumId
                ))
            );
        }
    }
}
