using MediatR;
using Microsoft.AspNetCore.Http;
using PublicSite.Domain.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Galleries.Command.Create
{
    public record CreateGalleryCommand
    (
        DateTime? Date,
        string? Description,
        IFormFile Ressource,
        Guid? AlbumId
    ) : IRequest<CreateGalleryResponse>;
}