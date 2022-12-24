using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace SearchAndRescue.Business
{
    public class Race : FullAuditedAggregateRoot<long>, IMultiTenant
    {

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public Guid? TenantId { get; set; }

    }
}
