using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Heros.Command.Delete
{
    public record DeleteHeroCommand(Guid Id) : IRequest<DeleteHeroResponse>;
}
