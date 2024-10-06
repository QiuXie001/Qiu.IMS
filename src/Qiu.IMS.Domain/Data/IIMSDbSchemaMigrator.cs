using System.Threading.Tasks;

namespace Qiu.IMS.Data;

public interface IIMSDbSchemaMigrator
{
    Task MigrateAsync();
}
