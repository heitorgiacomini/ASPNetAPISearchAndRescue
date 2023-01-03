using Microsoft.EntityFrameworkCore;
using SearchAndRescue.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;

namespace SearchAndRescue.Utils
{
    public class SqlExecuter : ISqlExecuter, ITransientDependency
    {
        private readonly IDbContextProvider<SearchAndRescueDbContext> _dbContextProvider;

        public SqlExecuter(IDbContextProvider<SearchAndRescueDbContext> dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
        }

        public int Execute(string sql, params object[] parameters)
        {
            return _dbContextProvider.GetDbContext().Database.ExecuteSqlRaw(sql, parameters);
        }
    }
}
