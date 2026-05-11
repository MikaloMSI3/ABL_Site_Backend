using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Heros.Command.Update
{
    public record UpdateHeroRequest(int? Order, IFormFile? Ressource);
}
