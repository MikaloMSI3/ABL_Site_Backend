using MediatR;
using PublicSite.Domain.Entities.Models;
using PublicSite.Domain.Interfaces.Repositories;
using PublicSite.Domain.Interfaces.Repositories.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.ActualityCategories.Command.Create
{
    public class CreateActualityCatCommandHandler(IActualityCatRepositoryCommand _repository, IUnitOfWork _unitOfWork) : IRequestHandler<CreateActualityCatCommand, CreateActualityCatResponse>
    {
        public async Task<CreateActualityCatResponse> Handle(CreateActualityCatCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.AddActualityCategoryAsync(ActualityCategory.Create(request.Name));
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new CreateActualityCatResponse
                (
                    entity.Id,
                    entity.CreatedAt,
                    entity.Name
                );
        }
    }
}
