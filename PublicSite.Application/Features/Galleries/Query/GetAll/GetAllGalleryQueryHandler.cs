using MediatR;
using PublicSite.Application.Features.Actualities.Query.GetAll;
using PublicSite.Application.Mappers;
using PublicSite.Domain.Interfaces.Repositories;
using PublicSite.Domain.Interfaces.Repositories.Command;
using PublicSite.Domain.Interfaces.Repositories.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Galleries.Query.GetAll
{
    public class GetAllGalleryQueryHandler(IGalleryRepositoryQuery _repository) : IRequestHandler<GetAllGalleryQuery, GetAllGalleryResponse>
    {
        public async Task<GetAllGalleryResponse> Handle(GetAllGalleryQuery request, CancellationToken cancellationToken)
        {
            var (Results, TotalCount) = await _repository.GetAllGalleryAsync(request.AlbumId, request.Limit, request.OrderByDate, includeAlbum: true);

            return new GetAllGalleryResponse
            {
                Results = [.. Results.Select(x => GalleryMapper.ToDto(x))],
                TotalCount = TotalCount
            };
        }
    }
}
