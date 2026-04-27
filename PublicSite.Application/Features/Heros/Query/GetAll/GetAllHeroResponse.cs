using PublicSite.Application.Dtos.Galleries;
using PublicSite.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Heros.Query.GetAll
{
    public record GetAllHeroResponse
    {
        public IEnumerable<Image>? Results { get; set; }
        public long TotalCount { get; set; }
    }
}
