using PublicSite.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Domain.Interfaces.Repositories.Command
{
    public interface ISponsorRepositoryCommand
    {
        Task<Sponsor> AddSponsorAsync(Sponsor sponsor);
        Task<Sponsor> UpdateSponsorAsync(Guid id, Sponsor sponsor);
        Task<Sponsor> SoftDeleteSponsorAsync(Guid id);
    }
}
