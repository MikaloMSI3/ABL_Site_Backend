using MediatR;
using PublicSite.Application.Features.Actualities.Query.GetAll;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Galleries.Query.GetAll
{
    public record GetAllGalleryQuery(Guid? AlbumId = null, int? Limit = null, bool? OrderByDate = false) : IRequest<GetAllGalleryResponse>;
}
