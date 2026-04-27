using MediatR;
using PublicSite.Application.Features.ActualityCategories.Command.Create;
using PublicSite.Domain.Entities.Models;
using PublicSite.Domain.Interfaces.Repositories;
using PublicSite.Domain.Interfaces.Repositories.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Albums.Command.Create
{
    public class CreateAlbumCommandHandler(IAlbumRepositoryCommand _repository, IUnitOfWork _unitOfWork) : IRequestHandler<CreateAlbumCommand, CreateAlbumResponse>
    {
        public async Task<CreateAlbumResponse> Handle(CreateAlbumCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.AddAlbumAsync(Album.Create(request.Name));
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new CreateAlbumResponse
            (
                entity.Id,
                entity.CreatedAt,
                entity.Name
            );
        }
    }
}
