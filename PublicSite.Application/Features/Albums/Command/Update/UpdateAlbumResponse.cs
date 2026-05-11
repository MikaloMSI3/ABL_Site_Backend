using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Albums.Command.Update
{
    public record UpdateAlbumResponse
    (
        Guid Id,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        string Name
    );
}
