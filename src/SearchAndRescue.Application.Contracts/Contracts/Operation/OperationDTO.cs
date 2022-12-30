using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace SearchAndRescue.Contracts.Operation
{
    public class OperationDTO : FullAuditedEntityDto<long>
    {
        public NetTopologySuite.Geometries.Point PointAsGeometry { get; set; }
        public NetTopologySuite.Geometries.Point PointAsGeography { get; set; }
        //public CoordinateZ PCoordinateZ { get; set; }
    }
}
