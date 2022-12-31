using Microsoft.AspNetCore.Authorization;
using SearchAndRescue.Business.Operation;
using SearchAndRescue.Contracts.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Uow;

namespace SearchAndRescue.Entities
{
    public class OperationBAppService : SearchAndRescueAppService, IOperationAppService
    {
        
        private readonly IRepository<Operation, long> _operationRepository;

        public OperationBAppService(IRepository<Operation, long> operationRepository)
        {
            _operationRepository = operationRepository;
        }
        [AllowAnonymous]
        public async Task<OperationDTO> CreateAsync(CreateUpdateOperationDTO input)
        {
            input.PointAsGeography.X = -49.7620668;
            input.PointAsGeography.Y = -21.6724244;

            var operation = new Operation();
            operation.PointAsGeography = new NetTopologySuite.Geometries.Point(input.PointAsGeography.X, input.PointAsGeography.Y) { SRID = 4326 };
            //operation.PointAsGeography.X = input.PointAsGeography.X;
            //operation.PointAsGeography.Y = input.PointAsGeography.Y;
            //operation.PointAsGeography.Z = input.PointAsGeography.Z;

            //operation.PointAsGeometry.X
            //operation.PointAsGeometry.Y
            //operation.PointAsGeometry.Z

            using (var uow = UnitOfWorkManager.Begin(requiresNew: true)) // Add this scope
            {

                try
                {
                    var x = await _operationRepository.InsertAsync(operation);
                    await UnitOfWorkManager.Current.SaveChangesAsync();
                    await uow.CompleteAsync(); // Add this
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }


            var test = ObjectMapper.Map<Operation, OperationDTO>(operation); ;
            return test;
        }
        //var operation = ObjectMapper.Map<CreateUpdateOperationDTO, Operation>(input); ;

        public Task DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationDTO> GetAsync(long id)
        {
            throw new NotImplementedException();
        }
         

        public async Task<PagedResultDto<OperationDTO>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            
            var operations = await _operationRepository.GetListAsync();

            var totalCount = operations.Count();

            return new PagedResultDto<OperationDTO>(
                totalCount,
                ObjectMapper.Map<List<Operation>, List<OperationDTO>>(operations));
        }

        public Task<OperationDTO> UpdateAsync(long id, CreateUpdateOperationDTO input)
        {
            throw new NotImplementedException();
        }
        
    }
}
