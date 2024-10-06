using Volo.Abp.Modularity;

namespace Qiu.IMS;

[DependsOn(
    typeof(IMSDomainModule),
    typeof(IMSTestBaseModule)
)]
public class IMSDomainTestModule : AbpModule
{

}
