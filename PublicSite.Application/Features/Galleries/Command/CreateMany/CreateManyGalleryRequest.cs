using Microsoft.AspNetCore.Http;
using PublicSite.Domain.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Galleries.Command.CreateMany
{
    public record CreateManyGalleryRequest
    (
        IFormFile[] Ressources
    );
}
