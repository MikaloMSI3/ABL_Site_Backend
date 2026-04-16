using MediatR;
using PublicSite.Domain.Interfaces.Repositories;
using PublicSite.Domain.Interfaces.Repositories.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.ActualityCategories.Command.Delete
{
    public class DeleteActualityCatCommandHandler(IActualityCatRepositoryCommand _repository, IUnitOfWork _unitOfWork) : IRequestHandler<DeleteActualityCatCommand, DeleteActualityCatResponse>
    {
        public async Task<DeleteActualityCatResponse> Handle(DeleteActualityCatCommand request, CancellationToken cancellationToken)
        {
            var result = await _repository.SoftDeleteActualityCategoryAsync(request.Id);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new DeleteActualityCatResponse(result);
        }
    }
}
