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
    public class ActualityCatRepositoryCommand(DBContext _context, IActualityCatRepositoryQuery _query) : IActualityCatRepositoryCommand
    {
        private readonly DbSet<ActualityCategory> _actualityCategories = _context.ActualityCategories;
        public async Task<ActualityCategory> AddActualityCategoryAsync(ActualityCategory actuality)
        {
            var entity = ActualityCategory.Create(actuality.Name);
            await _actualityCategories.AddAsync(entity);
            return entity;
        }

        public async Task<ActualityCategory> SoftDeleteActualityCategoryAsync(Guid id)
        {
            var entity = await _query.GetByIdActualityCategoryAsync(id);
            entity.SoftDelete();
            return entity;
        }

        public async Task<ActualityCategory> UpdateActualityCategoryAsync(Guid id, string name)
        {
            var entity = await _query.GetByIdActualityCategoryAsync(id);
            entity.UpdateName(name);
            return entity;
        }
    }
}
