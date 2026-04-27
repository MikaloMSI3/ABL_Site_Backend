using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Faqs.Command.Update
{
    public record UpdateFaqCommand
    (
        Guid Id,
        string? Question,
        string? Answer,
        Guid? FaqCategoryId
    ) : IRequest<UpdateFaqResponse>;
}
