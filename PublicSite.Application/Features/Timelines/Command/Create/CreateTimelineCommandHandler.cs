using MediatR;
using PublicSite.Application.Features.Albums.Command.Create;
using PublicSite.Domain.Entities.Models;
using PublicSite.Domain.Interfaces.Repositories;
using PublicSite.Domain.Interfaces.Repositories.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Timelines.Command.Create
{
    public class CreateTimelineCommandHandler(ITimelineRepositoryCommand _repository, IUnitOfWork _unitOfWork) : IRequestHandler<CreateTimelineCommand, CreateTimelineResponse>
    {
        public async Task<CreateTimelineResponse> Handle(CreateTimelineCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.AddTimelineAsync(TimelineItem.Create(request.Title, request.Description, request.year));
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new CreateTimelineResponse
            (
                entity.Id,
                entity.CreatedAt,
                entity.Title,
                entity.Description ?? "",
                entity.Year
            );
        }
    }
}
