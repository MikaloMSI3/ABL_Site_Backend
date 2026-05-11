using PublicSite.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Domain.Interfaces.Repositories.Command
{
    public interface IFaqRepositoryCommand
    {
        Task<Faq> AddFaqAsync(Faq actuality);
        Task<Faq> UpdateFaqAsync(Guid id, Faq actuality);
        Task<Faq> SoftDeleteFaqAsync(Guid id);
    }
}
