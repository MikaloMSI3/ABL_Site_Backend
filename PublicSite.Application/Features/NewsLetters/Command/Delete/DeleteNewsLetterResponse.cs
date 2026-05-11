using PublicSite.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Application.Features.NewsLetters.Command.Delete
{
    public record DeleteNewsLetterResponse(NewsLetter NewsLetter);
}
