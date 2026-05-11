using MediatR;
using PublicSite.Domain.Interfaces.Repositories;
using PublicSite.Domain.Interfaces.Repositories.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.FaqCategories.Command.Update
{
    public record UpdateFaqCatCommandHandler(IFaqCatRepositoryCommand _repository, IUnitOfWork _unitOfWork) : IRequestHandler<UpdateFaqCatCommand, UpdateFaqCatResponse>
    {
        public async Task<UpdateFaqCatResponse> Handle(UpdateFaqCatCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.UpdateFaqCategoryAsync(request.Id, request.Name);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new UpdateFaqCatResponse
            (
                entity.Id,
                entity.CreatedAt,
                entity.UpdatedAt,
                entity.Name
            );
        }
    }
}
