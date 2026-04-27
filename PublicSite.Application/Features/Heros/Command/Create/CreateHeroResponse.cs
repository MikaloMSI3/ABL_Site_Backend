using PublicSite.Domain.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Heros.Command.Create
{
    public record CreateHeroResponse
    (
        Guid Id,
        DateTime CreatedAt,
        Ressource Ressource,
        int? Order
    );
}
