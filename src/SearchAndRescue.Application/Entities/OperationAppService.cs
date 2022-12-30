using SearchAndRescue.Business;
using SearchAndRescue.Contracts.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace SearchAndRescue.Entities
{
    public class OperationAppService :
        CrudAppService<
            Operation, //The Book entity
            OperationDTO, //Used to show books
            long, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateOperationDTO>, //Used to create/update a book
        IOperationAppService //implement the IBookAppService
    {
        public OperationAppService(IRepository<Operation, long> repository)
            : base(repository)
        {

        }
    }
}
