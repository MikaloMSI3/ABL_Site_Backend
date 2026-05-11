using PublicSite.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Domain.Interfaces.Repositories.Command
{
    public interface INewsLetterRepositoryCommand
    {
        Task<NewsLetter> AddNewsLetterAsync(NewsLetter actuality);
        Task<NewsLetter> SoftDeleteNewsLetterAsync(Guid id);
    }
}
