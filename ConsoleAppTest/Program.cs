//var cwc = mt.Transform(windsorCastle.X, windsorCastle.Y);
//var cbp = mt.Transform(buckinghamPalace.X, buckinghamPalace.Y);

//Console.WriteLine(new Coordinate(cwc.x, cwc.y).Distance(new Coordinate(cbp.x, cbp.y)))

//using ProjNet;

//var csWgs84 = ProjNet.CoordinateSystems.GeographicCoordinateSystem.WGS84;
//const string epsg27700 = "..."; // see http://epsg.io/27700


//var cs27700 = ProjNet.Converters.WellKnownText.CoordinateSystemWktReader.Parse(epsg27700);
//var ctFactory = new ProjNet.CoordinateSystems.Transformations.CoordinateTransformationFactory();
//var ct = ctFactory.CreateFromCoordinateSystems(csWgs84, cs27700);
//var mt = ct.MathTransform;

//var gf = new NetTopologySuite.Geometries.GeometryFactory(null, 27700);

//// BT2 8HB
//var myPostcode = gf.CreatePoint(mt.Transform(new Coordinate(-5.926223, 54.592395)));
//// DT11 0DB
//var myMatesPostcode = gf.CreatePoint(mt.Transform(new Coordinate(-2.314507, 50.827157)));

//double distance = myPostcode.Distance(myMatesPostcode);

//using GeoAPI.CoordinateSystems;
//using ProjNet.CoordinateSystems;



//List<GeoAPI.CoordinateSystems.ProjectionParameter> parameters = new List<GeoAPI.CoordinateSystems.ProjectionParameter>(4);
//parameters.Add(new GeoAPI.CoordinateSystems.ProjectionParameter("latitude_of_origin", 0));
//parameters.Add(new GeoAPI.CoordinateSystems.ProjectionParameter("central_meridian", 0));
//parameters.Add(new GeoAPI.CoordinateSystems.ProjectionParameter("false_easting", 0));
//parameters.Add(new GeoAPI.CoordinateSystems.ProjectionParameter("false_northing", 0));
//IProjection projection = cFac.CreateProjection("Mercator_1SP", "Mercator_1SP", parameters);
//IProjectedCoordinateSystem coordsys = cFac.CreateProjectedCoordinateSystem("World Mercator WGS84",
//    GeographicCoordinateSystem.WGS84, projection, LinearUnit.Metre,
//    new AxisInfo("East", AxisOrientationEnum.East), new AxisInfo("North", AxisOrientationEnum.North));


//IProjectedCoordinateSystem UTM32N = ProjectedCoordinateSystem.WGS84_UTM(32, true);
Console.WriteLine(1);