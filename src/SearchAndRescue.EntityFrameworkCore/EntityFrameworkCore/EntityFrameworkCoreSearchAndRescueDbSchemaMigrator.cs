using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SearchAndRescue.Data;
using Volo.Abp.DependencyInjection;

namespace SearchAndRescue.EntityFrameworkCore;

public class EntityFrameworkCoreSearchAndRescueDbSchemaMigrator
    : ISearchAndRescueDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreSearchAndRescueDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the SearchAndRescueDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<SearchAndRescueDbContext>()
            .Database
            .MigrateAsync();
    }
}
