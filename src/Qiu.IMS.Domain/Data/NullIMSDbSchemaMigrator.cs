using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Qiu.IMS.Data;

/* This is used if database provider does't define
 * IIMSDbSchemaMigrator implementation.
 */
public class NullIMSDbSchemaMigrator : IIMSDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
