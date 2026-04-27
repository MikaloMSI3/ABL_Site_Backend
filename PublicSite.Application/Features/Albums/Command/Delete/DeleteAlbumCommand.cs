using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Albums.Command.Delete
{
    public record DeleteAlbumCommand(Guid Id) : IRequest<DeleteAlbumResponse>;
}
