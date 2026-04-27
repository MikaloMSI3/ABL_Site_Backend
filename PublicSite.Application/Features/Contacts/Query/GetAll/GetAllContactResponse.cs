using PublicSite.Application.Dtos.Galleries;
using PublicSite.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.Contacts.Query.GetAll
{
    public record GetAllContactResponse
    {
        public IEnumerable<Contact>? Results { get; set; }
        public long TotalCount { get; set; }
    }
}
