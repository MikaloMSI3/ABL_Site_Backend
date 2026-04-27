using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Galleries.Command.Update
{
    public record UpdateGalleryRequest
    (
        DateTime? Date,
        string? Description,
        IFormFile Ressource,
        Guid? AlbumId
    );
}
