using NetTopologySuite.Geometries.Utilities;
using NetTopologySuite.Geometries;
using NetTopologySuite.LinearReferencing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAndRescue.Utils
{
    //public class InsertPointinLineString
    //{
        //Geometry InsertPoint(Geometry geom, Coordinate point)
        //{
        //    if (!(geom is ILineal))
        //        throw new InvalidOperationException();

        //    var lil = new LocationIndexedLine(geom);
        //    var ll = lil.Project(point);

        //    var element = (LineString)geom.GetGeometryN(ll.ComponentIndex);
        //    var oldSeq = element.CoordinateSequence;
        //    var newSeq = element.Factory.CoordinateSequenceFactory.Create(
        //        oldSeq.Count + 1, oldSeq.Dimension);

        //    var j = 0;
        //    if (ll.SegmentIndex == 0 && ll.SegmentFraction == 0)
        //    {
        //        if (ll.GetSegment(element).P0.Distance(point) == 0) return geom;
        //        newSeq.SetCoordinate(0, point);
        //        CoordinateSequences.Copy(oldSeq, 0, newSeq, 1, oldSeq.Count);
        //    }
        //    else if (ll.SegmentIndex == oldSeq.Count - 1 && ll.SegmentFraction == 0)
        //    {
        //        if (ll.GetSegment(element).P0.Distance(point) == 0) return geom;
        //        CoordinateSequences.Copy(oldSeq, 0, newSeq, 0, oldSeq.Count);
        //        newSeq.SetCoordinate(oldSeq.Count, point);
        //    }
        //    else
        //    {
        //        if (ll.IsVertex) return geom;

        //        CoordinateSequences.Copy(oldSeq, 0, newSeq, 0, ll.SegmentIndex + 1);
        //        newSeq.SetCoordinate(ll.SegmentIndex + 1, point);
        //        CoordinateSequences.Copy(oldSeq, ll.SegmentIndex + 1, newSeq, ll.SegmentIndex + 2, newSeq.Count - 2 - ll.SegmentIndex);
        //    }

        //    var lines = new List<Geometry>();
        //    LineStringExtracter.GetLines(geom, lines);
        //    lines[ll.ComponentIndex] = geom.Factory.CreateLineString(newSeq);
        //    if (lines.Count == 1)
        //        return lines[0];
        //    return geom.Factory.BuildGeometry(lines);

        //}

    //}
}
