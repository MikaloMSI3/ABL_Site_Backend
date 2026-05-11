using Microsoft.EntityFrameworkCore;
using PublicSite.Domain.Entities.Models;
using PublicSite.Domain.Interfaces.Repositories.Command;
using PublicSite.Domain.Interfaces.Repositories.Query;
using PublicSite.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Infrastructure.Persistence.Repositories.Command
{
    public class ActualityRepositoryCommand(DBContext _context, IActualityRepositoryQuery _query) : IActualityRepositoryCommand
    {
        private readonly DbSet<Actuality> _news = _context.News;
        public async Task<Actuality> AddActualityAsync(Actuality actuality)
        {
            var entity = Actuality.Create(actuality.Date, actuality.Title,actuality.Description, actuality.ActualityCategoryId,actuality.Ressource);
            await _news.AddAsync(entity);
            return entity;
        }

        public async Task<Actuality> SoftDeleteActualityAsync(Guid id)
        {
            var entity = await _query.GetByIdActualityAsync(id);
            entity.SoftDelete();
            return entity;
        }

        public async Task<Actuality> UpdateActualityAsync(Guid id, Actuality actuality)
        {
            var entity = await _query.GetByIdActualityAsync(id);
            entity.Update(actuality.Date, actuality.Title, actuality.Description, actuality.ActualityCategoryId, actuality.Ressource);
            return entity;
        }
    }
}
