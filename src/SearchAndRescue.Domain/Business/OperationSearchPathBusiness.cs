using NetTopologySuite.Geometries;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Spatial;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Identity;
using Volo.Abp.MultiTenancy;

namespace SearchAndRescue.Business
{
    public class PathSearchOperationBusiness : BaseClassBusiness
    {
        [Column(TypeName = "geography(LINESTRINGZ,4326)")]
        public LineString GeographyLineString { get; set; }
        public DateTime Date { get; set; }
        public int Precisao { get; set; }
        public Guid IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
    }
}
