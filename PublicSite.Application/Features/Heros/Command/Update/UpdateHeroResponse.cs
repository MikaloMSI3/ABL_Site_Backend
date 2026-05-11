using Microsoft.AspNetCore.Http;
using PublicSite.Domain.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Heros.Command.Update
{
    public record UpdateHeroResponse
    (
        Guid Id,
        DateTime? CreatedAt,
        DateTime? UpdatedAt,
        int? Order,
        Ressource? Ressource
    );
}
