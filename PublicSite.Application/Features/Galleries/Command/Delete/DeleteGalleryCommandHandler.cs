using MediatR;
using PublicSite.Application.Features.Actualities.Command.Delete;
using PublicSite.Domain.Interfaces.Repositories;
using PublicSite.Domain.Interfaces.Repositories.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Galleries.Command.Delete
{
    public class DeleteGalleryCommandHandler(IGalleryRepositoryCommand _repository, IUnitOfWork _unitOfWork) : IRequestHandler<DeleteGalleryCommand, DeleteGalleryResponse>
    {
        public async Task<DeleteGalleryResponse> Handle(DeleteGalleryCommand request, CancellationToken cancellationToken)
        {
            var result = await _repository.SoftDeleteGalleryAsync(request.Id);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new DeleteGalleryResponse(result);
        }
    }
}
