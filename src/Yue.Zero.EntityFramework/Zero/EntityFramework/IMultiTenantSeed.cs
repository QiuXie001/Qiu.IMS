using Yue.MultiTenancy;

namespace Yue.Zero.EntityFramework
{
    public interface IMultiTenantSeed
    {
        YueTenantBase Tenant { get; set; }
    }
}