using livraria.Authors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetTopologySuite.Algorithm.Locate;
using NetTopologySuite.Geometries;
using NetTopologySuite;
using SearchAndRescue.Contracts.Operation;
using SearchAndRescue.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Uow;
using Volo.Abp.Domain.Repositories;
using SearchAndRescue.Business;

namespace SearchAndRescue.Controllers
{
    public class GeoFunctionsBusinessAppService : SearchAndRescueAppService
    {
        private readonly IRepository<GeoFunctionsBusiness, long> _operationRepository;
        private readonly IGenericRepository<GeoFunctionsBusiness, long> _genericRepository;
        //private readonly ISampleBlogRepository<GeoFunctionsBusiness, long> _sampleBlogRepository;

        public GeoFunctionsBusinessAppService(
            IRepository<GeoFunctionsBusiness, long> operationRepository,
            IGenericRepository<GeoFunctionsBusiness, long> genericRepository
        //ISampleBlogRepository<GeoFunctionsBusiness, long> sampleBlogRepository
        )
        {
            _operationRepository = operationRepository;
            _genericRepository = genericRepository;
            //_sampleBlogRepository = sampleBlogRepository;
        }  
        
        [AllowAnonymous]
        [HttpGet]
        public async Task<List<GeoFunctionsBusiness>> ListTesteAsync()
        {

            var qry = await _operationRepository.GetQueryableAsync();
            return null;
        }
        [AllowAnonymous]
        [HttpGet]
        [UnitOfWork]
        public async Task<int> UpdateLineAsync()
        {
            var qry = await _operationRepository.GetQueryableAsync();
            var linestring = qry.Where(x => x.Name == "Lins").FirstOrDefault();

            var point = new Point(13, 13);

            using (var uow = UnitOfWorkManager.Begin(requiresNew: true)) // Add this scope
            {
                var linhasafetadas = _genericRepository.UpdateLineString(point, nameof(linestring.Linha), linestring.Id);
                await UnitOfWorkManager.Current.SaveChangesAsync();
                await uow.CompleteAsync(); // Add this
                return linhasafetadas;
            }
            // Use ST_AddPoint to add the point to the linestring
            //_ctx.Database.CurrentTransaction.GeoFunctionsBusiness.Local..FromSqlRaw("UPDATE linestrings SET geom = ST_AddPoint(geom, {0}, {1}) WHERE id = {2}", point.X, point.Y, linestring.Id);
            //_ctx.GetDbContext().Database.ExecuteSqlRaw();

            //await _operationRepository.UpdateAsync(operation); 
        }

        [AllowAnonymous]
        [HttpGet]
        [UnitOfWork]
        public async Task<bool?> CrieUmCirculoBaseadoEmUmPontoEUmRaioEmKm()
        {
            using (var uow = UnitOfWorkManager.Begin(requiresNew: true)) // Add this scope
            {
                try
                {
                    double cirRadiusInKms = 10;

                    var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(4326); // WGS84

                    var circleCenter = new NetTopologySuite.Geometries.Coordinate(-46.8754826, -23.6815315);

                    var circle = geometryFactory.CreatePoint(circleCenter).Buffer(cirRadiusInKms);


                    //await UnitOfWorkManager.Current.SaveChangesAsync();
                    //await uow.CompleteAsync(); // Add this
                    return null;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public double MeterToDegree(double meters, double latitude)
        {
            return meters / (111.32 * 1000 * Math.Cos(latitude * (Math.PI / 180)));
        }
        [AllowAnonymous]
        public async Task<OperationDTO> CrieVariasObjetosAtribuaLineStringESalveTodoasNoBancoDeUmaVez(CreateUpdateOperationDTO input)
        {
            using (var uow = UnitOfWorkManager.Begin(requiresNew: true)) // Add this scope
            {
                try
                {
                    List<GeoFunctionsBusiness> ops = new List<GeoFunctionsBusiness>();
                    
                    Coordinate[] cords = new Coordinate[] {
                        new Coordinate(-22.008739354151004, -49.9772135956213),
                        new Coordinate(-21.804878967027566, -49.6146647674963),
                        new Coordinate(-21.442312470615608 ,-49.3564860565588)
                    };

                    var lins = new GeoFunctionsBusiness();

                    lins.Linha = new LineString(cords) { SRID = 4326 };

                    lins.Name = "Lins";
                    ops.Add(lins);


                    var sp = new GeoFunctionsBusiness();
                    sp.PointAsGeography = new NetTopologySuite.Geometries.Point(-46.8754826, -23.6815315) { SRID = 4326 };
                    sp.Name = "São Paulo";
                    ops.Add(sp);

                    var bauru = new GeoFunctionsBusiness();
                    bauru.PointAsGeography = new NetTopologySuite.Geometries.Point(-49.1605885, -22.2876835) { SRID = 4326 };
                    bauru.Name = "Bauru";
                    ops.Add(bauru);

                    var tokyo = new GeoFunctionsBusiness();
                    tokyo.PointAsGeography = new NetTopologySuite.Geometries.Point(139.6007843, 35.6684415) { SRID = 4326 };
                    tokyo.Name = "Tokyo";
                    ops.Add(tokyo);

                    await _operationRepository.InsertManyAsync(ops);
                    await UnitOfWorkManager.Current.SaveChangesAsync();
                    await uow.CompleteAsync(); // Add this
                    return null;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }


        [AllowAnonymous]
        public async Task<OperationDTO> CrieUmPoligonoEVerifiqueSeUmPontoLhePertence(CreateUpdateOperationDTO input)
        {
            List<GeoFunctionsBusiness> ops = new List<GeoFunctionsBusiness>();
            var lins = new GeoFunctionsBusiness();


            Coordinate[] polygonCoords = new Coordinate[] {
                new Coordinate(-20.523359617261246, -50.76550190635486),
                new Coordinate(-20.523359617261246, -42.72350971885486),
                new Coordinate(-25.417091836608826, -42.72350971885486),
                new Coordinate(-25.417091836608826, -50.76550190635486),
                new Coordinate(-20.523359617261246, -50.76550190635486)
            };

            lins.Poligono = new Polygon(new LinearRing(polygonCoords)) { SRID = 4326 };

            // Create an IndexedPointInAreaLocator for the polygon
            IndexedPointInAreaLocator locator = new IndexedPointInAreaLocator(lins.Poligono);
            Coordinate pointCoord = new Coordinate(-21.6724244, -49.7620668);
            // Use the locator to determine if the point is inside the polygon
            bool isInside = locator.Locate(pointCoord) == NetTopologySuite.Geometries.Location.Interior;

            lins.PointAsGeography = new NetTopologySuite.Geometries.Point(-21.6724244, -49.7620668) { SRID = 4326 };

            var b = lins.Poligono.Contains(lins.PointAsGeography);


            return null;
        }
    }
}
