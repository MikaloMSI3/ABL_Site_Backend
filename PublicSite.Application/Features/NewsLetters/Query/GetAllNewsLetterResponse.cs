using PublicSite.Application.Dtos.Galleries;
using PublicSite.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.NewsLetters.Query
{
    public record GetAllNewsLetterResponse
    {
        public IEnumerable<NewsLetter>? Results { get; set; }
        public long TotalCount { get; set; }
    }
}
