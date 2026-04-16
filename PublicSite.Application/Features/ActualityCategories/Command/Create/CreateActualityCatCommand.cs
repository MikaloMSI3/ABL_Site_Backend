using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.ActualityCategories.Command.Create
{
    public record CreateActualityCatCommand(string Name) : IRequest<CreateActualityCatResponse>;

}
