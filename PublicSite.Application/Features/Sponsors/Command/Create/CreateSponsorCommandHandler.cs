using MediatR;
using PublicSite.Application.Features.Heros.Command.Create;
using PublicSite.Application.Interfaces;
using PublicSite.Domain.Entities.Models;
using PublicSite.Domain.Interfaces.Repositories;
using PublicSite.Domain.Interfaces.Repositories.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Sponsors.Command.Create
{
    public class CreateSponsorCommandHandler(ISponsorRepositoryCommand _repository, IUnitOfWork _unitOfWork, IFileStorageService _fileStorageService) : IRequestHandler<CreateSponsorCommand, CreateSponsorResponse>
    {
        public async Task<CreateSponsorResponse> Handle(CreateSponsorCommand request, CancellationToken cancellationToken)
        {
            var ressource = await _fileStorageService.SaveFileAsync(request.Logo, "sponsors");
            var newEntity = Sponsor.Create(request.Name, ressource);

            var entity = await _repository.AddSponsorAsync(newEntity);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new CreateSponsorResponse
            (
                entity.Id,
                entity.CreatedAt,
                entity.Name,
                entity.Logo
            );
        }
    }
}
