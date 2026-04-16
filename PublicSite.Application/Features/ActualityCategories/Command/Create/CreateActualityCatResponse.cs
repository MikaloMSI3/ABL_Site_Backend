using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.ActualityCategories.Command.Create
{
    public record CreateActualityCatResponse
    (
        Guid Id,
        DateTime CreatedAt,
        string Name
    );

}
