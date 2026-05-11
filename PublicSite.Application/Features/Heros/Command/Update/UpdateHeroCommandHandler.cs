using MediatR;
using PublicSite.Application.Interfaces;
using PublicSite.Domain.Entities.Models;
using PublicSite.Domain.Interfaces.Repositories;
using PublicSite.Domain.Interfaces.Repositories.Command;
using PublicSite.Domain.Interfaces.Repositories.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Heros.Command.Update
{
    public class UpdateHeroCommandHandler(IHeroRepositoryCommand _repository, IHeroRepositoryQuery _queryRepo, IFileStorageService _fileStorageService, IUnitOfWork _unitOfWork) : IRequestHandler<UpdateHeroCommand, UpdateHeroResponse>
    {
        public async Task<UpdateHeroResponse> Handle(UpdateHeroCommand request, CancellationToken cancellationToken)
        {
            var hero = await _queryRepo.GetByIdHeroAsync(request.Id);
            hero.Update(request.Order);

            if (request.Ressource != null)
            {
                hero.Update(ressource: await _fileStorageService.SaveFileAsync(request.Ressource, "Heroes"));
                if (hero.Ressource != null)
                    _fileStorageService.DeleteFileAsync(hero.Ressource);
            }

            var entity = await _repository.UpdateHeroAsync(request.Id, hero);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new UpdateHeroResponse
            (
                hero.Id,
                hero.CreatedAt,
                hero.UpdatedAt,
                hero.Order,
                hero.Ressource
            );
        }
    }
}
