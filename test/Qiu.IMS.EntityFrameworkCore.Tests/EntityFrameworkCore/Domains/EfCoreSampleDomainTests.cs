using Qiu.IMS.Samples;
using Xunit;

namespace Qiu.IMS.EntityFrameworkCore.Domains;

[Collection(IMSTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<IMSEntityFrameworkCoreTestModule>
{

}
