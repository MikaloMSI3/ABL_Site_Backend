using PublicSite.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Domain.Interfaces.Repositories.Command
{
    public interface IHeroRepositoryCommand
    {
        Task<Image> AddHeroAsync(Image image);
        Task<Image> UpdateHeroAsync(Guid id, Image image);
        Task<Image> SoftDeleteHeroAsync(Guid id);
    }
}
