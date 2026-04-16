using MediatR;
using PublicSite.Application.Dtos;
using PublicSite.Application.Interfaces;
using PublicSite.Domain.Entities.Models;
using PublicSite.Domain.Interfaces.Repositories;
using PublicSite.Domain.Interfaces.Repositories.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Actualities.Command.Create
{
    public class CreateActualityCommandHandler(IActualityRepositoryCommand _repository, IFileStorageService _fileStorageService,IUnitOfWork _unitOfWork) : IRequestHandler<CreateActualityCommand, CreateActualityResponse>
    {
        public async Task<CreateActualityResponse> Handle(CreateActualityCommand request, CancellationToken cancellationToken)
        {
            var newEntity = Actuality.Create(request.Date, request.Title, request.Description, request.ActualityCategoryId, null);
            if (request.Ressource != null)
                newEntity.Update(ressource: await _fileStorageService.SaveFileAsync(request.Ressource, "Actualities"));

            var entity = await _repository.AddActualityAsync(newEntity);
            await _unitOfWork.SaveChangesAsync();

            return new CreateActualityResponse(
               entity.Id,
               entity.CreatedAt,
               entity.Date,
               entity.Title,
               entity.Description,
               entity.Ressource,
               entity.ActualityCategoryId
            );
        }
    }
}
