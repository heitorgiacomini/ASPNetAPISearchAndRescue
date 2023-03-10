using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SearchAndRescue.Business;
using SearchAndRescue.EntityFrameworkCore.Mappings;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace SearchAndRescue.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class SearchAndRescueDbContext :
    AbpDbContext<SearchAndRescueDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    public DbSet<GeoFunctionsBusiness> GeoFunctionsBusiness { get; set; }
    public DbSet<CountryBusiness> CountryBusiness { get; set; }
    public DbSet<StateBusiness> StateBusiness { get; set; }
    public DbSet<CityBusiness> CityBusiness { get; set; }
    public DbSet<AdressBusiness> AdressBusiness { get; set; }
    public DbSet<MissingPersonBusiness> MissingPersonBusiness { get; set; }
    public DbSet<RaceBusiness> RaceBusiness { get; set; }
    public DbSet<OperationBusiness> OperationBusiness { get; set; }
    public DbSet<PathSearchOperationBusiness> PathSearchOperationBusiness { get; set; }

    
    public SearchAndRescueDbContext(DbContextOptions<SearchAndRescueDbContext> options)
        : base(options)
    {

    }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    var connectionString = "server=127.0.0.1;port=3306;user=root;password=;database=Issue1619";
    //    var serverVersion = ServerVersion.AutoDetect(connectionString);

    //    optionsBuilder
    //        .UseNpgsql(
    //            connectionString, 
    //            options => options.UseNetTopologySuite())
    //        .UseLoggerFactory(
    //            LoggerFactory.Create(
    //                b => b
    //                    .AddConsole()
    //                    .AddFilter(level => level >= LogLevel.Information)))
    //        .EnableSensitiveDataLogging()
    //        .EnableDetailedErrors();
    //}


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
         
        /* Include modules to your migration db context */
        builder.HasPostgresExtension("postgis");
        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        /* Configure your own tables/entities inside here */
        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(SearchAndRescueConsts.DbTablePrefix + "YourEntities", SearchAndRescueConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});

        builder.ApplyConfiguration(new GeoFunctionsMap());

        builder.ApplyConfiguration(new CountryMap());
        builder.ApplyConfiguration(new StateMap());
        builder.ApplyConfiguration(new CityMap());
        builder.ApplyConfiguration(new AdressMap());
        builder.ApplyConfiguration(new MissingPersonMap());
        builder.ApplyConfiguration(new RaceMap());
        builder.ApplyConfiguration(new OperationMap());
        builder.ApplyConfiguration(new PathSearchOperationMap());




    }
}
