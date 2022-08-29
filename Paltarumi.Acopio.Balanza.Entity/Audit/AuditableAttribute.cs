namespace Paltarumi.Acopio.Balanza.Entity.Audit
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Field, AllowMultiple = true, Inherited = true)]
    public class AuditableAttribute : Attribute
    {

    }
}
