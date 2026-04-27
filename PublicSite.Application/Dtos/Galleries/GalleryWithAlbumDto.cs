using PublicSite.Domain.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Dtos.Galleries
{
    public record GalleryWithAlbumDto
    (
        Guid Id,
        DateTime Date,
        string? Description,
        Ressource? Ressource,
        Guid? AlbumId
    );
}
