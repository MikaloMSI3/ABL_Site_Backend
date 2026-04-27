using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Heros.Query.GetAll
{
    public record GetAllHeroQuery(int? Limit = null) : IRequest<GetAllHeroResponse>;
}
