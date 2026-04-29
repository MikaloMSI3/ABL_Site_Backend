using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Galleries.Command.CreateMany
{
    public record CreateManyGalleryCommand
    (
        Guid AlbumId,
        IFormFile[] Ressources
    ) : IRequest<CreateManyGalleryResponse>;
}
