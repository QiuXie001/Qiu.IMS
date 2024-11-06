using System.Reflection;
using Yue.Domain.Uow;
using Yue.EntityFramework;
using Yue.Modules;
using Yue.MultiTenancy;
using Castle.MicroKernel.Registration;

namespace Yue.Zero.EntityFramework
{
    /// <summary>
    /// Entity framework integration module for ASP.NET Boilerplate Zero.
    /// </summary>
    [DependsOn(typeof(YueZeroCoreModule), typeof(YueEntityFrameworkModule))]
    public class YueZeroEntityFrameworkModule : YueModule
    {
        public override void PreInitialize()
        {
            Configuration.ReplaceService(typeof(IConnectionStringResolver), () =>
            {
                IocManager.IocContainer.Register(
                    Component.For<IConnectionStringResolver, IDbPerTenantConnectionStringResolver>()
                        .ImplementedBy<DbPerTenantConnectionStringResolver>()
                        .LifestyleTransient()
                    );
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
