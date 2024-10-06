using Qiu.IMS.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Qiu.IMS.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class IMSController : AbpControllerBase
{
    protected IMSController()
    {
        LocalizationResource = typeof(IMSResource);
    }
}
