using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetTopologySuite;
using NetTopologySuite.Algorithm.Locate;
using NetTopologySuite.Geometries;
using SearchAndRescue.Business;
using SearchAndRescue.Contracts.Operation;
using SearchAndRescue.EntityFrameworkCore;
using SearchAndRescue.Utils;
using System;
using System.Collections.Generic;
//using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Uow;

namespace SearchAndRescue.Controllers
{
    public class OperationBAppService : SearchAndRescueAppService//, IOperationAppService
    {

        private readonly IRepository<GeoFunctionsBusiness, long> _operationRepository;
        private readonly IGenericRepository<GeoFunctionsBusiness, long> _genericRepository;
        //private readonly ISampleBlogRepository<GeoFunctionsBusiness, long> _sampleBlogRepository;

        public OperationBAppService(
            IRepository<GeoFunctionsBusiness, long> operationRepository,
            IGenericRepository<GeoFunctionsBusiness, long> genericRepository
        //ISampleBlogRepository<GeoFunctionsBusiness, long> sampleBlogRepository
        )
        {
            _operationRepository = operationRepository;
            _genericRepository = genericRepository;
            //_sampleBlogRepository = sampleBlogRepository;
        }
       
         

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
                ObjectMapper.Map<List<GeoFunctionsBusiness>, List<OperationDTO>>(operations));
        }

        public Task<OperationDTO> UpdateAsync(long id, CreateUpdateOperationDTO input)
        {
            throw new NotImplementedException();
        }

    }
}
