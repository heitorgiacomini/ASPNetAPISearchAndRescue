using ProjNet.CoordinateSystems.Transformations;
using ProjNet.CoordinateSystems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetTopologySuite.Geometries;

namespace ConsoleAppTest.NetTopologyFactories
{
    internal class MathTransformFilter : ICoordinateSequenceFilter
    {
        //https://github.com/NetTopologySuite/ProjNet4GeoAPI/wiki/Projecting-points-from-one-coordinate-system-to-another
        private readonly MathTransform _mathTransform;

        public MathTransformFilter(MathTransform mathTransform)
            => _mathTransform = mathTransform;

        public bool Done => false;
        public bool GeometryChanged => true;

        public void Filter(CoordinateSequence seq, int i)
        {
            var (x, y, z) = _mathTransform.Transform(seq.GetX(i), seq.GetY(i), seq.GetZ(i));
            seq.SetX(i, x);
            seq.SetY(i, y);
        }
        public Geometry Transform(Geometry geometry, MathTransform mathTransform)
        {
            geometry = geometry.Copy();
            geometry.Apply(new MathTransformFilter(mathTransform));
            return geometry;
        }

        //Or if injected in
        //public Geometry Transform(Geometry geometry)
        //{
        //    geometry = geometry.Copy();
        //    geometry.Apply(_mathTransform);
        //    return geometry;
        //}

    }
}
