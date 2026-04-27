using MediatR;
using PublicSite.Domain.Interfaces.Repositories;
using PublicSite.Domain.Interfaces.Repositories.Command;
using PublicSite.Domain.Interfaces.Repositories.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Faqs.Command.Update
{
    public class UpdateFaqCommandHandler(IFaqRepositoryCommand _repository, IFaqRepositoryQuery _query, IUnitOfWork _unitOfWork) : IRequestHandler<UpdateFaqCommand, UpdateFaqResponse>
    {
        public async Task<UpdateFaqResponse> Handle(UpdateFaqCommand request, CancellationToken cancellationToken)
        {
            var faq = await _query.GetByIdFaqAsync(request.Id);
            faq.Update(request.Question, request.Answer, request.FaqCategoryId);

            var newEntity = await _repository.UpdateFaqAsync(request.Id, faq);

            await _unitOfWork.SaveChangesAsync();

            return new UpdateFaqResponse
            (
                Id : newEntity.Id,
                CreatedAt : newEntity.CreatedAt,
                UpdatedAt : newEntity.UpdatedAt,
                Question : newEntity.Question,
                Answer : newEntity.Answer,
                FaqCategoryId : newEntity.FaqCategoryId
            );
        }
    }
}
