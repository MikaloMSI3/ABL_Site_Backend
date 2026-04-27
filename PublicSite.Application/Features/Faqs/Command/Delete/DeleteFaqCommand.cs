using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Faqs.Command.Delete
{
    public record DeleteFaqCommand(Guid Id) : IRequest<DeleteFaqResponse>;
}
