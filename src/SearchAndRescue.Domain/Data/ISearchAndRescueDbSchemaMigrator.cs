using System.Threading.Tasks;

namespace SearchAndRescue.Data;

public interface ISearchAndRescueDbSchemaMigrator
{
    Task MigrateAsync();
}
