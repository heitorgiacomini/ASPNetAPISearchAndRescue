using System;
using System.Spatial;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Identity;
using Volo.Abp.MultiTenancy;

namespace SearchAndRescue.Business
{
    public class Search : FullAuditedAggregateRoot<long>, IMultiTenant
    {
        public Guid? TenantId { get; set; }

        //HasConversion(new GeographyValueConverter()
        //[Column(TypeName = "geography")]
        public Geography GeographyLineString { get; set; }
        public IdentityUser IdentityUser { get; set; }
        public int Precisao { get; set; }
    }
}
