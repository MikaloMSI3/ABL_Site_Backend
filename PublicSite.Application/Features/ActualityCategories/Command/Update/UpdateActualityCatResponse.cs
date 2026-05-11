using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.ActualityCategories.Command.Update
{
    public record UpdateActualityCatResponse
    (
        Guid Id,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        string Name
    );
}
