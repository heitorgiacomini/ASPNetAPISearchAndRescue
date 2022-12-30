using NetTopologySuite.Geometries;
using NetTopologySuite.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest.NetTopologyFactories
{
    public class GeometriesToGeoJson
    {
        GeoJsonWriter _geoJsonWriter = new GeoJsonWriter();
        GeoJsonReader _geoJsonReader = new GeoJsonReader();
        public string convert(Geometry geometry)
        {
            var str = _geoJsonWriter.Write(geometry);
            return str;
        }
        public Geometry read(string json)
        {
            return _geoJsonReader.Read<Geometry>(json);
        }
    }
}
