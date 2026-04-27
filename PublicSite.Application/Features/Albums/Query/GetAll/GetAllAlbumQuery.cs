using MediatR;
using PublicSite.Application.Features.ActualityCategories.Query.GetAll;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Albums.Query.GetAll
{
    public record GetAllAlbumQuery(int? Limit = null, bool? IncludeGalleries = false) : IRequest<GetAllAlbumResponse>;
}
