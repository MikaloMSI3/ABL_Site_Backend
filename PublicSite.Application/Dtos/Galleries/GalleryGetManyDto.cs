using PublicSite.Domain.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Dtos.Galleries
{
    public record GalleryGetManyDto
    (
        Guid Id,
        DateTime CreatedAt,
        Ressource? Ressource
    );
}
