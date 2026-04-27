using MediatR;
using PublicSite.Application.Features.Galleries.Command.Delete;
using PublicSite.Domain.Interfaces.Repositories;
using PublicSite.Domain.Interfaces.Repositories.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Heros.Command.Delete
{
    public class DeleteHeroCommandHandler(IHeroRepositoryCommand _repository, IUnitOfWork _unitOfWork) : IRequestHandler<DeleteHeroCommand, DeleteHeroResponse>
    {
        public async Task<DeleteHeroResponse> Handle(DeleteHeroCommand request, CancellationToken cancellationToken)
        {
            var result = await _repository.SoftDeleteHeroAsync(request.Id);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new DeleteHeroResponse(result);
        }
    }
}
