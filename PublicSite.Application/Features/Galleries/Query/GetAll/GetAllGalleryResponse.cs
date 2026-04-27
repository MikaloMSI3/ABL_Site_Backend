using PublicSite.Application.Dtos.Actualities;
using PublicSite.Application.Dtos.Galleries;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Galleries.Query.GetAll
{
    public record GetAllGalleryResponse
    {
        public IEnumerable<GalleryDto>? Results { get; set; }
        public long TotalCount { get; set; }
    }
}
