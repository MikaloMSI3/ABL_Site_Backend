using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Sponsors.Command.Create
{
    public record CreateSponsorCommand
    (
        string Name,
        IFormFile Logo,
        string? SiteUrl
    ) : IRequest<CreateSponsorResponse>;
}
