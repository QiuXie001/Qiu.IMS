

namespace Qiu.Zero.EntityFramework
{
    /// <summary>
    /// Extension methods for <see cref="DbModelBuilder"/>.
    /// </summary>
    public static class ZeroDbModelBuilderExtensions
    {
        /// <summary>
        /// Changes prefix for YUE tables (which is "Yue" by default).
        /// Can be null/empty string to clear the prefix.
        /// </summary>
        /// <typeparam name="TTenant">The type of the tenant entity.</typeparam>
        /// <typeparam name="TRole">The type of the role entity.</typeparam>
        /// <typeparam name="TUser">The type of the user entity.</typeparam>
        /// <param name="modelBuilder">Model builder.</param>
        /// <param name="prefix">Table prefix, or null to clear prefix.</param>
        public static void ChangeYueTablePrefix<TTenant, TRole, TUser>(this ZeroDbModelBuilderExtensions modelBuilder, string prefix, string schemaName = null)
        {
            prefix = prefix ?? "Core_";

            SetTableName<AuditLog>(modelBuilder, prefix + "AuditLog", schemaName);
            SetTableName<BackgroundJobInfo>(modelBuilder, prefix + "BackgroundJobInfo", schemaName);
            SetTableName<Edition>(modelBuilder, prefix + "Edition", schemaName);
            SetTableName<FeatureSetting>(modelBuilder, prefix + "FeatureSetting", schemaName);
            SetTableName<TenantFeatureSetting>(modelBuilder, prefix + "FeatureSetting", schemaName);
            SetTableName<EditionFeatureSetting>(modelBuilder, prefix + "FeatureSetting", schemaName);
            SetTableName<ApplicationLanguage>(modelBuilder, prefix + "ApplicationLanguage", schemaName);
            SetTableName<ApplicationLanguageText>(modelBuilder, prefix + "ApplicationLanguageText", schemaName);
            SetTableName<NotificationInfo>(modelBuilder, prefix + "NotificationInfoQueue", schemaName);
            SetTableName<NotificationSubscriptionInfo>(modelBuilder, prefix + "NotificationSubscriptionInfo", schemaName);
            //SetTableName<OrganizationUnit>(modelBuilder, prefix + "OrganizationUnits", schemaName);
            SetTableName<PermissionSetting>(modelBuilder, prefix + "PermissionSetting", schemaName);
            SetTableName<RolePermissionSetting>(modelBuilder, prefix + "PermissionSetting", schemaName);
            SetTableName<UserPermissionSetting>(modelBuilder, prefix + "PermissionSetting", schemaName);
            SetTableName<TRole>(modelBuilder, prefix + "Role", schemaName);
            SetTableName<Setting>(modelBuilder, prefix + "Setting", schemaName);
            SetTableName<TTenant>(modelBuilder, prefix + "Tenant", schemaName);
            SetTableName<UserLogin>(modelBuilder, prefix + "UserLogin", schemaName);
            SetTableName<UserLoginAttempt>(modelBuilder, prefix + "UserLoginAttempt", schemaName);
            SetTableName<TenantNotificationInfo>(modelBuilder, prefix + "TenantNotificationInfo", schemaName);
            SetTableName<UserNotificationInfo>(modelBuilder, prefix + "UserNotificationInfo", schemaName);
            //SetTableName<UserOrganizationUnit>(modelBuilder, prefix + "UserOrganizationUnits", schemaName);
            SetTableName<UserRole>(modelBuilder, prefix + "UserRole", schemaName);
            SetTableName<TUser>(modelBuilder, prefix + "User", schemaName);
            SetTableName<UserAccount>(modelBuilder, prefix + "UserAccount", schemaName);
            SetTableName<UserClaim>(modelBuilder, prefix + "UserClaim", schemaName);
        }

        private static void SetTableName<TEntity>(DbModelBuilder modelBuilder, string tableName, string schemaName)
            where TEntity : class
        {
            if (schemaName == null)
            {
                modelBuilder.Entity<TEntity>().ToTable(tableName);
            }
            else
            {
                modelBuilder.Entity<TEntity>().ToTable(tableName, schemaName);
            }
        }
    }
}