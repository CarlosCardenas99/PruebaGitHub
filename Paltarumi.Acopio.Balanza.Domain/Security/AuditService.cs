using Paltarumi.Acopio.Balanza.Repository.Abstractions.Audit;

namespace Paltarumi.Acopio.Balanza.Domain.Security
{
    public class AuditService : IAuditService
    {
        public Task AuditEntity<TEntity>(Operation operation, params TEntity[] entities)
        {
            throw new NotImplementedException();
        }
    }
}
