using SearchAndRescue.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace SearchAndRescue.Permissions;

public class SearchAndRescuePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(SearchAndRescuePermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(SearchAndRescuePermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<SearchAndRescueResource>(name);
    }
}
