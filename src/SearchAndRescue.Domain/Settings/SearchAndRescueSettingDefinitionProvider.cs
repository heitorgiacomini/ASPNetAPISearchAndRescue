using Volo.Abp.Settings;

namespace SearchAndRescue.Settings;

public class SearchAndRescueSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(SearchAndRescueSettings.MySetting1));
    }
}
