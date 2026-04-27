using PublicSite.Application.Dtos.Faqs;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Dtos.Galleries
{
    public record AlbumDto
    (
        Guid Id,
        DateTime CreatedAt,
        string Name,
        IEnumerable<GalleryWithAlbumDto>? Galleries
    );
}
