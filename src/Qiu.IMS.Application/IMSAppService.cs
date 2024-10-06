using Qiu.IMS.Localization;
using Volo.Abp.Application.Services;

namespace Qiu.IMS;

/* Inherit your application services from this class.
 */
public abstract class IMSAppService : ApplicationService
{
    protected IMSAppService()
    {
        LocalizationResource = typeof(IMSResource);
    }
}
