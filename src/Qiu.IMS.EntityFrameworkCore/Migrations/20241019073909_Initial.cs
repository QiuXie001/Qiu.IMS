using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Qiu.IMS.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo.");

            migrationBuilder.CreateTable(
                name: "Core_AuditLogs",
                schema: "dbo.",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationName = table.Column<string>(type: "nvarchar(96)", maxLength: 96, nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TenantName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    ImpersonatorUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ImpersonatorUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ImpersonatorTenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ImpersonatorTenantName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    ExecutionTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExecutionDuration = table.Column<int>(type: "int", nullable: false),
                    ClientIpAddress = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    ClientName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    ClientId = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    CorrelationId = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    BrowserInfo = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    HttpMethod = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    Url = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Exceptions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    HttpStatusCode = table.Column<int>(type: "int", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_AuditLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Core_BackgroundJobs",
                schema: "dbo.",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    JobArgs = table.Column<string>(type: "nvarchar(max)", maxLength: 1048576, nullable: false),
                    TryCount = table.Column<short>(type: "smallint", nullable: false, defaultValue: (short)0),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NextTryTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastTryTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsAbandoned = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Priority = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)15),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_BackgroundJobs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Core_BlobContainers",
                schema: "dbo.",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_BlobContainers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Core_ClaimTypes",
                schema: "dbo.",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Required = table.Column<bool>(type: "bit", nullable: false),
                    IsStatic = table.Column<bool>(type: "bit", nullable: false),
                    Regex = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    RegexDescription = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ValueType = table.Column<int>(type: "int", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_ClaimTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Core_FeatureGroups",
                schema: "dbo.",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_FeatureGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Core_Features",
                schema: "dbo.",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ParentName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DisplayName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    DefaultValue = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    IsVisibleToClients = table.Column<bool>(type: "bit", nullable: false),
                    IsAvailableToHost = table.Column<bool>(type: "bit", nullable: false),
                    AllowedProviders = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ValueType = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_Features", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Core_FeatureValues",
                schema: "dbo.",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    ProviderKey = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_FeatureValues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Core_LinkUsers",
                schema: "dbo.",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SourceUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SourceTenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TargetUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TargetTenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_LinkUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Core_OrganizationUnits",
                schema: "dbo.",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(95)", maxLength: 95, nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    EntityVersion = table.Column<int>(type: "int", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_OrganizationUnits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Core_OrganizationUnits_Core_OrganizationUnits_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "dbo.",
                        principalTable: "Core_OrganizationUnits",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Core_PermissionGrants",
                schema: "dbo.",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_PermissionGrants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Core_PermissionGroups",
                schema: "dbo.",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_PermissionGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Core_Permissions",
                schema: "dbo.",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ParentName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DisplayName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    MultiTenancySide = table.Column<byte>(type: "tinyint", nullable: false),
                    Providers = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    StateCheckers = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_Permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Core_Roles",
                schema: "dbo.",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    IsStatic = table.Column<bool>(type: "bit", nullable: false),
                    IsPublic = table.Column<bool>(type: "bit", nullable: false),
                    EntityVersion = table.Column<int>(type: "int", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Core_SecurityLogs",
                schema: "dbo.",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ApplicationName = table.Column<string>(type: "nvarchar(96)", maxLength: 96, nullable: true),
                    Identity = table.Column<string>(type: "nvarchar(96)", maxLength: 96, nullable: true),
                    Action = table.Column<string>(type: "nvarchar(96)", maxLength: 96, nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    TenantName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    ClientId = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    CorrelationId = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    ClientIpAddress = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    BrowserInfo = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_SecurityLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Core_Sessions",
                schema: "dbo.",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SessionId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Device = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    DeviceInfo = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientId = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    IpAddresses = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    SignedIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastAccessed = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_Sessions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Core_SettingDefinitions",
                schema: "dbo.",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    DefaultValue = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true),
                    IsVisibleToClients = table.Column<bool>(type: "bit", nullable: false),
                    Providers = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    IsInherited = table.Column<bool>(type: "bit", nullable: false),
                    IsEncrypted = table.Column<bool>(type: "bit", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_SettingDefinitions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Core_Settings",
                schema: "dbo.",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false),
                    ProviderName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    ProviderKey = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_Settings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Core_Tenants",
                schema: "dbo.",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    NormalizedName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    EntityVersion = table.Column<int>(type: "int", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_Tenants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Core_UserDelegations",
                schema: "dbo.",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SourceUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TargetUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_UserDelegations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Core_Users",
                schema: "dbo.",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    IsExternal = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    ShouldChangePasswordOnNextLogin = table.Column<bool>(type: "bit", nullable: false),
                    EntityVersion = table.Column<int>(type: "int", nullable: false),
                    LastPasswordChangeTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OpenIddictApplications",
                schema: "dbo.",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ClientId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ClientSecret = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ConsentType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayNames = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JsonWebKeySet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Permissions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostLogoutRedirectUris = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Properties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RedirectUris = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Requirements = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Settings = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientUri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogoUri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenIddictApplications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OpenIddictScopes",
                schema: "dbo.",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descriptions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayNames = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Properties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Resources = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenIddictScopes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Core_AuditLogActions",
                schema: "dbo.",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AuditLogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    MethodName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Parameters = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ExecutionTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExecutionDuration = table.Column<int>(type: "int", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_AuditLogActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Core_AuditLogActions_Core_AuditLogs_AuditLogId",
                        column: x => x.AuditLogId,
                        principalSchema: "dbo.",
                        principalTable: "Core_AuditLogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Core_EntityChanges",
                schema: "dbo.",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AuditLogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ChangeTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ChangeType = table.Column<byte>(type: "tinyint", nullable: false),
                    EntityTenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EntityId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    EntityTypeFullName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_EntityChanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Core_EntityChanges_Core_AuditLogs_AuditLogId",
                        column: x => x.AuditLogId,
                        principalSchema: "dbo.",
                        principalTable: "Core_AuditLogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Core_Blobs",
                schema: "dbo.",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContainerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Content = table.Column<byte[]>(type: "varbinary(max)", maxLength: 2147483647, nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_Blobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Core_Blobs_Core_BlobContainers_ContainerId",
                        column: x => x.ContainerId,
                        principalSchema: "dbo.",
                        principalTable: "Core_BlobContainers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Core_OrganizationUnitRoles",
                schema: "dbo.",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganizationUnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_OrganizationUnitRoles", x => new { x.OrganizationUnitId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_Core_OrganizationUnitRoles_Core_OrganizationUnits_OrganizationUnitId",
                        column: x => x.OrganizationUnitId,
                        principalSchema: "dbo.",
                        principalTable: "Core_OrganizationUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Core_OrganizationUnitRoles_Core_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbo.",
                        principalTable: "Core_Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Core_RoleClaims",
                schema: "dbo.",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ClaimType = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ClaimValue = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Core_RoleClaims_Core_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbo.",
                        principalTable: "Core_Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Core_TenantConnectionStrings",
                schema: "dbo.",
                columns: table => new
                {
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_TenantConnectionStrings", x => new { x.TenantId, x.Name });
                    table.ForeignKey(
                        name: "FK_Core_TenantConnectionStrings_Core_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalSchema: "dbo.",
                        principalTable: "Core_Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Core_UserClaims",
                schema: "dbo.",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ClaimType = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ClaimValue = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Core_UserClaims_Core_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo.",
                        principalTable: "Core_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Core_UserLogins",
                schema: "dbo.",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProviderKey = table.Column<string>(type: "nvarchar(196)", maxLength: 196, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_UserLogins", x => new { x.UserId, x.LoginProvider });
                    table.ForeignKey(
                        name: "FK_Core_UserLogins_Core_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo.",
                        principalTable: "Core_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Core_UserOrganizationUnits",
                schema: "dbo.",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganizationUnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_UserOrganizationUnits", x => new { x.OrganizationUnitId, x.UserId });
                    table.ForeignKey(
                        name: "FK_Core_UserOrganizationUnits_Core_OrganizationUnits_OrganizationUnitId",
                        column: x => x.OrganizationUnitId,
                        principalSchema: "dbo.",
                        principalTable: "Core_OrganizationUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Core_UserOrganizationUnits_Core_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo.",
                        principalTable: "Core_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Core_UserRoles",
                schema: "dbo.",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_Core_UserRoles_Core_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbo.",
                        principalTable: "Core_Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Core_UserRoles_Core_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo.",
                        principalTable: "Core_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Core_UserTokens",
                schema: "dbo.",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_Core_UserTokens_Core_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo.",
                        principalTable: "Core_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OpenIddictAuthorizations",
                schema: "dbo.",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Properties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Scopes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenIddictAuthorizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpenIddictAuthorizations_OpenIddictApplications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalSchema: "dbo.",
                        principalTable: "OpenIddictApplications",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Core_EntityPropertyChanges",
                schema: "dbo.",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EntityChangeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NewValue = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    OriginalValue = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    PropertyName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    PropertyTypeFullName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_EntityPropertyChanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Core_EntityPropertyChanges_Core_EntityChanges_EntityChangeId",
                        column: x => x.EntityChangeId,
                        principalSchema: "dbo.",
                        principalTable: "Core_EntityChanges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OpenIddictTokens",
                schema: "dbo.",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AuthorizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Payload = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Properties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RedemptionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReferenceId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenIddictTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpenIddictTokens_OpenIddictApplications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalSchema: "dbo.",
                        principalTable: "OpenIddictApplications",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OpenIddictTokens_OpenIddictAuthorizations_AuthorizationId",
                        column: x => x.AuthorizationId,
                        principalSchema: "dbo.",
                        principalTable: "OpenIddictAuthorizations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Core_AuditLogActions_AuditLogId",
                schema: "dbo.",
                table: "Core_AuditLogActions",
                column: "AuditLogId");

            migrationBuilder.CreateIndex(
                name: "IX_Core_AuditLogActions_TenantId_ServiceName_MethodName_ExecutionTime",
                schema: "dbo.",
                table: "Core_AuditLogActions",
                columns: new[] { "TenantId", "ServiceName", "MethodName", "ExecutionTime" });

            migrationBuilder.CreateIndex(
                name: "IX_Core_AuditLogs_TenantId_ExecutionTime",
                schema: "dbo.",
                table: "Core_AuditLogs",
                columns: new[] { "TenantId", "ExecutionTime" });

            migrationBuilder.CreateIndex(
                name: "IX_Core_AuditLogs_TenantId_UserId_ExecutionTime",
                schema: "dbo.",
                table: "Core_AuditLogs",
                columns: new[] { "TenantId", "UserId", "ExecutionTime" });

            migrationBuilder.CreateIndex(
                name: "IX_Core_BackgroundJobs_IsAbandoned_NextTryTime",
                schema: "dbo.",
                table: "Core_BackgroundJobs",
                columns: new[] { "IsAbandoned", "NextTryTime" });

            migrationBuilder.CreateIndex(
                name: "IX_Core_BlobContainers_TenantId_Name",
                schema: "dbo.",
                table: "Core_BlobContainers",
                columns: new[] { "TenantId", "Name" });

            migrationBuilder.CreateIndex(
                name: "IX_Core_Blobs_ContainerId",
                schema: "dbo.",
                table: "Core_Blobs",
                column: "ContainerId");

            migrationBuilder.CreateIndex(
                name: "IX_Core_Blobs_TenantId_ContainerId_Name",
                schema: "dbo.",
                table: "Core_Blobs",
                columns: new[] { "TenantId", "ContainerId", "Name" });

            migrationBuilder.CreateIndex(
                name: "IX_Core_EntityChanges_AuditLogId",
                schema: "dbo.",
                table: "Core_EntityChanges",
                column: "AuditLogId");

            migrationBuilder.CreateIndex(
                name: "IX_Core_EntityChanges_TenantId_EntityTypeFullName_EntityId",
                schema: "dbo.",
                table: "Core_EntityChanges",
                columns: new[] { "TenantId", "EntityTypeFullName", "EntityId" });

            migrationBuilder.CreateIndex(
                name: "IX_Core_EntityPropertyChanges_EntityChangeId",
                schema: "dbo.",
                table: "Core_EntityPropertyChanges",
                column: "EntityChangeId");

            migrationBuilder.CreateIndex(
                name: "IX_Core_FeatureGroups_Name",
                schema: "dbo.",
                table: "Core_FeatureGroups",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Core_Features_GroupName",
                schema: "dbo.",
                table: "Core_Features",
                column: "GroupName");

            migrationBuilder.CreateIndex(
                name: "IX_Core_Features_Name",
                schema: "dbo.",
                table: "Core_Features",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Core_FeatureValues_Name_ProviderName_ProviderKey",
                schema: "dbo.",
                table: "Core_FeatureValues",
                columns: new[] { "Name", "ProviderName", "ProviderKey" },
                unique: true,
                filter: "[ProviderName] IS NOT NULL AND [ProviderKey] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Core_LinkUsers_SourceUserId_SourceTenantId_TargetUserId_TargetTenantId",
                schema: "dbo.",
                table: "Core_LinkUsers",
                columns: new[] { "SourceUserId", "SourceTenantId", "TargetUserId", "TargetTenantId" },
                unique: true,
                filter: "[SourceTenantId] IS NOT NULL AND [TargetTenantId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Core_OrganizationUnitRoles_RoleId_OrganizationUnitId",
                schema: "dbo.",
                table: "Core_OrganizationUnitRoles",
                columns: new[] { "RoleId", "OrganizationUnitId" });

            migrationBuilder.CreateIndex(
                name: "IX_Core_OrganizationUnits_Code",
                schema: "dbo.",
                table: "Core_OrganizationUnits",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_Core_OrganizationUnits_ParentId",
                schema: "dbo.",
                table: "Core_OrganizationUnits",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Core_PermissionGrants_TenantId_Name_ProviderName_ProviderKey",
                schema: "dbo.",
                table: "Core_PermissionGrants",
                columns: new[] { "TenantId", "Name", "ProviderName", "ProviderKey" },
                unique: true,
                filter: "[TenantId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Core_PermissionGroups_Name",
                schema: "dbo.",
                table: "Core_PermissionGroups",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Core_Permissions_GroupName",
                schema: "dbo.",
                table: "Core_Permissions",
                column: "GroupName");

            migrationBuilder.CreateIndex(
                name: "IX_Core_Permissions_Name",
                schema: "dbo.",
                table: "Core_Permissions",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Core_RoleClaims_RoleId",
                schema: "dbo.",
                table: "Core_RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Core_Roles_NormalizedName",
                schema: "dbo.",
                table: "Core_Roles",
                column: "NormalizedName");

            migrationBuilder.CreateIndex(
                name: "IX_Core_SecurityLogs_TenantId_Action",
                schema: "dbo.",
                table: "Core_SecurityLogs",
                columns: new[] { "TenantId", "Action" });

            migrationBuilder.CreateIndex(
                name: "IX_Core_SecurityLogs_TenantId_ApplicationName",
                schema: "dbo.",
                table: "Core_SecurityLogs",
                columns: new[] { "TenantId", "ApplicationName" });

            migrationBuilder.CreateIndex(
                name: "IX_Core_SecurityLogs_TenantId_Identity",
                schema: "dbo.",
                table: "Core_SecurityLogs",
                columns: new[] { "TenantId", "Identity" });

            migrationBuilder.CreateIndex(
                name: "IX_Core_SecurityLogs_TenantId_UserId",
                schema: "dbo.",
                table: "Core_SecurityLogs",
                columns: new[] { "TenantId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_Core_Sessions_Device",
                schema: "dbo.",
                table: "Core_Sessions",
                column: "Device");

            migrationBuilder.CreateIndex(
                name: "IX_Core_Sessions_SessionId",
                schema: "dbo.",
                table: "Core_Sessions",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Core_Sessions_TenantId_UserId",
                schema: "dbo.",
                table: "Core_Sessions",
                columns: new[] { "TenantId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_Core_SettingDefinitions_Name",
                schema: "dbo.",
                table: "Core_SettingDefinitions",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Core_Settings_Name_ProviderName_ProviderKey",
                schema: "dbo.",
                table: "Core_Settings",
                columns: new[] { "Name", "ProviderName", "ProviderKey" },
                unique: true,
                filter: "[ProviderName] IS NOT NULL AND [ProviderKey] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Core_Tenants_Name",
                schema: "dbo.",
                table: "Core_Tenants",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Core_Tenants_NormalizedName",
                schema: "dbo.",
                table: "Core_Tenants",
                column: "NormalizedName");

            migrationBuilder.CreateIndex(
                name: "IX_Core_UserClaims_UserId",
                schema: "dbo.",
                table: "Core_UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Core_UserLogins_LoginProvider_ProviderKey",
                schema: "dbo.",
                table: "Core_UserLogins",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.CreateIndex(
                name: "IX_Core_UserOrganizationUnits_UserId_OrganizationUnitId",
                schema: "dbo.",
                table: "Core_UserOrganizationUnits",
                columns: new[] { "UserId", "OrganizationUnitId" });

            migrationBuilder.CreateIndex(
                name: "IX_Core_UserRoles_RoleId_UserId",
                schema: "dbo.",
                table: "Core_UserRoles",
                columns: new[] { "RoleId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_Core_Users_Email",
                schema: "dbo.",
                table: "Core_Users",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_Core_Users_NormalizedEmail",
                schema: "dbo.",
                table: "Core_Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Core_Users_NormalizedUserName",
                schema: "dbo.",
                table: "Core_Users",
                column: "NormalizedUserName");

            migrationBuilder.CreateIndex(
                name: "IX_Core_Users_UserName",
                schema: "dbo.",
                table: "Core_Users",
                column: "UserName");

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictApplications_ClientId",
                schema: "dbo.",
                table: "OpenIddictApplications",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictAuthorizations_ApplicationId_Status_Subject_Type",
                schema: "dbo.",
                table: "OpenIddictAuthorizations",
                columns: new[] { "ApplicationId", "Status", "Subject", "Type" });

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictScopes_Name",
                schema: "dbo.",
                table: "OpenIddictScopes",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictTokens_ApplicationId_Status_Subject_Type",
                schema: "dbo.",
                table: "OpenIddictTokens",
                columns: new[] { "ApplicationId", "Status", "Subject", "Type" });

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictTokens_AuthorizationId",
                schema: "dbo.",
                table: "OpenIddictTokens",
                column: "AuthorizationId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictTokens_ReferenceId",
                schema: "dbo.",
                table: "OpenIddictTokens",
                column: "ReferenceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Core_AuditLogActions",
                schema: "dbo.");

            migrationBuilder.DropTable(
                name: "Core_BackgroundJobs",
                schema: "dbo.");

            migrationBuilder.DropTable(
                name: "Core_Blobs",
                schema: "dbo.");

            migrationBuilder.DropTable(
                name: "Core_ClaimTypes",
                schema: "dbo.");

            migrationBuilder.DropTable(
                name: "Core_EntityPropertyChanges",
                schema: "dbo.");

            migrationBuilder.DropTable(
                name: "Core_FeatureGroups",
                schema: "dbo.");

            migrationBuilder.DropTable(
                name: "Core_Features",
                schema: "dbo.");

            migrationBuilder.DropTable(
                name: "Core_FeatureValues",
                schema: "dbo.");

            migrationBuilder.DropTable(
                name: "Core_LinkUsers",
                schema: "dbo.");

            migrationBuilder.DropTable(
                name: "Core_OrganizationUnitRoles",
                schema: "dbo.");

            migrationBuilder.DropTable(
                name: "Core_PermissionGrants",
                schema: "dbo.");

            migrationBuilder.DropTable(
                name: "Core_PermissionGroups",
                schema: "dbo.");

            migrationBuilder.DropTable(
                name: "Core_Permissions",
                schema: "dbo.");

            migrationBuilder.DropTable(
                name: "Core_RoleClaims",
                schema: "dbo.");

            migrationBuilder.DropTable(
                name: "Core_SecurityLogs",
                schema: "dbo.");

            migrationBuilder.DropTable(
                name: "Core_Sessions",
                schema: "dbo.");

            migrationBuilder.DropTable(
                name: "Core_SettingDefinitions",
                schema: "dbo.");

            migrationBuilder.DropTable(
                name: "Core_Settings",
                schema: "dbo.");

            migrationBuilder.DropTable(
                name: "Core_TenantConnectionStrings",
                schema: "dbo.");

            migrationBuilder.DropTable(
                name: "Core_UserClaims",
                schema: "dbo.");

            migrationBuilder.DropTable(
                name: "Core_UserDelegations",
                schema: "dbo.");

            migrationBuilder.DropTable(
                name: "Core_UserLogins",
                schema: "dbo.");

            migrationBuilder.DropTable(
                name: "Core_UserOrganizationUnits",
                schema: "dbo.");

            migrationBuilder.DropTable(
                name: "Core_UserRoles",
                schema: "dbo.");

            migrationBuilder.DropTable(
                name: "Core_UserTokens",
                schema: "dbo.");

            migrationBuilder.DropTable(
                name: "OpenIddictScopes",
                schema: "dbo.");

            migrationBuilder.DropTable(
                name: "OpenIddictTokens",
                schema: "dbo.");

            migrationBuilder.DropTable(
                name: "Core_BlobContainers",
                schema: "dbo.");

            migrationBuilder.DropTable(
                name: "Core_EntityChanges",
                schema: "dbo.");

            migrationBuilder.DropTable(
                name: "Core_Tenants",
                schema: "dbo.");

            migrationBuilder.DropTable(
                name: "Core_OrganizationUnits",
                schema: "dbo.");

            migrationBuilder.DropTable(
                name: "Core_Roles",
                schema: "dbo.");

            migrationBuilder.DropTable(
                name: "Core_Users",
                schema: "dbo.");

            migrationBuilder.DropTable(
                name: "OpenIddictAuthorizations",
                schema: "dbo.");

            migrationBuilder.DropTable(
                name: "Core_AuditLogs",
                schema: "dbo.");

            migrationBuilder.DropTable(
                name: "OpenIddictApplications",
                schema: "dbo.");
        }
    }
}
