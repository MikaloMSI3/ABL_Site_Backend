using PublicSite.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text; 

namespace PublicSite.Domain.Interfaces.Repositories.Query
{
    public interface ISponsorRepositoryQuery
    {
        Task<Sponsor> GetByIdSponsorAsync(Guid id);
        Task<(IEnumerable<Sponsor> Result, long TotalCount)> GetAllSponsorAsync(int? limit = null);
    }
}
