using MediatR;
using PublicSite.Application.Interfaces;
using PublicSite.Domain.Entities.Models;
using PublicSite.Domain.Interfaces.Repositories;
using PublicSite.Domain.Interfaces.Repositories.Command;
using PublicSite.Domain.Interfaces.Repositories.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Actualities.Command.Update
{
    public class UpdateActualityCommandHandler(IActualityRepositoryCommand _repository, IActualityRepositoryQuery _queryRepo, IUnitOfWork _unitOfWork, IFileStorageService _fileStorageService) : IRequestHandler<UpdateActualityCommand, UpdateActualityResponse>
    {
        public async Task<UpdateActualityResponse> Handle(UpdateActualityCommand request, CancellationToken cancellationToken)
        {
            var act = new Actuality(request.Date, request.Title, request.Description, request.ActualityCategoryId);
            var actualAct = _queryRepo.GetByIdActualityAsync(request.Id);

            if (request.Ressource != null)
            {
                act.Update(ressource: await _fileStorageService.SaveFileAsync(request.Ressource, "Actualities"));
                if (actualAct.Result.Ressource != null)
                    _fileStorageService.DeleteFileAsync(actualAct.Result.Ressource);
            }
              
            var entity = await _repository.UpdateActualityAsync(request.Id, act);

            return new UpdateActualityResponse(
                entity.Id,
                entity.CreatedAt,
                entity.UpdatedAt,
                entity.Date,
                entity.Title,
                entity.Description,
                entity.Ressource,
                entity.ActualityCategoryId
            );
        }
    }
}
