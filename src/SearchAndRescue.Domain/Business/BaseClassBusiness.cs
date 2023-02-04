using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace SearchAndRescue.Business
{
    public class BaseClassBusiness : FullAuditedAggregateRoot<long>, IMultiTenant
    {
        public Guid? TenantId { get; set; }
    }
}
