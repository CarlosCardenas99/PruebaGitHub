using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Audit;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Transactions;
using Paltarumi.Acopio.Balanza.Repository.Audit;
using Paltarumi.Acopio.Balanza.Repository.Base;
using Paltarumi.Acopio.Balanza.Repository.Data;
using Paltarumi.Acopio.Balanza.Repository.Transactions;

namespace Paltarumi.Acopio.Balanza.Repository.Extensions
{
    public static class RepositoryServiceCollectionExtensions
    {
        public static IServiceCollection UseRepositories(this IServiceCollection services, IConfiguration configuration, string assembly = null)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrEmpty(assembly))
            {
                services.AddSqlServer<AuditDbContext>(connectionString);
                services.AddSqlServer<AcopioDbContext>(connectionString);
            }
            else
            {
                services.AddSqlServer<AuditDbContext>(connectionString, b => b.MigrationsAssembly(assembly));
                services.AddSqlServer<AcopioDbContext>(connectionString, b => b.MigrationsAssembly(assembly));
            }

            services.AddScoped<AuditDbContext>();
            services.AddScoped<IAuditService, AuditService>();

            services.AddScoped<DbContext, AcopioDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork<DbContext>>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            return services;
        }
    }
}
