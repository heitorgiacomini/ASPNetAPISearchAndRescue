using SearchAndRescue.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace SearchAndRescue.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class SearchAndRescueController : AbpControllerBase
{
    protected SearchAndRescueController()
    {
        LocalizationResource = typeof(SearchAndRescueResource);
    }
}
