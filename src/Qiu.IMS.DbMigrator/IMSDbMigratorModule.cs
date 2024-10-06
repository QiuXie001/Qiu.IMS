using Qiu.IMS.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Qiu.IMS.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(IMSEntityFrameworkCoreModule),
    typeof(IMSApplicationContractsModule)
)]
public class IMSDbMigratorModule : AbpModule
{
}
