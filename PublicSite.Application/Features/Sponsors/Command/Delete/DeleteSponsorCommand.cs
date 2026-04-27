using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Sponsors.Command.Delete
{
    public record DeleteSponsorCommand(Guid Id) : IRequest<DeleteSponsorResponse>;
}
