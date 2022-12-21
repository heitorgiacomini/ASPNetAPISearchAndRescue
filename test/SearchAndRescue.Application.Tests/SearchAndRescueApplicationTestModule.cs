using Volo.Abp.Modularity;

namespace SearchAndRescue;

[DependsOn(
    typeof(SearchAndRescueApplicationModule),
    typeof(SearchAndRescueDomainTestModule)
    )]
public class SearchAndRescueApplicationTestModule : AbpModule
{

}
