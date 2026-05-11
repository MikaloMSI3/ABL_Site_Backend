using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Heros.Command.Update
{
    public record UpdateHeroCommand
    (
        Guid Id,
        int? Order,
        IFormFile? Ressource
    ) : IRequest<UpdateHeroResponse>;
}
