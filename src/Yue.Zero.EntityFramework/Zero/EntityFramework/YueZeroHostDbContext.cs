using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using Yue.Application.Editions;
using Yue.Application.Features;
using Yue.Authorization.Roles;
using Yue.Authorization.Users;
using Yue.BackgroundJobs;
using Yue.MultiTenancy;

namespace Yue.Zero.EntityFramework
{
    [MultiTenancySide(MultiTenancySides.Host)]
    public abstract class YueZeroHostDbContext<TTenant, TRole, TUser> : YueZeroCommonDbContext<TRole, TUser>
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

        protected YueZeroHostDbContext()
        {

        }

        protected YueZeroHostDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        protected YueZeroHostDbContext(DbCompiledModel model)
            : base(model)
        {

        }

        protected YueZeroHostDbContext(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {

        }

        protected YueZeroHostDbContext(string nameOrConnectionString, DbCompiledModel model)
            : base(nameOrConnectionString, model)
        {
        }

        protected YueZeroHostDbContext(ObjectContext objectContext, bool dbContextOwnsObjectContext)
            : base(objectContext, dbContextOwnsObjectContext)
        {
        }

        protected YueZeroHostDbContext(DbConnection existingConnection, DbCompiledModel model, bool contextOwnsConnection)
            : base(existingConnection, model, contextOwnsConnection)
        {
        }
    }
}