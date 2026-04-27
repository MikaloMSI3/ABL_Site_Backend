using MediatR;
using PublicSite.Application.Features.Actualities.Query.GetById;
using PublicSite.Domain.Interfaces.Repositories.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Galleries.Query.GetById
{
    public class GetByIdGalleryQueryHandler(IGalleryRepositoryQuery _repository) : IRequestHandler<GetByIdGalleryQuery, GetByIdGalleryResponse>
    {
        public async Task<GetByIdGalleryResponse> Handle(GetByIdGalleryQuery request, CancellationToken cancellationToken)
        {
            var actuality = await _repository.GetByIdGalleryAsync(request.Id);

            return new GetByIdGalleryResponse
            (
                Id: actuality.Id,
                CreatedAt: actuality.CreatedAt,
                UpdatedAt: actuality.UpdatedAt,
                IsDeleted: actuality.IsDeleted,
                Date: actuality.Date,
                Description: actuality.Description,
                Ressource: actuality.Ressource,
                AlbumId: actuality.AlbumId,
                AlbumName: actuality.Album?.Name
            );
        }
    }
}
