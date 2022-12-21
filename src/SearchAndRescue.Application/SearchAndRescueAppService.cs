using System;
using System.Collections.Generic;
using System.Text;
using SearchAndRescue.Localization;
using Volo.Abp.Application.Services;

namespace SearchAndRescue;

/* Inherit your application services from this class.
 */
public abstract class SearchAndRescueAppService : ApplicationService
{
    protected SearchAndRescueAppService()
    {
        LocalizationResource = typeof(SearchAndRescueResource);
    }
}
