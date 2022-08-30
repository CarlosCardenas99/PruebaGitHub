namespace Paltarumi.Acopio.Balanza.Repository.Abstractions.Audit
{
    public interface IAuditService
    {
        Task AuditEntity<TEntity>(Operation operation, params TEntity[] entities);
    }
}
