using System.Data.Common;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using Yue.Authorization.Roles;
using Yue.Authorization.Users;
using Yue.MultiTenancy;

namespace Yue.Zero.EntityFramework
{
    [MultiTenancySide(MultiTenancySides.Host)]
    public abstract class YueZeroTenantDbContext<TRole, TUser> : YueZeroCommonDbContext<TRole, TUser>
        where TRole : YueRole<TUser>
        where TUser : YueUser<TUser>
    {
        /// <summary>
        /// Default constructor.
        /// Do not directly instantiate this class. Instead, use dependency injection!
        /// </summary>
        protected YueZeroTenantDbContext()
        {

        }

        /// <summary>
        /// Constructor with connection string parameter.
        /// </summary>
        /// <param name="nameOrConnectionString">Connection string or a name in connection strings in configuration file</param>
        protected YueZeroTenantDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        protected YueZeroTenantDbContext(DbCompiledModel model)
            : base(model)
        {

        }

        /// <summary>
        /// This constructor can be used for unit tests.
        /// </summary>
        protected YueZeroTenantDbContext(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {

        }

        protected YueZeroTenantDbContext(string nameOrConnectionString, DbCompiledModel model)
            : base(nameOrConnectionString, model)
        {
        }

        protected YueZeroTenantDbContext(ObjectContext objectContext, bool dbContextOwnsObjectContext)
            : base(objectContext, dbContextOwnsObjectContext)
        {
        }

        protected YueZeroTenantDbContext(DbConnection existingConnection, DbCompiledModel model, bool contextOwnsConnection)
            : base(existingConnection, model, contextOwnsConnection)
        {
        }
    }
}