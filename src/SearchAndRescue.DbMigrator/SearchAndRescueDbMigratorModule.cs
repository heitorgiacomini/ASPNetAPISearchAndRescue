using SearchAndRescue.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace SearchAndRescue.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(SearchAndRescueEntityFrameworkCoreModule),
    typeof(SearchAndRescueApplicationContractsModule)
    )]
public class SearchAndRescueDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
