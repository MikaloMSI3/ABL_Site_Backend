using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.FaqCategories.Command.Create
{
    public record CreateFaqCatCommand(string Name) : IRequest<CreateFaqCatResponse>;
}
