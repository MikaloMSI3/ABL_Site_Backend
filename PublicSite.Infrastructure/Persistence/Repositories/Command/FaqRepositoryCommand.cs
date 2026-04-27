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
    public class FaqRepositoryCommand(DBContext _context, IFaqRepositoryQuery _query) : IFaqRepositoryCommand
    {
        private readonly DbSet<Faq> _faqs = _context.Faqs;
        public async Task<Faq> AddFaqAsync(Faq faq)
        {
            var entity = Faq.Create(faq.Question, faq.Answer, faq.FaqCategoryId);
            await _faqs.AddAsync(entity);
            return entity;
        }

        public async Task<bool> SoftDeleteFaqAsync(Guid id)
        {
            var entity = _query.GetByIdFaqAsync(id);
            entity.Result.SoftDeleteFaq();
            return entity != null;
        }

        public Task<Faq> UpdateFaqAsync(Guid id, Faq faq)
        {
            var entity = _query.GetByIdFaqAsync(id);
            entity.Result.Update(faq.Question, faq.Answer, faq.FaqCategoryId);
            return entity;
        }
    }
}
