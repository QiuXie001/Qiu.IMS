using Volo.Abp.Modularity;

namespace Qiu.IMS;

/* Inherit from this class for your domain layer tests. */
public abstract class IMSDomainTestBase<TStartupModule> : IMSTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
