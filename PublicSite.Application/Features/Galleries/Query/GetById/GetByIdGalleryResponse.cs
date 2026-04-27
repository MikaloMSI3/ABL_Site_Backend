using PublicSite.Domain.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Galleries.Query.GetById
{
    public record GetByIdGalleryResponse
    (
        Guid Id,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        bool IsDeleted,
        DateTime? Date,
        string? Description,
        Ressource? Ressource,
        Guid? AlbumId,
        string? AlbumName
    );
}
