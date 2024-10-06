using Microsoft.Extensions.Localization;
using Qiu.IMS.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Qiu.IMS;

[Dependency(ReplaceServices = true)]
public class IMSBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<IMSResource> _localizer;

    public IMSBrandingProvider(IStringLocalizer<IMSResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
