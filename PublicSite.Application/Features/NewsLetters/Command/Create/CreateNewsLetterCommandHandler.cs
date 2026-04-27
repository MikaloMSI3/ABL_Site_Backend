using MediatR;
using PublicSite.Application.Features.Albums.Command.Create;
using PublicSite.Domain.Entities.Models;
using PublicSite.Domain.Interfaces.Repositories;
using PublicSite.Domain.Interfaces.Repositories.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.NewsLetters.Command.Create
{
    public class CreateNewsLetterCommandHandler(INewsLetterRepositoryCommand _repository, IUnitOfWork _unitOfWork) : IRequestHandler<CreateNewsLetterCommand, CreateNewsLetterResponse>
    {
        public async Task<CreateNewsLetterResponse> Handle(CreateNewsLetterCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.AddNewsLetterAsync(NewsLetter.Create(request.Email));
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new CreateNewsLetterResponse
            (
                entity.Id,
                entity.CreatedAt,
                entity.Email
            );
        }
    }
}
