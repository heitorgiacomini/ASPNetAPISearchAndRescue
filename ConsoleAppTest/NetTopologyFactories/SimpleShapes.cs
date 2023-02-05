using NetTopologySuite.Geometries;
using NetTopologySuite.Operation.Distance;
using NetTopologySuite.Utilities;
using ProjNet.CoordinateSystems.Transformations;
using ProjNet.CoordinateSystems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest.NetTopologyFactories
{
    public class SimpleShapes
    {
        private readonly GeometricShapeFactory _geometricShapeFactory;

        public SimpleShapes(GeometricShapeFactory geometricShapeFactory)
        {
            _geometricShapeFactory = geometricShapeFactory;
        }

        public Polygon CreateCircle(Coordinate center, double radius)
        {
            _geometricShapeFactory.Base = center;
            _geometricShapeFactory.Size = radius * 2; //Diameter
            return _geometricShapeFactory.CreateCircle();
        }

        public MathTransform GetTransformFilter()
        {
            CoordinateTransformationFactory ctFact = new CoordinateTransformationFactory();

            ProjectedCoordinateSystem googleMapsSys = ProjectedCoordinateSystem.WebMercator;
            ProjectedCoordinateSystem anotherSystem = ProjectedCoordinateSystem.WGS84_UTM(1, true);

            ICoordinateTransformation tranformer = ctFact.CreateFromCoordinateSystems(googleMapsSys, anotherSystem);
            return tranformer.MathTransform;
        }

        public bool ComparingTwoCoords(Coordinate coord1, Coordinate coord2, double threshold)
        {
            // You can play around with these values so lets say we only
            // care down to sixth decimal, threshold can be ".000001"
            // That means Coord1 (1.123456,2.123456)
            // Coord2 (1.123457,2.123457) will return true
            // Better than comparing x and y every time

            return coord1.Equals2D(coord2, threshold);
        }

        public double DistanceBetweenGeometeries(Geometry geo1, Geometry geo2)
        {
            double dist = geo1.Distance(geo2);
            // This is the same as doing the following

            //Finding the closest points
            Coordinate[] closestPoints = DistanceOp.NearestPoints(geo1, geo2);

            //Then Running Distance Calculations on the pair of coordinates (or more returned)
            //Something like this
            double distBetweenClosestPoints = DistanceOp.Distance(new Point(closestPoints[0]),
                new Point(closestPoints[1]));

            return dist; // Or closest Points
        }
    }
}
