using MediatR;
using PublicSite.Domain.Entities.Models;
using PublicSite.Domain.Interfaces.Repositories;
using PublicSite.Domain.Interfaces.Repositories.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Faqs.Command.Create
{
    public class CreateFaqCommandHandler(IFaqRepositoryCommand _repository, IUnitOfWork _unitOfWork) : IRequestHandler<CreateFaqCommand, CreateFaqResponse>
    {
        public async Task<CreateFaqResponse> Handle(CreateFaqCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.AddFaqAsync(Faq.Create(request.Question, request.Answer, request.FaqCategoryId));

            await _unitOfWork.SaveChangesAsync();

            return new CreateFaqResponse
            (
                Id : entity.Id,
                CreatedAt : entity.CreatedAt,
                Question : entity.Question,
                Answer : entity.Answer,
                FaqCategoryId : entity.FaqCategoryId
            );
        }
    }
}
