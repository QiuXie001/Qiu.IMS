using Volo.Abp.Settings;

namespace Qiu.IMS.Settings;

public class IMSSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(IMSSettings.MySetting1));
    }
}
