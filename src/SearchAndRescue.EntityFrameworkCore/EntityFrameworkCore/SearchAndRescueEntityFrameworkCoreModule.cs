using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SearchAndRescue.Repositories;
using SearchAndRescue.Utils;
using System;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.PostgreSql;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.Modularity;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace SearchAndRescue.EntityFrameworkCore;

[DependsOn(
    typeof(SearchAndRescueDomainModule),
    typeof(AbpIdentityEntityFrameworkCoreModule),
    typeof(AbpOpenIddictEntityFrameworkCoreModule),
    typeof(AbpPermissionManagementEntityFrameworkCoreModule),
    typeof(AbpSettingManagementEntityFrameworkCoreModule),
    typeof(AbpEntityFrameworkCorePostgreSqlModule),
    typeof(AbpBackgroundJobsEntityFrameworkCoreModule),
    typeof(AbpAuditLoggingEntityFrameworkCoreModule),
    typeof(AbpTenantManagementEntityFrameworkCoreModule),
    typeof(AbpFeatureManagementEntityFrameworkCoreModule)
    )]
public class SearchAndRescueEntityFrameworkCoreModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        // https://www.npgsql.org/efcore/release-notes/6.0.html#opting-out-of-the-new-timestamp-mapping-logic
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        SearchAndRescueEfCoreEntityExtensionMappings.Configure();

         
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
       
        context.Services.AddAbpDbContext<SearchAndRescueDbContext>(options =>
        {
            /* Remove "includeAllEntities: true" to create
             * default repositories only for aggregate roots */
            options.AddDefaultRepositories(includeAllEntities: true);
            //
            
            //options.AddRepository<IGenericRepository<TEntity, TKey>, EfCoreGenericRepository<TEntity, TKey>>;
            //options.AddRepository< typeof(ISampleBlogRepository<,>), typeof(ISampleBlogRepository<,>) > ();
            //options.AddRepository(typeof(ISampleBlogRepository<,>), typeof(SampleBlogRepositoryBase<,>));
        });
        
        context.Services.AddSingleton(typeof(ISampleBlogRepository<,>), typeof(SampleBlogRepositoryBase<,>));
        context.Services.AddSingleton(typeof(IGenericRepository<,>), typeof(EfCoreGenericRepository<,>));
        
    


        Configure<AbpDbContextOptions>(options =>
        {
            
            /* The main point to change your DBMS.
             * See also SearchAndRescueMigrationsDbContextFactory for EF Core tooling. */ 
            options.UseNpgsql(x => x.UseNetTopologySuite());
        });

        //Configure<AbpDbContextOptions>(options =>
        //{
        //    options.Configure(c =>
        //    {
        //        c.UseSqlServer();
        //        c.DbContextOptions.UseTriggers();
        //    });
        //});
    }
}
