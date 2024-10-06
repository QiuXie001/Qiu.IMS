using Qiu.IMS.Samples;
using Xunit;

namespace Qiu.IMS.EntityFrameworkCore.Applications;

[Collection(IMSTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<IMSEntityFrameworkCoreTestModule>
{

}
