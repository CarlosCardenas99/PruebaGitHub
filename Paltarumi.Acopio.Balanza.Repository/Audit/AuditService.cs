using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Paltarumi.Acopio.Balanza.Entity.Audit;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Audit;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Security;
using Paltarumi.Acopio.Balanza.Repository.Data;
using Paltarumi.Acopio.Balanza.Repository.Extensions;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Paltarumi.Acopio.Balanza.Repository.Audit
{
    public class AuditService : IAuditService
    {
        private readonly IUserIdentity _userIdentity;
        private readonly AuditDbContext _auditDbContext;

        private readonly string[] keyProperties = {
            "id",
            "identifier",
            "code",
            "codigo"
        };

        private readonly string[] skippedProperties = {
            "UserNameCreate",
            "CreateDate",
            "UserNameUpdate",
            "UpdateDate"
        };

        public AuditService(IUserIdentity userIdentity, AuditDbContext auditDbContext)
        {
            _userIdentity = userIdentity;
            _auditDbContext = auditDbContext;
        }

        public async Task AuditEntity<TEntity>(Operation operation, params TEntity[] entities)
        {
            var auditHeaders = new List<AuditHeader>();

            foreach (var entity in entities)
            {
                var changes = AuditEntity(operation, new List<Type>(), entity, typeof(TEntity));
                auditHeaders.AddRange(changes);
            }

            if (auditHeaders.Any())
            {
                auditHeaders = auditHeaders.OrderBy(x => x.Entity).ThenBy(x => x.Identifier).ToList();
                await _auditDbContext.Set<AuditHeader>().AddRangeAsync(auditHeaders.ToArray());
                await _auditDbContext.SaveChangesAsync();
            }
        }

        private IEnumerable<AuditHeader> AuditEntity<TEntity>(Operation operation, ICollection<Type> baseTypes, TEntity entity, Type entityType)
        {
            var auditHeaders = new List<AuditHeader>();

            if (entity == null) return auditHeaders;
            if (entityType.IsSimple()) return auditHeaders;

            auditHeaders.AddRange(AuditEntity(operation, entity, entityType));

            var properties = entityType.GetProperties().Where(x =>
                !keyProperties.Contains(x.Name) &&
                !skippedProperties.Contains(x.Name) &&
                !x.PropertyType.IsSimple()
            );

            foreach (var property in properties)
            {
                var propertyValue = property.GetValue(entity);
                if (propertyValue == null) continue;

                if (baseTypes.Contains(property.PropertyType)) continue;
                if (!baseTypes.Contains(entityType)) baseTypes.Add(entityType);

                if (!property.PropertyType.IsCollection())
                    auditHeaders.AddRange(AuditEntity(operation, baseTypes, propertyValue, propertyValue.GetType()));
                else
                {
                    if (propertyValue is IEnumerable entities)
                    {
                        var entitiesEnumerator = entities.GetEnumerator();
                        while (entitiesEnumerator.MoveNext())
                            auditHeaders.AddRange(AuditEntity(operation, baseTypes, entitiesEnumerator.Current, entitiesEnumerator.Current.GetType()));
                    }

                    continue;
                }
            }

            return auditHeaders;
        }

        private IEnumerable<AuditHeader> AuditEntity<TEntity>(Operation operation, TEntity entity, Type entityType)
        {
            var auditHeaders = new List<AuditHeader>();

            var auditAttribute = entityType.CustomAttributes.FirstOrDefault(x =>
                x.AttributeType == typeof(AuditableAttribute)
            );

            var propertiesToAudit = new List<PropertyInfo>();
            var properties = entityType.GetProperties().Where(x =>
                !keyProperties.Contains(x.Name) &&
                !skippedProperties.Contains(x.Name) &&
                x.PropertyType.IsSimple()
            );

            if (auditAttribute != null)
                propertiesToAudit.AddRange(properties);
            else
                propertiesToAudit.AddRange(GetPropertiesToAudit(entityType));

            if (!propertiesToAudit.Any())
                return auditHeaders;

            var auditDetails = new List<AuditDetail>();

            foreach (var propertyToAudit in propertiesToAudit)
            {
                auditDetails.Add(new AuditDetail
                {
                    Field = propertyToAudit.Name,
                    Value = propertyToAudit.GetValue(entity)?.ToString()!
                });
            }

            var auditHeader = new AuditHeader
            {
                Operation = operation,
                Entity = entityType.Name,
                Identifier = GetIdentifier(entity, entityType),
                UserName = _userIdentity.GetCurrentUser(),
                Date = DateTimeOffset.Now,
                AuditDetails = auditDetails
            };

            auditHeaders.Add(auditHeader);

            return auditHeaders;
        }

        private IEnumerable<PropertyInfo> GetPropertiesToAudit(Type type)
        {
            var properties = type.GetProperties().Where(x =>
                !keyProperties.Contains(x.Name) &&
                !skippedProperties.Contains(x.Name) &&
                x.CustomAttributes.Any(x => x.AttributeType == typeof(AuditableAttribute))
            );

            return properties;
        }

        private string GetIdentifier<TEntity>(TEntity entity, Type entityType)
        {
            var properties = entityType.GetProperties().Where(x => !skippedProperties.Contains(x.Name));

            var keyProperty = properties.FirstOrDefault(p => p.CustomAttributes.Any(x => x.AttributeType == typeof(KeyAttribute)));
            if (keyProperty != null)
                return keyProperty.GetValue(entity)?.ToString()!;

            keyProperty = properties.FirstOrDefault(p =>
                keyProperties.Contains(p.Name.ToLower()) ||
                p.Name.ToLower() == $"Id{entityType.Name}".ToLower() ||
                p.Name.ToLower() == $"{entityType.Name}Id".ToLower() &&
                p.PropertyType.IsSimple()
            );

            if (keyProperty != null)
                return keyProperty.GetValue(entity)?.ToString()!;

            return string.Empty;
        }
    }
}
