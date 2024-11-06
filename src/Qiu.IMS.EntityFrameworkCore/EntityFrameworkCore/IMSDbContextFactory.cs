using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Data;
using Volo.Abp.Identity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.TenantManagement;

namespace Qiu.IMS.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class IMSDbContextFactory : IDesignTimeDbContextFactory<IMSDbContext>
{
    public IMSDbContext CreateDbContext(string[] args)
    {
        AbpCommonDbProperties.DbSchema = "dbo.";
        AbpCommonDbProperties.DbTablePrefix = "Core_";
        var configuration = BuildConfiguration();
        
        IMSEfCoreEntityExtensionMappings.Configure();

        var builder = new DbContextOptionsBuilder<IMSDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));
        
        return new IMSDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        AbpCommonDbProperties.DbSchema = "dbo.";
        AbpCommonDbProperties.DbTablePrefix = "Core_";
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Qiu.IMS.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
