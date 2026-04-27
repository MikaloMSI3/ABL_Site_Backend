using MediatR;
using PublicSite.Application.Features.Heros.Query.GetAll;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Sponsors.Query.GetAll
{
    public record GetAllSponsorQuery(int? Limit = null) : IRequest<GetAllSponsorResponse>;
}
