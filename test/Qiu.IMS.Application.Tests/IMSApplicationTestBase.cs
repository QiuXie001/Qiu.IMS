using Volo.Abp.Modularity;

namespace Qiu.IMS;

public abstract class IMSApplicationTestBase<TStartupModule> : IMSTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
