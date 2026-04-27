using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Actualities.Command.Update
{
    public record UpdateActualityRequest
    (
        DateTime? Date,
        string Title,
        string? Description,
        IFormFile Ressource,
        Guid? ActualityCategoryId
    );
}
