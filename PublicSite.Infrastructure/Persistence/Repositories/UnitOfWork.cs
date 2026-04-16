using Microsoft.EntityFrameworkCore;
using PublicSite.Domain.Interfaces.Repositories;
using PublicSite.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Infrastructure.Persistence.Repositories
{
    public class UnitOfWork(DBContext _context) : IUnitOfWork
    {
        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync(cancellationToken); 
        }
    }
}
