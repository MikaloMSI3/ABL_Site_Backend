using MediatR;
using PublicSite.Application.Features.FaqCategories.Command.Delete;
using PublicSite.Domain.Interfaces.Repositories;
using PublicSite.Domain.Interfaces.Repositories.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.FaqCategories.Command.Delete
{
    public class DeleteFaqCatCommandHandler(IFaqCatRepositoryCommand _repository, IUnitOfWork _unitOfWork) : IRequestHandler<DeleteFaqCatCommand, DeleteFaqCatResponse>
    {
        public async Task<DeleteFaqCatResponse> Handle(DeleteFaqCatCommand request, CancellationToken cancellationToken)
        {
            var result = await _repository.SoftDeleteFaqCategoryAsync(request.Id);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new DeleteFaqCatResponse(result);
        }
    }
}
 