using MediatR;
using PublicSite.Application.Interfaces;
using PublicSite.Application.Mappers;
using PublicSite.Domain.Entities.Models;
using PublicSite.Domain.Interfaces.Repositories;
using PublicSite.Domain.Interfaces.Repositories.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Galleries.Command.CreateMany
{
    public class CreateManyGalleryCommandHandler(IGalleryRepositoryCommand _repository, IFileStorageService _fileStorageService, IUnitOfWork _unitOfWork) : IRequestHandler<CreateManyGalleryCommand, CreateManyGalleryResponse>
    {
        public async Task<CreateManyGalleryResponse> Handle(CreateManyGalleryCommand request, CancellationToken cancellationToken)
        {
            var ressources = await _fileStorageService.SaveManyFileAsync(request.Ressources, "galleries");

            var galleryList = new List<Gallery>();
            foreach (var gallery in ressources)
            {
                galleryList.Add(Gallery.Create(request.AlbumId, gallery));
            }

            var list = await _repository.AddManyGalleryAsync(galleryList);
            await _unitOfWork.SaveChangesAsync();

            return new CreateManyGalleryResponse
            (
                AlbumId : request.AlbumId,
                Galleries : list.Select(x => GalleryMapper.ToGetManyDto(x)).ToList()
            );
        }
    }
}
