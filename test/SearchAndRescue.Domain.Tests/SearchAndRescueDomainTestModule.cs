using SearchAndRescue.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace SearchAndRescue;

[DependsOn(
    typeof(SearchAndRescueEntityFrameworkCoreTestModule)
    )]
public class SearchAndRescueDomainTestModule : AbpModule
{

}
