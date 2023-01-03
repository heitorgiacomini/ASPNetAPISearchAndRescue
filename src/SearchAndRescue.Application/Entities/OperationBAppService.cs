using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetTopologySuite.Algorithm.Locate;
using NetTopologySuite.Geometries;
using SearchAndRescue.Business.Operation;
using SearchAndRescue.Contracts.Operation;
using SearchAndRescue.EntityFrameworkCore;
using SearchAndRescue.Utils;
using System;
using System.Collections.Generic;
//using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Uow;

namespace SearchAndRescue.Entities
{
    public class OperationBAppService : SearchAndRescueAppService, IOperationAppService
    {

        private readonly IRepository<Operation, long> _operationRepository;
        private readonly IGenericRepository<Operation, long> _genericRepository;
        //private readonly ISampleBlogRepository<Operation, long> _sampleBlogRepository;

        public OperationBAppService(
            IRepository<Operation, long> operationRepository,
            IGenericRepository<Operation, long> genericRepository
            //ISampleBlogRepository<Operation, long> sampleBlogRepository
        )
        {
            _operationRepository = operationRepository;
            _genericRepository = genericRepository;
            //_sampleBlogRepository = sampleBlogRepository;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<List<Operation>> ListTesteAsync()
        {

            var qry = await _operationRepository.GetQueryableAsync();
            return null;
        }

        [AllowAnonymous]
        [HttpGet]
        [UnitOfWork]
        public async Task<int> UpdateLineAsync() {
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
            //_ctx.Database.CurrentTransaction.Operation.Local..FromSqlRaw("UPDATE linestrings SET geom = ST_AddPoint(geom, {0}, {1}) WHERE id = {2}", point.X, point.Y, linestring.Id);
            //_ctx.GetDbContext().Database.ExecuteSqlRaw();

            //await _operationRepository.UpdateAsync(operation); 
        }

        //[AllowAnonymous]
        public async Task<OperationDTO> CreateAsync(CreateUpdateOperationDTO input)
        {
            using (var uow = UnitOfWorkManager.Begin(requiresNew: true)) // Add this scope
            {
                try
                {
                    List<Operation> ops = new List<Operation>();
                    var lins = new Operation();
                    

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

                    Coordinate[] cords = new Coordinate[] {
                        new Coordinate(-22.008739354151004, -49.9772135956213),
                        new Coordinate(-21.804878967027566, -49.6146647674963),
                        new Coordinate(-21.442312470615608 ,-49.3564860565588)
                    };
                    
                    lins.Linha = new LineString(cords) { SRID = 4326 };
                    //CoordinateList pontosDaLinha = (CoordinateList)lins.Linha.Coordinates.ToList();

                    ////pontoDaLinha.(new Coordinate(-20.6724244, -48.7620668));
                    //pontosDaLinha.AddLast(new Coordinate(-20.6724244, -48.7620668));
                    
                    //lins.Linha = new LineString(pontosDaLinha.ToArray()) { SRID = 4326 };
                    
                    lins.Name = "Lins";
                    ops.Add(lins);

                    
                    var sp = new Operation();
                    sp.PointAsGeography = new NetTopologySuite.Geometries.Point(-46.8754826, -23.6815315) { SRID = 4326 };
                    sp.Name = "São Paulo";
                    ops.Add(sp);

                    var bauru = new Operation();
                    bauru.PointAsGeography = new NetTopologySuite.Geometries.Point(-49.1605885, -22.2876835) { SRID = 4326 };
                    bauru.Name = "Bauru";
                    ops.Add(bauru);

                    var tokyo = new Operation();
                    tokyo.PointAsGeography = new NetTopologySuite.Geometries.Point(139.6007843, 35.6684415) { SRID = 4326 };
                    tokyo.Name = "Tokyo";
                    ops.Add(tokyo);

                    //operation.PointAsGeography.X = input.PointAsGeography.X;
                    //operation.PointAsGeography.Y = input.PointAsGeography.Y;
                    //operation.PointAsGeography.Z = input.PointAsGeography.Z;

                    //operation.PointAsGeometry.X
                    //operation.PointAsGeometry.Y
                    //operation.PointAsGeometry.Z


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
        //[AllowAnonymous]
        //public async Task<OperationDTO> CreateAsync(CreateUpdateOperationDTO input)
        //{
        //    input.PointAsGeography.X = -49.7620668;
        //    input.PointAsGeography.Y = -21.6724244;

        //    var operation = new Operation();
        //    operation.PointAsGeography = new NetTopologySuite.Geometries.Point(input.PointAsGeography.X, input.PointAsGeography.Y) { SRID = 4326 };
        //    //operation.PointAsGeography.X = input.PointAsGeography.X;
        //    //operation.PointAsGeography.Y = input.PointAsGeography.Y;
        //    //operation.PointAsGeography.Z = input.PointAsGeography.Z;

        //    //operation.PointAsGeometry.X
        //    //operation.PointAsGeometry.Y
        //    //operation.PointAsGeometry.Z

        //    using (var uow = UnitOfWorkManager.Begin(requiresNew: true)) // Add this scope
        //    {

        //        try
        //        {
        //            var x = await _operationRepository.InsertAsync(operation);
        //            await UnitOfWorkManager.Current.SaveChangesAsync();
        //            await uow.CompleteAsync(); // Add this
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //    }


        //    var test = ObjectMapper.Map<Operation, OperationDTO>(operation); ;
        //    return test;
        //}

        //var operation = ObjectMapper.Map<CreateUpdateOperationDTO, Operation>(input); ;

        public Task DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationDTO> GetAsync(long id)
        {
            throw new NotImplementedException();
        }


        public async Task<PagedResultDto<OperationDTO>> GetListAsync(PagedAndSortedResultRequestDto input)
        {

            var operations = await _operationRepository.GetListAsync();

            var totalCount = operations.Count();

            return new PagedResultDto<OperationDTO>(
                totalCount,
                ObjectMapper.Map<List<Operation>, List<OperationDTO>>(operations));
        }

        public Task<OperationDTO> UpdateAsync(long id, CreateUpdateOperationDTO input)
        {
            throw new NotImplementedException();
        }

    }
}
