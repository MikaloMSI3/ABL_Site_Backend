using MediatR;
using PublicSite.Application.Features.Albums.Command.Delete;
using PublicSite.Domain.Interfaces.Repositories;
using PublicSite.Domain.Interfaces.Repositories.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Timelines.Command.Delete
{
    public class DeleteTimelineCommandHandler(ITimelineRepositoryCommand _repository, IUnitOfWork _unitOfWork) : IRequestHandler<DeleteTimelineCommand, DeleteTimelineResponse>
    {
        public async Task<DeleteTimelineResponse> Handle(DeleteTimelineCommand request, CancellationToken cancellationToken)
        {
            var result = await _repository.SoftDeleteTimelineAsync(request.Id);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new DeleteTimelineResponse(result);
        }
    }
}
