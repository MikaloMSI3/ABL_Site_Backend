using PublicSite.Domain.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Dtos.Galleries
{
    public record GalleryDto
    (
        Guid Id,
        DateTime? Date,
        string? Description,
        Ressource? Ressource,
        Guid? AlbumId,
        string? AlbumName
    );
}
