using Volo.Abp.Modularity;

namespace Qiu.IMS;

[DependsOn(
    typeof(IMSApplicationModule),
    typeof(IMSDomainTestModule)
)]
public class IMSApplicationTestModule : AbpModule
{

}
