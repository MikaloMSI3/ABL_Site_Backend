using MediatR;
using PublicSite.Domain.Entities.Models;
using PublicSite.Domain.Interfaces.Repositories;
using PublicSite.Domain.Interfaces.Repositories.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Users.Command.Update
{
    public class UpdateUserCommandHandler(IUserRepositoryCommand _repository, IUnitOfWork _unitOfWork) : IRequestHandler<UpdateUserCommand, UpdateUserResponse>
    {
        public async Task<UpdateUserResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.UpdateUserAsync(request.Id, User.Create(request.Email, request.Password));
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new UpdateUserResponse
            (
                entity.Id,
                entity.CreatedAt,
                entity.UpdatedAt,
                entity.Email,
                entity.Password
            );
        }
    }
}
