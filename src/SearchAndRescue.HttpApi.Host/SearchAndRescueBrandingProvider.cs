using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace SearchAndRescue;

[Dependency(ReplaceServices = true)]
public class SearchAndRescueBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "SearchAndRescue";
}
