using MediatR;
using PublicSite.Domain.Interfaces.Repositories;
using PublicSite.Domain.Interfaces.Repositories.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.ActualityCategories.Command.Update
{
    public class UpdateActualityCatCommandHandler(IActualityCatRepositoryCommand _repository, IUnitOfWork _unitOfWork) : IRequestHandler<UpdateActualityCatCommand, UpdateActualityCatResponse>
    {
        public async Task<UpdateActualityCatResponse> Handle(UpdateActualityCatCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.UpdateActualityCategoryAsync(request.Id, request.Name);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new UpdateActualityCatResponse
            (
                entity.Id,
                entity.CreatedAt,
                entity.UpdatedAt,
                entity.Name
            );
        }
    }
}
