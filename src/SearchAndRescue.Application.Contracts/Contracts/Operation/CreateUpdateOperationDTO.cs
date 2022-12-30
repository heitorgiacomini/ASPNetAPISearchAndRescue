using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace SearchAndRescue.Contracts.Operation
{
    public class CreateUpdateOperationDTO
    {
        public NetTopologySuite.Geometries.Point PointAsGeometry { get; set; }
        public NetTopologySuite.Geometries.Point PointAsGeography { get; set; }
        //public CoordinateZ PCoordinateZ { get; set; }

    }
}
