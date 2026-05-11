using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PublicSite.Domain.Entities.Models;
using PublicSite.Domain.Interfaces.Repositories;
using PublicSite.Domain.Interfaces.Repositories.Command;
using PublicSite.Domain.Interfaces.Repositories.Query;
using PublicSite.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSite.Infrastructure.Common.Initialization
{
    public class AppInitializer(IServiceProvider _serviceProvider)
    {
        public async Task InitializeAsync()
        {
            using var scope = _serviceProvider.CreateScope();

            var dbContext = scope.ServiceProvider.GetRequiredService<DBContext>();
            var config = scope.ServiceProvider.GetRequiredService<IConfiguration>();
            var commandRepo = scope.ServiceProvider.GetRequiredService<IUserRepositoryCommand>();
            var queryRepo = scope.ServiceProvider.GetRequiredService<IUserRepositoryQuery>();
            var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

            await dbContext.Database.MigrateAsync();

            await SeedUserAsync(config, commandRepo, queryRepo, unitOfWork);

        }

        public async Task SeedUserAsync(IConfiguration _config, IUserRepositoryCommand _repository, IUserRepositoryQuery _queryRepo, IUnitOfWork _unitOfWork)
        {
            var email = _config["SuperAdmin:Email"];
            var password = _config["SuperAdmin:Password"];

            if (email == null || password == null)
                throw new Exception("SuperAdmin email or password not found");

            var user = await _queryRepo.GetByEmail(email);
            if (user == null)
            {
                await _repository.AddUserAsync(User.Create(email, password));
                await _unitOfWork.SaveChangesAsync();
            }

        }
    }
}
