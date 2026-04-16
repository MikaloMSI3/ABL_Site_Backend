using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.ActualityCategories.Command.Delete
{
    public record DeleteActualityCatCommand(Guid Id) : IRequest<DeleteActualityCatResponse>;
}
