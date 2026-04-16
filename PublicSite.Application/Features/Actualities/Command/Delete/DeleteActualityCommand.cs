using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Actualities.Command.Delete
{
    public record DeleteActualityCommand(Guid Id) : IRequest<DeleteActualityResponse>;

}
