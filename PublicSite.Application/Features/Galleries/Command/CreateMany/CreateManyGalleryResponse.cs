using PublicSite.Application.Dtos.Galleries;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Galleries.Command.CreateMany
{
    public record CreateManyGalleryResponse
    (
        Guid AlbumId,
        List<GalleryGetManyDto> Galleries
    );
}
