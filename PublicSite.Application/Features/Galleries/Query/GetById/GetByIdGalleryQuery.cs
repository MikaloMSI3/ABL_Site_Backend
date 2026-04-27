using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Galleries.Query.GetById
{
    public record GetByIdGalleryQuery(Guid Id) : IRequest<GetByIdGalleryResponse>;
}
