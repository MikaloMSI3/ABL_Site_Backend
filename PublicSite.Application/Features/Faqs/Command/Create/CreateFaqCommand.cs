using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Faqs.Command.Create
{
    public record CreateFaqCommand
    (
        string Question,
        string Answer,
        Guid? FaqCategoryId
    ) : IRequest<CreateFaqResponse>;
}
