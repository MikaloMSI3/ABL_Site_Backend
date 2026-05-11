using PublicSite.Application.Dtos.Actualities;
using PublicSite.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Users.Query.GetAll
{
    public record GetAllUserResponse
    {
        public IEnumerable<User>? Results { get; set; }
        public long TotalCount { get; set; }
    }
}
