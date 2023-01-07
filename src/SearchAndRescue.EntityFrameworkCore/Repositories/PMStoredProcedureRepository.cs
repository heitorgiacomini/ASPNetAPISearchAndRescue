using Microsoft.EntityFrameworkCore;
using SearchAndRescue.EntityFrameworkCore;
using SearchAndRescue.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using static OpenIddict.Abstractions.OpenIddictConstants;

namespace SearchAndRescue.Repositories
{
    
    //public class SampleBlogRepositoryBase<TEntity> : SampleBlogRepositoryBase<TEntity, int>, ISampleBlogRepository<TEntity>
    //    where TEntity : class, IEntity<int>
    //{
    //    public SampleBlogRepositoryBase(IDbContextProvider<SearchAndRescueDbContext> dbContextProvider)
    //        : base(dbContextProvider)
    //    {
    //    }
    //}

    public class SampleBlogRepositoryBase<TEntity, TPrimaryKey> : EfCoreRepository<SearchAndRescueDbContext, TEntity, TPrimaryKey>, ISampleBlogRepository<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        private SearchAndRescueDbContext Context { get; set; }
        public SampleBlogRepositoryBase(IDbContextProvider<SearchAndRescueDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
            Context = dbContextProvider.GetDbContext();
        }

        public List<TEntity> ExecuteSP(string query, params object[] parameters)
        {
            FormattableString formattable = $"${query}, {parameters}";
            var type = Context.Set<TEntity>().FromSql(formattable).AsNoTracking().ToList<TEntity>();
            return type;
        }

        public int UpdateLineString(NetTopologySuite.Geometries.Point point, string field, TPrimaryKey id)
        {
            var sql = $"UPDATE \"SearchAndRescue\".\"Business\".\"AppOperation\" SET \"{field}\" = ST_AddPoint(\"{field}\",ST_SetSRID(ST_MakePoint({point.X},{point.Y}), 4326)) WHERE \"Id\" = {id}";
            var type = Context.Database.ExecuteSqlRaw(sql);
            return type; 
        }
    }
}
