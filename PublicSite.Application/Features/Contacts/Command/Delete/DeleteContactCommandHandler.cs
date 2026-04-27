using MediatR;
using PublicSite.Application.Features.Albums.Command.Delete;
using PublicSite.Domain.Interfaces.Repositories;
using PublicSite.Domain.Interfaces.Repositories.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Contacts.Command.Delete
{
    public class DeleteContactCommandHandler(IContactRepositoryCommand _repository, IUnitOfWork _unitOfWork) : IRequestHandler<DeleteContactCommand, DeleteContactResponse>
    {
        public async Task<DeleteContactResponse> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            var result = await _repository.SoftDeleteContactAsync(request.Id);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new DeleteContactResponse(result);
        }
    }
}
