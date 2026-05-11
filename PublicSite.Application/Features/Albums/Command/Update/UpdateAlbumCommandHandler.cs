using MediatR;
using PublicSite.Domain.Interfaces.Repositories;
using PublicSite.Domain.Interfaces.Repositories.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Albums.Command.Update
{
    public class UpdateAlbumCommandHandler(IAlbumRepositoryCommand _repository, IUnitOfWork _unitOfWork) : IRequestHandler<UpdateAlbumCommand, UpdateAlbumResponse>
    {
        public async Task<UpdateAlbumResponse> Handle(UpdateAlbumCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.UpdateAlbumAsync(request.Id, request.Name);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new UpdateAlbumResponse
            (
                entity.Id,
                entity.CreatedAt,
                entity.UpdatedAt,
                entity.Name
            );
        }
    }
}
