using PublicSite.Domain.Entities.Models;
using PublicSite.Domain.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Galleries.Command.Create
{
    public record CreateGalleryResponse
    (
        Guid Id,
        DateTime CreatedAt,
        DateTime? Date,
        string? Description,
        Ressource? Ressource,
        Guid? AlbumId
    );
}
