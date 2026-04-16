using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Dtos.Actualities
{
    public record ActualityCategoryDto
        (
            Guid Id,
            DateTime CreatedAt,
            string Name,
            IEnumerable<ActualityWithCatDto>? Actualities
        );

}
