using MediatR;
using PublicSite.Application.Features.Heros.Command.Delete;
using PublicSite.Domain.Interfaces.Repositories;
using PublicSite.Domain.Interfaces.Repositories.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Sponsors.Command.Delete
{
    public class DeleteSponsorCommandHandler(ISponsorRepositoryCommand _repository, IUnitOfWork _unitOfWork) : IRequestHandler<DeleteSponsorCommand, DeleteSponsorResponse>
    {
        public async Task<DeleteSponsorResponse> Handle(DeleteSponsorCommand request, CancellationToken cancellationToken)
        {
            var result = await _repository.SoftDeleteSponsorAsync(request.Id);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new DeleteSponsorResponse(result);
        }
    }
}
