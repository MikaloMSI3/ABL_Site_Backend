using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Heros.Command.Create
{
    public record CreateHeroCommand(IFormFile Ressource, int? Order = null) : IRequest<CreateHeroResponse>;
}
