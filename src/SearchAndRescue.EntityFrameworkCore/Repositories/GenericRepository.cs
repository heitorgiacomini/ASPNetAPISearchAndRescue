using SearchAndRescue.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace SearchAndRescue.Repositories
{
    //internal class GenericRepository : IGenericRepository, Repository<TEntity, TKey>
    //{
    //    private readonly ISqlExecuter _sqlExecuter;

    //    public GenericRepository(ISqlExecuter sqlExecuter)
    //    {
    //        _sqlExecuter = sqlExecuter;
    //    }

    //    public void UpdateLineString(Point point, String field, int id)
    //    {
    //        var sql = $"UPDATE \"SearchAndRescue\".\"SearchAndRescue\".\"SearchAndRescue\" SET \"{field}\" = ST_AddPoint(\"{field}\", ST_GeomFromText('POINT({point.X} {point.Y})', 4326)) WHERE \"Id\" = {id}";
    //        _sqlExecuter.Execute(sql);
    //    }
    //} 
}
