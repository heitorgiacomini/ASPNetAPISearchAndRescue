using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAndRescue.Utils
{
    public class VincentyFormulaDirectProblem
    {
        private double RadiusLong = 6378137.0;
        private double Flatts = 1 / 298.257222101;
        private double RadiusShort => RadiusLong * (1 - Flatts);

        private double DoRad(double a)
        {
            return a / 180 * Math.PI;
        }

        private double RadDo(double a)
        {
            return a * 180 / Math.PI;
        }

        private double XY(double x, double y)
        {
            return Math.Pow(x, y);
        }

        /// <summary>
        /// Get <see cref="Location"/> by lat & long and bearing (direction) and distance (km)
        /// </summary>
        /// <param name="lat"></param>
        /// <param name="lng"></param>
        /// <param name="bearing"></param>
        /// <param name="distance">distance in km</param>
        /// <returns></returns>
        public Location CalcVincenty(double lat, double lng, double bearing, double distance)
        {
            return VincentyDirectFormula(DoRad(lat), DoRad(lng), DoRad(bearing), (distance * 1000));
        }

        private Location VincentyDirectFormula(double lat1, double lng1, double bearing, double lenInMeter)
        {
            var U1 = Math.Atan((1 - Flatts) * Math.Tan(lat1));
            var sigma1 = Math.Atan(Math.Tan(U1) / Math.Cos(bearing));
            var alpha = Math.Asin(Math.Cos(U1) * Math.Sin(bearing));
            var u2 = XY(Math.Cos(alpha), 2) * (XY(RadiusLong, 2) - XY(RadiusShort, 2)) / XY(RadiusShort, 2);
            var A = 1 + (u2 / 16384) * (4096 + u2 * (-768 + u2 * (320 - 175 * u2)));
            var B = (u2 / 1024) * (256 + u2 * (-128 + u2 * (74 - 47 * u2)));
            var sigma = lenInMeter / RadiusShort / A;

            double sigma0;
            double dm2;

            do
            {
                sigma0 = sigma;
                dm2 = 2 * sigma1 + sigma;
                var tempX = Math.Cos(sigma) * (-1 + 2 * XY(Math.Cos(dm2), 2)) - B / 6 * Math.Cos(dm2) * (-3 + 4 * XY(Math.Sin(dm2), 2)) * (-3 + 4 * XY(Math.Cos(dm2), 2));
                var dSigma = B * Math.Sin(sigma) * (Math.Cos(dm2) + B / 4 * tempX);
                sigma = lenInMeter / RadiusShort / A + dSigma;
            } while (Math.Abs(sigma0 - sigma) > 1e-9);

            var x = Math.Sin(U1) * Math.Cos(sigma) + Math.Cos(U1) * Math.Sin(sigma) * Math.Cos(bearing);
            var hxy = XY(XY(Math.Sin(alpha), 2) + XY(Math.Sin(U1) * Math.Sin(sigma) - Math.Cos(U1) * Math.Cos(sigma) * Math.Cos(bearing), (double)2), ((double)1 / 2));
            var tempF = (1.0 - Flatts);
            var y = tempF * hxy;
            var lamda = Math.Sin(sigma) * Math.Sin(bearing) / (Math.Cos(U1) * Math.Cos(sigma) - Math.Sin(U1) * Math.Sin(sigma) * Math.Cos(bearing));
            lamda = Math.Atan(lamda);
            var C = (Flatts / 16) * XY(Math.Cos(alpha), 2) * (4 + Flatts * (4 - 3 * XY(Math.Cos(alpha), 2)));
            var z = Math.Cos(dm2) + C * Math.Cos(sigma) * (-1 + 2 * XY(Math.Cos(dm2), 2));
            var omega = lamda - (1 - C) * Flatts * Math.Sin(alpha) * (sigma + C * Math.Sin(sigma) * z);

            return new Location
            {
                Latitude = RadDo(Math.Atan(x / y)),
                Longitude = RadDo(lng1 + omega)
            };
        }
    }

    public class Location
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
