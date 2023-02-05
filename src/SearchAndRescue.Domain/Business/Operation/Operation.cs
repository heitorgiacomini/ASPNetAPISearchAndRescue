using NetTopologySuite.Algorithm;
using NetTopologySuite;
using NetTopologySuite.Geometries;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using NetTopologySuite.Geometries.Prepared;
using NetTopologySuite.Algorithm.Locate;
using System.ComponentModel.DataAnnotations;

namespace SearchAndRescue.Business
{
    public class OperationBusiness : BaseClassBusiness
    {
        [MaxLength(30)]
        public string Name { get; set; }
        [Column(TypeName = "geometry (PointZ, 4326)")]
        public Point PointOfInterest { get; set; }
        public int RadiusOfInterestInKm { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public long? OperationStatusId { get; set; }
        public OperationStatusBusiness OperationStatus { get; set; }
         

    }
}
