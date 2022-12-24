using NetTopologySuite.Geometries;
using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace SearchAndRescue.Business
{
    public class Operation : FullAuditedAggregateRoot<long>, IMultiTenant
    {
        public Guid? TenantId { get; set; }
        public string Name { get; set; }
        //HasConversion(new GeographyValueConverter()
        //[Column(TypeName = "geography")]
        public Point GeometryPoint { get; set; }
        //public CoordinateZ CoordinateZ { get; set; }
        public decimal RadiusOfInterest { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public OperationStatus OperationStatus { get; set; }

        public Operation()
        {

        }

    }
}
//Npgsql.PostgresTypes
//public NpgsqlPoint NpgsqlPoint { get; set; }
//public Geography Geography { get; set; }
//public DbGeography DbGeography { get; set; }
//public GeometryPoint GeometryPoint { get; set; }
//public Point Center { get; set; }
//public Point NetTopologySuitePoint { get; set; }