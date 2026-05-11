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
    public class FaqCatRepositoryCommand(DBContext _context, IFaqCatRepositoryQuery _query) : IFaqCatRepositoryCommand
    {
        private readonly DbSet<FaqCategory> _faqCategories = _context.FaqCategories;
        public async Task<FaqCategory> AddFaqCategoryAsync(FaqCategory actuality)
        {
            var entity = FaqCategory.Create(actuality.Name);
            await _faqCategories.AddAsync(entity);
            return entity;
        }

        public async Task<FaqCategory> SoftDeleteFaqCategoryAsync(Guid id)
        {
            var entity = await _query.GetByIdFaqCategoryAsync(id);
            entity.SoftDeleteFaqCategory();
            return entity;
        }

        public async Task<FaqCategory> UpdateFaqCategoryAsync(Guid id, string name)
        {
            var entity = await _query.GetByIdFaqCategoryAsync(id);
            entity.UpdateName(name);
            return entity;
        }
    }
}
