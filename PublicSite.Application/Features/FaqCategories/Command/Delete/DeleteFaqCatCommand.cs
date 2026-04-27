using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.FaqCategories.Command.Delete
{
    public record DeleteFaqCatCommand(Guid Id) : IRequest<DeleteFaqCatResponse>;
}
