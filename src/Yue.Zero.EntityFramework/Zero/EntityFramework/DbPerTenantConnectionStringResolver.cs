using System;
using Yue.Configuration.Startup;
using Yue.Domain.Uow;
using Yue.Extensions;
using Yue.MultiTenancy;
using Yue.Runtime.Session;

namespace Yue.Zero.EntityFramework
{
    /// <summary>
    /// Implements <see cref="IDbPerTenantConnectionStringResolver"/> to dynamically resolve
    /// connection string for a multi tenant application.
    /// </summary>
    public class DbPerTenantConnectionStringResolver : DefaultConnectionStringResolver, IDbPerTenantConnectionStringResolver
    {
        /// <summary>
        /// Reference to the session.
        /// </summary>
        public IYueSession YueSession { get; set; }

        private readonly ICurrentUnitOfWorkProvider _currentUnitOfWorkProvider;
        private readonly ITenantCache _tenantCache;

        /// <summary>
        /// Initializes a new instance of the <see cref="DbPerTenantConnectionStringResolver"/> class.
        /// </summary>
        public DbPerTenantConnectionStringResolver(
            IYueStartupConfiguration configuration,
            ICurrentUnitOfWorkProvider currentUnitOfWorkProvider,
            ITenantCache tenantCache)
            : base(
                  configuration)
        {
            _currentUnitOfWorkProvider = currentUnitOfWorkProvider;
            _tenantCache = tenantCache;

            YueSession = NullYueSession.Instance;
        }

        public override string GetNameOrConnectionString(ConnectionStringResolveArgs args)
        {
            if (args.MultiTenancySide == MultiTenancySides.Host)
            {
                return GetNameOrConnectionString(new DbPerTenantConnectionStringResolveArgs(null, args));
            }

            return GetNameOrConnectionString(new DbPerTenantConnectionStringResolveArgs(GetCurrentTenantId(), args));
        }

        public virtual string GetNameOrConnectionString(DbPerTenantConnectionStringResolveArgs args)
        {
            if (args.TenantId == null)
            {
                //Requested for host
                return base.GetNameOrConnectionString(args);
            }

            var tenantCacheItem = _tenantCache.Get(args.TenantId.Value);
            if (tenantCacheItem.ConnectionString.IsNullOrEmpty())
            {
                //Tenant has not dedicated database
                return base.GetNameOrConnectionString(args);
            }

            return tenantCacheItem.ConnectionString;
        }

        protected virtual Guid? GetCurrentTenantId()
        {
            return _currentUnitOfWorkProvider.Current != null
                ? _currentUnitOfWorkProvider.Current.GetTenantId()
                : YueSession.TenantId;
        }
    }
}
