using PublicSite.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Domain.Interfaces.Repositories.Command
{
    public interface IActualityCatRepositoryCommand
    {
        Task<ActualityCategory> AddActualityCategoryAsync(ActualityCategory actuality);
        Task<ActualityCategory> SoftDeleteActualityCategoryAsync(Guid id);
        Task<ActualityCategory> UpdateActualityCategoryAsync(Guid id, string name);
    }
}
