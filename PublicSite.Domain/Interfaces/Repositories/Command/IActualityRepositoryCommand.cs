using PublicSite.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Domain.Interfaces.Repositories.Command
{
    public interface IActualityRepositoryCommand
    {
        Task<Actuality> AddActualityAsync(Actuality actuality);
        Task<Actuality> UpdateActualityAsync(Guid id, Actuality actuality);
        Task<Actuality> SoftDeleteActualityAsync(Guid id);
    }
}
