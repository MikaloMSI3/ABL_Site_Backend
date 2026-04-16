using MediatR;
using PublicSite.Domain.Interfaces.Repositories;
using PublicSite.Domain.Interfaces.Repositories.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Actualities.Command.Delete
{
    public class DeleteActualityCommandHandler(IActualityRepositoryCommand _repository, IUnitOfWork _unitOfWork) : IRequestHandler<DeleteActualityCommand, DeleteActualityResponse>
    {
        public async Task<DeleteActualityResponse> Handle(DeleteActualityCommand request, CancellationToken cancellationToken)
        {
            var result = await _repository.SoftDeleteActualityAsync(request.Id);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new DeleteActualityResponse(result);
        }
    }
}
