using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace SearchAndRescue.Contracts.Operation
{
    public interface IOperationAppService :
        ICrudAppService< //Defines CRUD methods
            OperationDTO, //Used to show operations
            long, //Primary key of the operation entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateOperationDTO> //Used to create/update a operation
    {

    }
}
