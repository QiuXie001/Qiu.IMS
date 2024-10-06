using Xunit;

namespace Qiu.IMS.EntityFrameworkCore;

[CollectionDefinition(IMSTestConsts.CollectionDefinitionName)]
public class IMSEntityFrameworkCoreCollection : ICollectionFixture<IMSEntityFrameworkCoreFixture>
{

}
