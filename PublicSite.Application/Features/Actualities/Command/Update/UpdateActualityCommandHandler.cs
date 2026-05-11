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
            var act = await _queryRepo.GetByIdActualityAsync(request.Id);
            act.Update(request.Date, request.Title, request.Description, request.ActualityCategoryId);

            if (request.Ressource != null)
            {
                act.Update(ressource: await _fileStorageService.SaveFileAsync(request.Ressource, "actualities"));
                if (act.Ressource != null)
                    _fileStorageService.DeleteFileAsync(act.Ressource);
            }
              
            var entity = await _repository.UpdateActualityAsync(request.Id, act);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

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
