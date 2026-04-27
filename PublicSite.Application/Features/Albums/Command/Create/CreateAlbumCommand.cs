using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Albums.Command.Create
{
    public record CreateAlbumCommand(string Name) : IRequest<CreateAlbumResponse>;
}
