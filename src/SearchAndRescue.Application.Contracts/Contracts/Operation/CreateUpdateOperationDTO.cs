using SearchAndRescue.Contracts.GenericIApplicationService;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace SearchAndRescue.Contracts.Operation
{
    public class CreateUpdateOperationDTO
    {
        public Point3D PointAsGeography { get; set; }
        //public CoordinateZ PCoordinateZ { get; set; }

    }
}
