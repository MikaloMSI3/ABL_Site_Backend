using Microsoft.AspNetCore.Http;
using PublicSite.Domain.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Galleries.Command.Update
{
    public record UpdateGalleryResponse
    (
        Guid Id,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        DateTime? Date,
        string? Description,
        Ressource Ressource,
        Guid? AlbumId
    );
}
