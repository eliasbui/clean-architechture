using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrators.MSSQL.Migrations.Application;

public partial class InitialMigrations : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.EnsureSchema(
            "Auditing");

        migrationBuilder.EnsureSchema(
            "Catalog");

        migrationBuilder.EnsureSchema(
            "Identity");

        migrationBuilder.CreateTable(
            "AuditTrails",
            schema: "Auditing",
            columns: table => new
            {
                Id = table.Column<Guid>("uniqueidentifier", nullable: false),
                UserId = table.Column<Guid>("uniqueidentifier", nullable: false),
                Type = table.Column<string>("nvarchar(max)", nullable: true),
                TableName = table.Column<string>("nvarchar(max)", nullable: true),
                DateTime = table.Column<DateTime>("datetime2", nullable: false),
                OldValues = table.Column<string>("nvarchar(max)", nullable: true),
                NewValues = table.Column<string>("nvarchar(max)", nullable: true),
                AffectedColumns = table.Column<string>("nvarchar(max)", nullable: true),
                PrimaryKey = table.Column<string>("nvarchar(max)", nullable: true),
                TenantId = table.Column<string>("nvarchar(64)", maxLength: 64, nullable: false)
            },
            constraints: table => { table.PrimaryKey("PK_AuditTrails", x => x.Id); });

        migrationBuilder.CreateTable(
            "Brands",
            schema: "Catalog",
            columns: table => new
            {
                Id = table.Column<Guid>("uniqueidentifier", nullable: false),
                Name = table.Column<string>("nvarchar(256)", maxLength: 256, nullable: false),
                Description = table.Column<string>("nvarchar(max)", nullable: true),
                TenantId = table.Column<string>("nvarchar(64)", maxLength: 64, nullable: false),
                CreatedBy = table.Column<Guid>("uniqueidentifier", nullable: false),
                CreatedOn = table.Column<DateTime>("datetime2", nullable: false),
                LastModifiedBy = table.Column<Guid>("uniqueidentifier", nullable: false),
                LastModifiedOn = table.Column<DateTime>("datetime2", nullable: true),
                DeletedOn = table.Column<DateTime>("datetime2", nullable: true),
                DeletedBy = table.Column<Guid>("uniqueidentifier", nullable: true)
            },
            constraints: table => { table.PrimaryKey("PK_Brands", x => x.Id); });

        migrationBuilder.CreateTable(
            "Roles",
            schema: "Identity",
            columns: table => new
            {
                Id = table.Column<string>("nvarchar(450)", nullable: false),
                Description = table.Column<string>("nvarchar(max)", nullable: true),
                TenantId = table.Column<string>("nvarchar(64)", maxLength: 64, nullable: false),
                Name = table.Column<string>("nvarchar(256)", maxLength: 256, nullable: true),
                NormalizedName = table.Column<string>("nvarchar(256)", maxLength: 256, nullable: true),
                ConcurrencyStamp = table.Column<string>("nvarchar(max)", nullable: true)
            },
            constraints: table => { table.PrimaryKey("PK_Roles", x => x.Id); });

        migrationBuilder.CreateTable(
            "Users",
            schema: "Identity",
            columns: table => new
            {
                Id = table.Column<string>("nvarchar(450)", nullable: false),
                FirstName = table.Column<string>("nvarchar(max)", nullable: true),
                LastName = table.Column<string>("nvarchar(max)", nullable: true),
                ImageUrl = table.Column<string>("nvarchar(max)", nullable: true),
                IsActive = table.Column<bool>("bit", nullable: false),
                RefreshToken = table.Column<string>("nvarchar(max)", nullable: true),
                RefreshTokenExpiryTime = table.Column<DateTime>("datetime2", nullable: false),
                ObjectId = table.Column<string>("nvarchar(256)", maxLength: 256, nullable: true),
                TenantId = table.Column<string>("nvarchar(64)", maxLength: 64, nullable: false),
                UserName = table.Column<string>("nvarchar(256)", maxLength: 256, nullable: true),
                NormalizedUserName = table.Column<string>("nvarchar(256)", maxLength: 256, nullable: true),
                Email = table.Column<string>("nvarchar(256)", maxLength: 256, nullable: true),
                NormalizedEmail = table.Column<string>("nvarchar(256)", maxLength: 256, nullable: true),
                EmailConfirmed = table.Column<bool>("bit", nullable: false),
                PasswordHash = table.Column<string>("nvarchar(max)", nullable: true),
                SecurityStamp = table.Column<string>("nvarchar(max)", nullable: true),
                ConcurrencyStamp = table.Column<string>("nvarchar(max)", nullable: true),
                PhoneNumber = table.Column<string>("nvarchar(max)", nullable: true),
                PhoneNumberConfirmed = table.Column<bool>("bit", nullable: false),
                TwoFactorEnabled = table.Column<bool>("bit", nullable: false),
                LockoutEnd = table.Column<DateTimeOffset>("datetimeoffset", nullable: true),
                LockoutEnabled = table.Column<bool>("bit", nullable: false),
                AccessFailedCount = table.Column<int>("int", nullable: false)
            },
            constraints: table => { table.PrimaryKey("PK_Users", x => x.Id); });

        migrationBuilder.CreateTable(
            "Products",
            schema: "Catalog",
            columns: table => new
            {
                Id = table.Column<Guid>("uniqueidentifier", nullable: false),
                Name = table.Column<string>("nvarchar(1024)", maxLength: 1024, nullable: false),
                Description = table.Column<string>("nvarchar(max)", nullable: true),
                Rate = table.Column<decimal>("decimal(18,2)", nullable: false),
                ImagePath = table.Column<string>("nvarchar(2048)", maxLength: 2048, nullable: true),
                BrandId = table.Column<Guid>("uniqueidentifier", nullable: false),
                TenantId = table.Column<string>("nvarchar(64)", maxLength: 64, nullable: false),
                CreatedBy = table.Column<Guid>("uniqueidentifier", nullable: false),
                CreatedOn = table.Column<DateTime>("datetime2", nullable: false),
                LastModifiedBy = table.Column<Guid>("uniqueidentifier", nullable: false),
                LastModifiedOn = table.Column<DateTime>("datetime2", nullable: true),
                DeletedOn = table.Column<DateTime>("datetime2", nullable: true),
                DeletedBy = table.Column<Guid>("uniqueidentifier", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Products", x => x.Id);
                table.ForeignKey(
                    "FK_Products_Brands_BrandId",
                    x => x.BrandId,
                    principalSchema: "Catalog",
                    principalTable: "Brands",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            "RoleClaims",
            schema: "Identity",
            columns: table => new
            {
                Id = table.Column<int>("int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Description = table.Column<string>("nvarchar(max)", nullable: true),
                Group = table.Column<string>("nvarchar(max)", nullable: true),
                CreatedBy = table.Column<string>("nvarchar(max)", nullable: true),
                CreatedOn = table.Column<DateTime>("datetime2", nullable: false),
                LastModifiedBy = table.Column<string>("nvarchar(max)", nullable: true),
                LastModifiedOn = table.Column<DateTime>("datetime2", nullable: true),
                TenantId = table.Column<string>("nvarchar(64)", maxLength: 64, nullable: false),
                RoleId = table.Column<string>("nvarchar(450)", nullable: false),
                ClaimType = table.Column<string>("nvarchar(max)", nullable: true),
                ClaimValue = table.Column<string>("nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_RoleClaims", x => x.Id);
                table.ForeignKey(
                    "FK_RoleClaims_Roles_RoleId",
                    x => x.RoleId,
                    principalSchema: "Identity",
                    principalTable: "Roles",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            "UserClaims",
            schema: "Identity",
            columns: table => new
            {
                Id = table.Column<int>("int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                UserId = table.Column<string>("nvarchar(450)", nullable: false),
                ClaimType = table.Column<string>("nvarchar(max)", nullable: true),
                ClaimValue = table.Column<string>("nvarchar(max)", nullable: true),
                TenantId = table.Column<string>("nvarchar(64)", maxLength: 64, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_UserClaims", x => x.Id);
                table.ForeignKey(
                    "FK_UserClaims_Users_UserId",
                    x => x.UserId,
                    principalSchema: "Identity",
                    principalTable: "Users",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            "UserLogins",
            schema: "Identity",
            columns: table => new
            {
                Id = table.Column<string>("nvarchar(450)", nullable: false),
                LoginProvider = table.Column<string>("nvarchar(450)", nullable: false),
                ProviderKey = table.Column<string>("nvarchar(450)", nullable: false),
                ProviderDisplayName = table.Column<string>("nvarchar(max)", nullable: true),
                UserId = table.Column<string>("nvarchar(450)", nullable: false),
                TenantId = table.Column<string>("nvarchar(64)", maxLength: 64, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_UserLogins", x => x.Id);
                table.ForeignKey(
                    "FK_UserLogins_Users_UserId",
                    x => x.UserId,
                    principalSchema: "Identity",
                    principalTable: "Users",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            "UserRoles",
            schema: "Identity",
            columns: table => new
            {
                UserId = table.Column<string>("nvarchar(450)", nullable: false),
                RoleId = table.Column<string>("nvarchar(450)", nullable: false),
                TenantId = table.Column<string>("nvarchar(64)", maxLength: 64, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                table.ForeignKey(
                    "FK_UserRoles_Roles_RoleId",
                    x => x.RoleId,
                    principalSchema: "Identity",
                    principalTable: "Roles",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    "FK_UserRoles_Users_UserId",
                    x => x.UserId,
                    principalSchema: "Identity",
                    principalTable: "Users",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            "UserTokens",
            schema: "Identity",
            columns: table => new
            {
                UserId = table.Column<string>("nvarchar(450)", nullable: false),
                LoginProvider = table.Column<string>("nvarchar(450)", nullable: false),
                Name = table.Column<string>("nvarchar(450)", nullable: false),
                Value = table.Column<string>("nvarchar(max)", nullable: true),
                TenantId = table.Column<string>("nvarchar(64)", maxLength: 64, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                table.ForeignKey(
                    "FK_UserTokens_Users_UserId",
                    x => x.UserId,
                    principalSchema: "Identity",
                    principalTable: "Users",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            "IX_Products_BrandId",
            schema: "Catalog",
            table: "Products",
            column: "BrandId");

        migrationBuilder.CreateIndex(
            "IX_RoleClaims_RoleId",
            schema: "Identity",
            table: "RoleClaims",
            column: "RoleId");

        migrationBuilder.CreateIndex(
            "RoleNameIndex",
            schema: "Identity",
            table: "Roles",
            columns: new[] { "NormalizedName", "TenantId" },
            unique: true,
            filter: "[NormalizedName] IS NOT NULL");

        migrationBuilder.CreateIndex(
            "IX_UserClaims_UserId",
            schema: "Identity",
            table: "UserClaims",
            column: "UserId");

        migrationBuilder.CreateIndex(
            "IX_UserLogins_LoginProvider_ProviderKey_TenantId",
            schema: "Identity",
            table: "UserLogins",
            columns: new[] { "LoginProvider", "ProviderKey", "TenantId" },
            unique: true);

        migrationBuilder.CreateIndex(
            "IX_UserLogins_UserId",
            schema: "Identity",
            table: "UserLogins",
            column: "UserId");

        migrationBuilder.CreateIndex(
            "IX_UserRoles_RoleId",
            schema: "Identity",
            table: "UserRoles",
            column: "RoleId");

        migrationBuilder.CreateIndex(
            "EmailIndex",
            schema: "Identity",
            table: "Users",
            column: "NormalizedEmail");

        migrationBuilder.CreateIndex(
            "UserNameIndex",
            schema: "Identity",
            table: "Users",
            columns: new[] { "NormalizedUserName", "TenantId" },
            unique: true,
            filter: "[NormalizedUserName] IS NOT NULL");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            "AuditTrails",
            "Auditing");

        migrationBuilder.DropTable(
            "Products",
            "Catalog");

        migrationBuilder.DropTable(
            "RoleClaims",
            "Identity");

        migrationBuilder.DropTable(
            "UserClaims",
            "Identity");

        migrationBuilder.DropTable(
            "UserLogins",
            "Identity");

        migrationBuilder.DropTable(
            "UserRoles",
            "Identity");

        migrationBuilder.DropTable(
            "UserTokens",
            "Identity");

        migrationBuilder.DropTable(
            "Brands",
            "Catalog");

        migrationBuilder.DropTable(
            "Roles",
            "Identity");

        migrationBuilder.DropTable(
            "Users",
            "Identity");
    }
}