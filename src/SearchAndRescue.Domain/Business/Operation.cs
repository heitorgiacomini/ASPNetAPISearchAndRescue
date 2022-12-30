using NetTopologySuite.Geometries;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace SearchAndRescue.Business
{
    public class Operation : BaseClass
    {
        public string Name { get; set; }
        [Column(TypeName = "geography")]
        public Point Point { get; set; }
        public decimal RadiusOfInterest { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public long OperationStatusId { get; set; }
        public OperationStatus OperationStatus { get; set; }

        public Operation()
        {
            
        }

    }
}

//HasConversion(new GeographyValueConverter()
//[Column(TypeName = "geography")]

//public CoordinateZ CoordinateZ { get; set; }

//Npgsql.PostgresTypes
//public NpgsqlPoint NpgsqlPoint { get; set; }
//public Geography Geography { get; set; }
//public DbGeography DbGeography { get; set; }
//public GeometryPoint GeometryPoint { get; set; }
//public Point Center { get; set; }
//public Point NetTopologySuitePoint { get; set; }