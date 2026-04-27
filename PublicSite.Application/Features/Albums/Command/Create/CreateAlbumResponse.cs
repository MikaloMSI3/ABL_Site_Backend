using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Albums.Command.Create
{
    public record CreateAlbumResponse
    (
        Guid Id,
        DateTime CreatedAt,
        string Name
    );
}
