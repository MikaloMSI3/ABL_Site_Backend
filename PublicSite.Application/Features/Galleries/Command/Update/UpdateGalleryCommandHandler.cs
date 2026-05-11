using MediatR;
using PublicSite.Application.Features.Actualities.Command.Update;
using PublicSite.Application.Interfaces;
using PublicSite.Application.Services;
using PublicSite.Domain.Interfaces.Repositories;
using PublicSite.Domain.Interfaces.Repositories.Command;
using PublicSite.Domain.Interfaces.Repositories.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Galleries.Command.Update
{
    public class UpdateGalleryCommandHandler(IGalleryRepositoryCommand _repository, IGalleryRepositoryQuery _queryRepo, IUnitOfWork _unitOfWork, IFileStorageService _fileStorageService) : IRequestHandler<UpdateGalleryCommand, UpdateGalleryResponse>
    {
        public async Task<UpdateGalleryResponse> Handle(UpdateGalleryCommand request, CancellationToken cancellationToken)
        {
            var act = await _queryRepo.GetByIdGalleryAsync(request.Id);
            act.Update(request.Date, request.Description, request.AlbumId);

            if (request.Ressource != null)
            {
                act.Update(ressource: await _fileStorageService.SaveFileAsync(request.Ressource, "galleries"));
                if (act.Ressource != null)
                    _fileStorageService.DeleteFileAsync(act.Ressource);
            }

            var entity = await _repository.UpdateGalleryAsync(request.Id, act);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new UpdateGalleryResponse(
                entity.Id,
                entity.CreatedAt,
                entity.UpdatedAt,
                entity.Date,
                entity.Description,
                entity.Ressource,
                entity.AlbumId
            );
        }
    }
}
