using MediatR;
using PublicSite.Domain.Entities.Models;
using PublicSite.Domain.Interfaces.Repositories;
using PublicSite.Domain.Interfaces.Repositories.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Users.Command.Create
{
    public class CreateUserCommandHandler(IUserRepositoryCommand _repository, IUnitOfWork _unitOfWork) : IRequestHandler<CreateUserCommand, CreateUserResponse>
    {
        public async Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.AddUserAsync(User.Create(request.Email, request.Password));
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new CreateUserResponse
            (
                entity.Id,
                entity.CreatedAt,
                entity.Email,
                entity.Password
            );
        }
    }
}
