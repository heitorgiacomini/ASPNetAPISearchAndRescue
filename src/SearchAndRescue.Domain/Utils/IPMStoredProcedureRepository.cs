using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace SearchAndRescue.Utils
{
    public interface IPMStoredProcedureRepository<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey> where TEntity : class, IEntity<TPrimaryKey>
    {
        List<TEntity> ExecuteSP(string query, params object[] parameters);
    }

    public interface IPMStoredProcedureRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity<int>
    {
        List<TEntity> ExecuteSP(string query, params object[] parameters);
    }
    public interface ISampleBlogRepository<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        List<TEntity> ExecuteSP(string query, params object[] parameters);
        public int UpdateLineString(Point point, String field, TPrimaryKey id);
    }

    //public interface ISampleBlogRepository<TEntity> : IRepository<TEntity>
    //    where TEntity : class, IEntity<int>
    //{
    //    List<TEntity> ExecuteSP(string query, params object[] parameters); 
    //}
}
