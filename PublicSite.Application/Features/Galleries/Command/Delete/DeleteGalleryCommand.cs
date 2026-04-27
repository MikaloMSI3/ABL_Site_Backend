using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Galleries.Command.Delete
{
    public record DeleteGalleryCommand(Guid Id) : IRequest<DeleteGalleryResponse>;
}
