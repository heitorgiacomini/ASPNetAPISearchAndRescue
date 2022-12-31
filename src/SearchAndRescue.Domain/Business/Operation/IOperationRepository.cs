using livraria.Authors;
using SearchAndRescue.Business.Operation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace livraria.Authors
{
    public interface IOperationRepository : IRepository<Operation, long>
    {
        Task<Operation> FindByNameAsync(string name);
        
        Task<List<Operation>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null
        );
    }
}
