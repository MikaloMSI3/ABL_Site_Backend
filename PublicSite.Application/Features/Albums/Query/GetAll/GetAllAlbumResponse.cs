using PublicSite.Application.Dtos.Actualities;
using PublicSite.Application.Dtos.Galleries;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Albums.Query.GetAll
{
    public record GetAllAlbumResponse
    {
        public IEnumerable<AlbumDto>? Results { get; set; }
        public long TotalCount { get; set; }
    }
}
