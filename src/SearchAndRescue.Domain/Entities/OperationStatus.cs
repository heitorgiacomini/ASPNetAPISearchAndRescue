using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace SearchAndRescue.Entities
{
    public class OperationStatus : FullAuditedAggregateRoot<long>, IMultiTenant
    {
        public Guid? TenantId { get; set; }
        public string Name { get; set; }
    }
}
