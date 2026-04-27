using MediatR;
using PublicSite.Application.Features.Actualities.Command.Create;
using PublicSite.Application.Interfaces;
using PublicSite.Domain.Entities.Models;
using PublicSite.Domain.Interfaces.Repositories;
using PublicSite.Domain.Interfaces.Repositories.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Galleries.Command.Create
{
    public class CreateGalleryCommandHandler(IGalleryRepositoryCommand _repository, IFileStorageService _fileStorageService, IUnitOfWork _unitOfWork) : IRequestHandler<CreateGalleryCommand, CreateGalleryResponse>
    {
        public async Task<CreateGalleryResponse> Handle(CreateGalleryCommand request, CancellationToken cancellationToken)
        {
            var ressource = await _fileStorageService.SaveFileAsync(request.Ressource, "galleries");
            var newEntity = Gallery.Create(request.Date, request.Description, request.AlbumId, ressource);

            var entity = await _repository.AddGalleryAsync(newEntity);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new CreateGalleryResponse(
               entity.Id,
               entity.CreatedAt,
               entity.Date,
               entity.Description,
               entity.Ressource,
               entity.AlbumId
            );
        }
    }
}
