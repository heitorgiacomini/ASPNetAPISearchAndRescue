using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace SearchAndRescue.Entities
{
    public class State : FullAuditedAggregateRoot<long>, IMultiTenant
    {
        [MaxLength(30)]
        [Required]
        public string Name { get; set; }
        public Guid? TenantId { get; set; }
    }
}
