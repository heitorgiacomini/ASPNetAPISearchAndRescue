using AutoMapper;
using SearchAndRescue.Business.Operation;
using SearchAndRescue.Contracts.Operation;

namespace SearchAndRescue;

public class SearchAndRescueApplicationAutoMapperProfile : Profile
{
    public SearchAndRescueApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Operation, OperationDTO>();
        CreateMap<CreateUpdateOperationDTO, Operation>(); 
        


    }
}
