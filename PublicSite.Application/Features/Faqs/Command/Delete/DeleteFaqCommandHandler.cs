using MediatR;
using PublicSite.Application.Features.Actualities.Command.Delete;
using PublicSite.Domain.Interfaces.Repositories;
using PublicSite.Domain.Interfaces.Repositories.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Faqs.Command.Delete
{
    public class DeleteFaqCommandHandler(IFaqRepositoryCommand _repository, IUnitOfWork _unitOfWork) : IRequestHandler<DeleteFaqCommand, DeleteFaqResponse>
    {
        public async Task<DeleteFaqResponse> Handle(DeleteFaqCommand request, CancellationToken cancellationToken)
        {
            var result = await _repository.SoftDeleteFaqAsync(request.Id);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new DeleteFaqResponse(result);
        }
    }
}
