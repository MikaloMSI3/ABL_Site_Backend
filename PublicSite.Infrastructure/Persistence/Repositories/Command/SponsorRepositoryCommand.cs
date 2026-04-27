using Microsoft.EntityFrameworkCore;
using PublicSite.Domain.Entities.Models;
using PublicSite.Domain.Interfaces.Repositories.Command;
using PublicSite.Domain.Interfaces.Repositories.Query;
using PublicSite.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Net.Mime.MediaTypeNames;

namespace PublicSite.Infrastructure.Persistence.Repositories.Command
{
    public class SponsorRepositoryCommand(DBContext _context, ISponsorRepositoryQuery _query) : ISponsorRepositoryCommand
    {
        private readonly DbSet<Sponsor> _sponsors = _context.Sponsors;
        public async Task<Sponsor> AddSponsorAsync(Sponsor sponsor)
        {
            var entity = Sponsor.Create(sponsor.Name, sponsor.Logo);
            await _sponsors.AddAsync(entity);
            return entity;
        }

        public async Task<bool> SoftDeleteSponsorAsync(Guid id)
        {
            var entity = _query.GetByIdSponsorAsync(id);
            entity.Result.SoftDeleteSponsor();
            return entity != null;
        }

        public Task<Sponsor> UpdateSponsorAsync(Guid id, Sponsor sponsor)
        {
            throw new NotImplementedException();
        }
    }
}
