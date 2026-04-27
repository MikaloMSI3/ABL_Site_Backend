using MediatR;
using PublicSite.Application.Features.ActualityCategories.Command.Delete;
using PublicSite.Domain.Interfaces.Repositories;
using PublicSite.Domain.Interfaces.Repositories.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Albums.Command.Delete
{
    public class DeleteAlbumCommandHandler(IAlbumRepositoryCommand _repository, IUnitOfWork _unitOfWork) : IRequestHandler<DeleteAlbumCommand, DeleteAlbumResponse>
    {
        public async Task<DeleteAlbumResponse> Handle(DeleteAlbumCommand request, CancellationToken cancellationToken)
        {
            var result = await _repository.SoftDeleteAlbumAsync(request.Id);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new DeleteAlbumResponse(result);
        }
    }
}
