using PublicSite.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Domain.Interfaces.Repositories.Command
{
    public interface IFaqCatRepositoryCommand
    {
        Task<FaqCategory> AddFaqCategoryAsync(FaqCategory actuality);
        Task<bool> SoftDeleteFaqCategoryAsync(Guid id);
    }
}
