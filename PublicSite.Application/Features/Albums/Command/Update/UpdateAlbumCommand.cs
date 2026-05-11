using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Albums.Command.Update
{
    public record UpdateAlbumCommand(Guid Id, string Name) : IRequest<UpdateAlbumResponse>;
}
