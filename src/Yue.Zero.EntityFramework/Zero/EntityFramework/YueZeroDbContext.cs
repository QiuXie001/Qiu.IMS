using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using Yue.Application.Editions;
using Yue.Application.Features;
using Yue.Authorization.Roles;
using Yue.Authorization.Users;
using Yue.BackgroundJobs;
using Yue.EntityFramework.Extensions;
using Yue.MultiTenancy;
using Yue.Notifications;

namespace Yue.Zero.EntityFramework
{
    /// <summary>
    /// Base DbContext for YUE zero.
    /// Derive your DbContext from this class to have base entities.
    /// </summary>
    public abstract class YueZeroDbContext<TTenant, TRole, TUser> : YueZeroCommonDbContext<TRole, TUser>
        where TTenant : YueTenant<TUser>
        where TRole : YueRole<TUser>
        where TUser : YueUser<TUser>
    {
        /// <summary>
        /// Tenants
        /// </summary>
        public virtual IDbSet<TTenant> Tenants { get; set; }

        /// <summary>
        /// Editions.
        /// </summary>
        public virtual IDbSet<Edition> Editions { get; set; }

        /// <summary>
        /// FeatureSettings.
        /// </summary>
        public virtual IDbSet<FeatureSetting> FeatureSettings { get; set; }

        /// <summary>
        /// TenantFeatureSetting.
        /// </summary>
        public virtual IDbSet<TenantFeatureSetting> TenantFeatureSettings { get; set; }

        /// <summary>
        /// EditionFeatureSettings.
        /// </summary>
        public virtual IDbSet<EditionFeatureSetting> EditionFeatureSettings { get; set; }

        /// <summary>
        /// Background jobs.
        /// </summary>
        public virtual IDbSet<BackgroundJobInfo> BackgroundJobs { get; set; }

        /// <summary>
        /// User accounts
        /// </summary>
        public virtual IDbSet<UserAccount> UserAccounts { get; set; }

        protected YueZeroDbContext()
        {

        }

        protected YueZeroDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        protected YueZeroDbContext(DbCompiledModel model)
            : base(model)
        {

        }

        protected YueZeroDbContext(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {

        }

        protected YueZeroDbContext(string nameOrConnectionString, DbCompiledModel model)
            : base(nameOrConnectionString, model)
        {
        }

        protected YueZeroDbContext(ObjectContext objectContext, bool dbContextOwnsObjectContext)
            : base(objectContext, dbContextOwnsObjectContext)
        {
        }

        protected YueZeroDbContext(DbConnection existingConnection, DbCompiledModel model, bool contextOwnsConnection)
            : base(existingConnection, model, contextOwnsConnection)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region BackgroundJobInfo.IX_IsAbandoned_NextTryTime

            modelBuilder.Entity<BackgroundJobInfo>()
                .Property(j => j.IsAbandoned)
                .CreateIndex("IX_IsAbandoned_NextTryTime", 1);

            modelBuilder.Entity<BackgroundJobInfo>()
                .Property(j => j.NextTryTime)
                .CreateIndex("IX_IsAbandoned_NextTryTime", 2);

            #endregion

            #region NotificationSubscriptionInfo.IX_NotificationName_EntityTypeName_EntityId_UserId

            modelBuilder.Entity<NotificationSubscriptionInfo>()
                .Property(ns => ns.NotificationName)
                .CreateIndex("IX_NotificationName_EntityTypeName_EntityId_UserId", 1);

            modelBuilder.Entity<NotificationSubscriptionInfo>()
                .Property(ns => ns.EntityTypeName)
                .CreateIndex("IX_NotificationName_EntityTypeName_EntityId_UserId", 2);

            modelBuilder.Entity<NotificationSubscriptionInfo>()
                .Property(ns => ns.EntityId)
                .CreateIndex("IX_NotificationName_EntityTypeName_EntityId_UserId", 3);

            modelBuilder.Entity<NotificationSubscriptionInfo>()
                .Property(ns => ns.UserId)
                .CreateIndex("IX_NotificationName_EntityTypeName_EntityId_UserId", 4);

            #endregion

            #region UserNotificationInfo.IX_UserId_State_CreationTime

            modelBuilder.Entity<UserNotificationInfo>()
                .Property(un => un.UserId)
                .CreateIndex("IX_UserId_State_CreationTime", 1);

            modelBuilder.Entity<UserNotificationInfo>()
                .Property(un => un.State)
                .CreateIndex("IX_UserId_State_CreationTime", 2);

            modelBuilder.Entity<UserNotificationInfo>()
                .Property(un => un.CreationTime)
                .CreateIndex("IX_UserId_State_CreationTime", 3);

            #endregion

            #region UserLoginAttempt.IX_TenancyName_UserNameOrEmailAddress_Result

            modelBuilder.Entity<UserLoginAttempt>()
                .Property(ula => ula.TenancyName)
                .CreateIndex("IX_TenancyName_UserNameOrEmailAddress_Result", 1);

            modelBuilder.Entity<UserLoginAttempt>()
                .Property(ula => ula.UserNameOrEmailAddress)
                .CreateIndex("IX_TenancyName_UserNameOrEmailAddress_Result", 2);

            modelBuilder.Entity<UserLoginAttempt>()
                .Property(ula => ula.Result)
                .CreateIndex("IX_TenancyName_UserNameOrEmailAddress_Result", 3);

            #endregion

            #region UserLoginAttempt.IX_UserId_TenantId

            modelBuilder.Entity<UserLoginAttempt>()
                .Property(ula => ula.UserId)
                .CreateIndex("IX_UserId_TenantId", 1);

            modelBuilder.Entity<UserLoginAttempt>()
                .Property(ula => ula.TenantId)
                .CreateIndex("IX_UserId_TenantId", 2);

            #endregion
        }
    }
}
