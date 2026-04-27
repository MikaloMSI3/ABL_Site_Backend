using MediatR;
using PublicSite.Application.Features.Albums.Command.Delete;
using PublicSite.Domain.Interfaces.Repositories;
using PublicSite.Domain.Interfaces.Repositories.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.NewsLetters.Command.Delete
{
    public class DeleteNewsLetterCommandHandler(INewsLetterRepositoryCommand _repository, IUnitOfWork _unitOfWork) : IRequestHandler<DeleteNewsLetterCommand, DeleteNewsLetterResponse>
    {
        public async Task<DeleteNewsLetterResponse> Handle(DeleteNewsLetterCommand request, CancellationToken cancellationToken)
        {
            var result = await _repository.SoftDeleteNewsLetterAsync(request.Id);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new DeleteNewsLetterResponse(result);
        }
    }
}
