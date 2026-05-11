using MediatR;
using PublicSite.Application.Features.Galleries.Command.Update;
using PublicSite.Application.Interfaces;
using PublicSite.Domain.Interfaces.Repositories;
using PublicSite.Domain.Interfaces.Repositories.Command;
using PublicSite.Domain.Interfaces.Repositories.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Sponsors.Command.Update
{
    public class UpdateSponsorCommandHandler(ISponsorRepositoryCommand _repository, ISponsorRepositoryQuery _queryRepo, IUnitOfWork _unitOfWork, IFileStorageService _fileStorageService) : IRequestHandler<UpdateSponsorCommand, UpdateSponsorResponse>
    {
        public async Task<UpdateSponsorResponse> Handle(UpdateSponsorCommand request, CancellationToken cancellationToken)
        {
            var act = await _queryRepo.GetByIdSponsorAsync(request.Id);
            act.Update(request.Name, siteUrl: request.SiteUrl);

            if (request.Ressource != null)
            {
                act.Update(logo: await _fileStorageService.SaveFileAsync(request.Ressource, "sponsors"));
                if (act.Logo != null)
                    _fileStorageService.DeleteFileAsync(act.Logo);
            }

            var entity = await _repository.UpdateSponsorAsync(request.Id, act);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new UpdateSponsorResponse(
                entity.Id,
                entity.CreatedAt,
                entity.UpdatedAt,
                entity.Name,
                entity.Logo,
                entity.SiteUrl
            );
        }
    }
}
