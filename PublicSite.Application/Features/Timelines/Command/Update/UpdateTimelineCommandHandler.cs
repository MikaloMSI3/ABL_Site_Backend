using MediatR;
using PublicSite.Domain.Entities.Models;
using PublicSite.Domain.Interfaces.Repositories;
using PublicSite.Domain.Interfaces.Repositories.Command;
using PublicSite.Domain.Interfaces.Repositories.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Timelines.Command.Update
{
    public class UpdateTimelineCommandHandler(ITimelineRepositoryQuery _query, IUnitOfWork _unitOfWork) : IRequestHandler<UpdateTimelineCommand, UpdateTimelineResponse>
    {
        public async Task<UpdateTimelineResponse> Handle(UpdateTimelineCommand request, CancellationToken cancellationToken)
        {
            var entity = await _query.GetByIdTimelineAsync(request.Id);
            entity.Update(request.Title, request.Description, request.Year);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new UpdateTimelineResponse
            (
                entity.Id,
                entity.CreatedAt,
                entity.UpdatedAt,
                entity.Title,
                entity.Description,
                entity.Year
            );
        }
    }
}
