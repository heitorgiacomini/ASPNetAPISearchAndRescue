using System;
using System.Spatial;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace SearchAndRescue.Entities
{
    public class Operation : FullAuditedAggregateRoot<long>, IMultiTenant
    {
        public Guid? TenantId { get; set; }
        public string Name { get; set; }
        //HasConversion(new GeographyValueConverter()
        //[Column(TypeName = "geography")]
        public Geography PointOfInterest { get; set; }
        public decimal RadiusOfInterest { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public OperationStatus OperationStatus { get; set; }
    }
}
