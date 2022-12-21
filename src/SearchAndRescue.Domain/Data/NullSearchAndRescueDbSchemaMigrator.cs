using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace SearchAndRescue.Data;

/* This is used if database provider does't define
 * ISearchAndRescueDbSchemaMigrator implementation.
 */
public class NullSearchAndRescueDbSchemaMigrator : ISearchAndRescueDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
