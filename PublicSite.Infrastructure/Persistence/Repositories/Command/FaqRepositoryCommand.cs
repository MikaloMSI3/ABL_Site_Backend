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

        public async Task<Faq> SoftDeleteFaqAsync(Guid id)
        {
            var entity = await _query.GetByIdFaqAsync(id);
            entity.SoftDeleteFaq();
            return entity;
        }

        public async Task<Faq> UpdateFaqAsync(Guid id, Faq faq)
        {
            var entity = await _query.GetByIdFaqAsync(id);
            entity.Update(faq.Question, faq.Answer, faq.FaqCategoryId);
            return entity;
        }
    }
}
