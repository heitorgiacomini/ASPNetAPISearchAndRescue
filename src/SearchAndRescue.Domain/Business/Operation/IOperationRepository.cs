using livraria.Authors;
using SearchAndRescue.Business;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace livraria.Authors
{
    public interface IOperationRepository : IRepository<OperationBusiness, long>
    {
        Task<OperationBusiness> FindByNameAsync(string name);
        
        Task<List<OperationBusiness>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null
        );
    }
}
