using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;
using Paltarumi.Acopio.Repository.Base;
using Paltarumi.Acopio.Repository.Data;
using Paltarumi.Acopio.Repository.Transactions;

namespace Paltarumi.Acopio.Repository.Extensions
{
    public static class RepositoryServiceCollectionExtensions
    {
        public static IServiceCollection UseRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = Environment.GetEnvironmentVariable("CONNECTIONSTRING"); //configuration.GetConnectionString("DefaultConnection");

            services.AddSqlServer<AcopioDbContext>(connectionString);

            services.AddScoped<DbContext, AcopioDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork<DbContext>>();
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

            return services;
        }
    }
}
