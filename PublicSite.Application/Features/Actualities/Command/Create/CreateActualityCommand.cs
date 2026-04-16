using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Actualities.Command.Create
{
    public record CreateActualityCommand 
    (
        DateTime? Date,
        string Title,
        string? Description,
        IFormFile Ressource,
        Guid? ActualityCategoryId
    ) : IRequest<CreateActualityResponse>;
       
}
