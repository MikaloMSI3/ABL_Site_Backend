using MediatR;
using PublicSite.Application.Features.ActualityCategories.Query.GetAll;
using PublicSite.Application.Mappers;
using PublicSite.Domain.Interfaces.Repositories.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Albums.Query.GetAll
{
    public class GetAllAlbumQueryHandler(IAlbumRepositoryQuery _repository) : IRequestHandler<GetAllAlbumQuery, GetAllAlbumResponse>
    {
        public async Task<GetAllAlbumResponse> Handle(GetAllAlbumQuery request, CancellationToken cancellationToken)
        {
            var (Result, TotalCount) = await _repository.GetAllAlbumAsync(request.Limit, request.IncludeGalleries);

            return new GetAllAlbumResponse
            {
                Results = Result.Select(x => AlbumMapper.ToDto(x)),
                TotalCount = TotalCount
            };
        }
    }
}
