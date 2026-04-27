using Microsoft.EntityFrameworkCore;
using PublicSite.Domain.Entities.Models;
using PublicSite.Domain.Interfaces.Repositories.Command;
using PublicSite.Domain.Interfaces.Repositories.Query;
using PublicSite.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace PublicSite.Infrastructure.Persistence.Repositories.Command
{
    public class NewsLetterRepositoryCommand(DBContext _context, INewsLetterRepositoryQuery _query) : INewsLetterRepositoryCommand
    {
        private readonly DbSet<NewsLetter> _newsLetters = _context.NewsLetters;
        public async Task<NewsLetter> AddNewsLetterAsync(NewsLetter newsLetter)
        {
            var entity = NewsLetter.Create(newsLetter.Email);
            await _newsLetters.AddAsync(entity);
            return entity;
        }

        public async Task<bool> SoftDeleteNewsLetterAsync(Guid id)
        {
            var entity = _query.GetByIdNewsLetterAsync(id);
            entity.Result.SoftDelete();
            return entity != null;
        }
    }
}
