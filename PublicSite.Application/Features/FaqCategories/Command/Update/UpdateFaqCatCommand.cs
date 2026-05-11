using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.FaqCategories.Command.Update
{
    public record UpdateFaqCatCommand(Guid Id, string Name) : IRequest<UpdateFaqCatResponse>;
}
