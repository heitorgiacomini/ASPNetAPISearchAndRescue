using NetTopologySuite.Geometries;
using SearchAndRescue.EntityFrameworkCore;
using SearchAndRescue.Utils;
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
    }
}
