using PublicSite.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Domain.Interfaces.Repositories.Command
{
    public interface IActualityCatRepositoryCommand
    {
        Task<ActualityCategory> AddActualityCategoryAsync(ActualityCategory actuality);
        Task<bool> SoftDeleteActualityCategoryAsync(Guid id);
    }
}
