using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Paltarumi.Acopio.Audit.RestClient.Base;
using Paltarumi.Acopio.Audit.RestClient.Extensions;
using Paltarumi.Acopio.Balanza.Entity;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Transactions;
using Paltarumi.Acopio.Balanza.Repository.Base;
using Paltarumi.Acopio.Balanza.Repository.Data;
using Paltarumi.Acopio.Balanza.Repository.Transactions;

namespace Paltarumi.Acopio.Balanza.Repository.Extensions
{
    public static class RepositoryServiceCollectionExtensions
    {
        public static IServiceCollection UseRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = Environment.GetEnvironmentVariable("CN_ACOPIO_BALANZA") ?? configuration.GetConnectionString("DefaultConnection");

            services.AddSqlServer<AcopioDbContext>(connectionString, b => b.MigrationsAssembly("Paltarumi.Acopio.Balanza.Apis"));

            services.AddScoped<DbContext, AcopioDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork<DbContext>>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            // Audit
            services.UseAuditServices(new ServiceOptions
            {
                BaseUrl = Environment.GetEnvironmentVariable("URL_SERVICE_AUDIT") ?? string.Empty
            }, config =>
            {
                config.AuditEntity<Concesion>(x => x.CodigoUnico, x => x.Nombre);//Audita solo las propiedades especificadas
                config.AuditEntity<Lote>();//Audita toda la entidad
                config.AuditEntity<LoteBalanza>();
                config.AuditEntity<LoteChancado>();
                config.AuditEntity<LoteCodigo>();
                config.AuditEntity<LoteMuestreo>();
                config.AuditEntity<Ticket>();
            });

            return services;
        }
    }
}
