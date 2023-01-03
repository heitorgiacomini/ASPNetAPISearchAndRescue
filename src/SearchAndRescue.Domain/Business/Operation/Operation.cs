using NetTopologySuite.Algorithm;
using NetTopologySuite;
using NetTopologySuite.Geometries;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using NetTopologySuite.Geometries.Prepared;
using NetTopologySuite.Algorithm.Locate;

namespace SearchAndRescue.Business.Operation
{
    public class Operation : AggregateRoot<long> //: BaseClass AggregateRoot
    {
        //installed entity framework to project
        //define database type geometry to point set as nullable
        [Column(TypeName = "geometry (PointZ, 4326)")]
        public Point PointAsGeometry { get; set; }
        [Column(TypeName = "geography(POINT,4326)")]
        public Point PointAsGeography { get; set; }
        public string Name { get; set; }
        public Geometry Geometry { get; set; }
        public Polygon Poligono { get; set; }
        //public PreparedPolygon PreparedPolygon { get; set; }
        //public IndexedPointInAreaLocator IndexedPointInAreaLocator { get; set; }
        public LineString Linha { get; set; }
        //public Coordinate[] Coordinates { get; set; }
        //[NotMapped]
        //public NetTopologySuite.Geometries.CoordinateList CoordinateList { get; set; }



        //public CoordinateZ PCoordinateZ { get; set; }
        ////public SQLGeography PDbGeography { get; set; }
        //public string Name { get; set; }
        //public decimal? RadiusOfInterest { get; set; }
        //public DateTime? StartDate { get; set; }
        //public DateTime? EndDate { get; set; }
        //public long? OperationStatusId { get; set; }
        //public OperationStatus OperationStatus { get; set; }

        public Operation()
        {
            //PointAsGeometry.Distance(new Point(1, 1));

            

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