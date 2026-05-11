using MediatR;
using PublicSite.Domain.Interfaces.Repositories;
using PublicSite.Domain.Interfaces.Repositories.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Users.Command.Delete
{
    public class DeleteUserCommandHandler(IUserRepositoryCommand _repository, IUnitOfWork _unitOfWork) : IRequestHandler<DeleteUserCommand, DeleteUserResponse>
    {
        public async Task<DeleteUserResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.SoftDeleteUserAsync(request.Id);
            await _unitOfWork.SaveChangesAsync();

            return new DeleteUserResponse(entity);
        }
    }
}
