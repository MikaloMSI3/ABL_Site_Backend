using PublicSite.Application.Dtos.Galleries;
using PublicSite.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Mappers
{
    public static class GalleryMapper
    {
        public static GalleryDto ToDto(Gallery gallery)
        {
            return new GalleryDto
            (
                Id : gallery.Id,
                Date : gallery.Date,
                Description : gallery.Description,
                Ressource : gallery.Ressource,
                AlbumId : gallery.AlbumId,
                AlbumName : gallery.Album?.Name
            );
        }

        public static GalleryGetManyDto ToGetManyDto(Gallery gallery)
        {
            return new GalleryGetManyDto
            (
                Id: gallery.Id,
                CreatedAt : gallery.CreatedAt,
                Ressource: gallery.Ressource
            );
        }
    }
}
