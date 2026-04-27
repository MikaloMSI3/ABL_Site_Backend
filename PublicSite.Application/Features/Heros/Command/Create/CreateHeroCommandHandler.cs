using MediatR;
using PublicSite.Application.Features.Albums.Command.Create;
using PublicSite.Application.Interfaces;
using PublicSite.Domain.Entities.Models;
using PublicSite.Domain.Interfaces.Repositories;
using PublicSite.Domain.Interfaces.Repositories.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Heros.Command.Create
{
    public class CreateHeroCommandHandler(IHeroRepositoryCommand _repository, IUnitOfWork _unitOfWork, IFileStorageService _fileStorageService) : IRequestHandler<CreateHeroCommand, CreateHeroResponse>
    {
        public async Task<CreateHeroResponse> Handle(CreateHeroCommand request, CancellationToken cancellationToken)
        {
            var ressource = await _fileStorageService.SaveFileAsync(request.Ressource, "Heroes");
            var newEntity = Image.Create(ressource, request.Order);

            var entity = await _repository.AddHeroAsync(newEntity);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new CreateHeroResponse
            (
                entity.Id,
                entity.CreatedAt,
                entity.Ressource,
                entity.Order
            );
        }
    }
}
