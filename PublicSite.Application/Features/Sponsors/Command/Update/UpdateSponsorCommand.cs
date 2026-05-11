using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Sponsors.Command.Update
{
    public record UpdateSponsorCommand
    (
        Guid Id,
        string? Name,
        IFormFile? Ressource,
        string? SiteUrl
    ) : IRequest<UpdateSponsorResponse>;
}
