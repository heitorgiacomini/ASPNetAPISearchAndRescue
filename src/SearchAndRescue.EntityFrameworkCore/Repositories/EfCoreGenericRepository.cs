using NetTopologySuite.Geometries;
using SearchAndRescue.EntityFrameworkCore;
using SearchAndRescue.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


namespace SearchAndRescue.Repositories
{ 
    public class EfCoreGenericRepository<TEntity, TKey> :
        EfCoreRepository<SearchAndRescueDbContext, TEntity, TKey>,
        IGenericRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
        private readonly ISqlExecuter _sqlExecuter;
        //public EfCoreAporteRepository(
        //    ISqlExecuter sqlExecuter,
        //    IDbContextProvider<SearchAndRescueDbContext> dbContextProvider)
        //    : base(dbContextProvider)
        //{
        //    _sqlExecuter = sqlExecuter;
        //}

        public EfCoreGenericRepository(
            ISqlExecuter sqlExecuter,
            IDbContextProvider<SearchAndRescueDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
            _sqlExecuter = sqlExecuter;
        }
         
        public int UpdateLineString(NetTopologySuite.Geometries.Point point, string field, TKey id)
        { 
            var sql2 = $"""UPDATE "SearchAndRescue"."Business"."AppOperation" SET "{field}" = ST_AddPoint("{field}",ST_SetSRID(ST_MakePoint({point.X},{point.Y}), 4326)) WHERE "Id" = {id}""";
            return _sqlExecuter.Execute(sql2); 
        }

        public int CreateCircle(NetTopologySuite.Geometries.Point point, string field, TKey id)
        {
            var sql = """
            
                """;
          //  var sql2 = $"""UPDATE "SearchAndRescue"."Business"."AppOperation" SET "{field}" = ST_AddPoint("{field}",ST_SetSRID(ST_MakePoint({point.X},{point.Y}), 4326)) WHERE "Id" = {id}""";
          //  return _sqlExecuter.Execute(sql2);
          //      INSERT INTO circle(the_geom)
          //SELECT ST_Buffer(ST_GeomFromText('POINT(x y)', 4326), r) as the_geom
          //FROM(SELECT 0 as x, 0 as y, 1000 as r) as params;
        }

        public int UpdateCircle(NetTopologySuite.Geometries.Point point, string field, TKey id)
        {
            //  var sql2 = $"""UPDATE "SearchAndRescue"."Business"."AppOperation" SET "{field}" = ST_AddPoint("{field}",ST_SetSRID(ST_MakePoint({point.X},{point.Y}), 4326)) WHERE "Id" = {id}""";
            //  return _sqlExecuter.Execute(sql2);
            //      INSERT INTO circle(the_geom)
            //SELECT ST_Buffer(ST_GeomFromText('POINT(x y)', 4326), r) as the_geom
            //FROM(SELECT 0 as x, 0 as y, 1000 as r) as params;
            throw new NotImplementedException();
        }
    }
}
