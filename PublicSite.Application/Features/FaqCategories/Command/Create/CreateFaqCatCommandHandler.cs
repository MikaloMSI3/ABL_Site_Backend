using MediatR;
using PublicSite.Application.Features.FaqCategories.Command.Create;
using PublicSite.Domain.Entities.Models;
using PublicSite.Domain.Interfaces.Repositories;
using PublicSite.Domain.Interfaces.Repositories.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.FaqCategories.Command.Create
{
    public class CreateFaqCatCommandHandler(IFaqCatRepositoryCommand _repository, IUnitOfWork _unitOfWork) : IRequestHandler<CreateFaqCatCommand, CreateFaqCatResponse>
    {
        public async Task<CreateFaqCatResponse> Handle(CreateFaqCatCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.AddFaqCategoryAsync(FaqCategory.Create(request.Name));
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new CreateFaqCatResponse
                (
                    entity.Id,
                    entity.CreatedAt,
                    entity.Name
                );
        }
    }
}
