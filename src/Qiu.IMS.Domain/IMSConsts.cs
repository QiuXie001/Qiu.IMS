using Volo.Abp.Identity;

namespace Qiu.IMS;

public static class IMSConsts
{
    public const string DbAppTablePrefix = "App_";
    public const string DbCmsTablePrefix = "Cms_";
    public const string DbCommonTablePrefix = "Common_";
    public const string DbCommentTablePrefix = "Comment_";
    public const string? DbSchema = null;
    public const string AdminEmailDefaultValue = IdentityDataSeedContributor.AdminEmailDefaultValue;
    public const string AdminPasswordDefaultValue = IdentityDataSeedContributor.AdminPasswordDefaultValue;
}
