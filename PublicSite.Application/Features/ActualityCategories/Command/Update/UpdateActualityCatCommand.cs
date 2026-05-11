using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.ActualityCategories.Command.Update
{
    public record UpdateActualityCatCommand(Guid Id, string Name) : IRequest<UpdateActualityCatResponse>;
}
