using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrators.Oracle.Migrations.Application;

public partial class Initial : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.EnsureSchema(
            "AUDITING");

        migrationBuilder.EnsureSchema(
            "CATALOG");

        migrationBuilder.EnsureSchema(
            "IDENTITY");

        migrationBuilder.CreateTable(
            "AuditTrails",
            schema: "AUDITING",
            columns: table => new
            {
                Id = table.Column<Guid>("RAW(16)", nullable: false),
                UserId = table.Column<Guid>("RAW(16)", nullable: false),
                Type = table.Column<string>("NVARCHAR2(2000)", nullable: true),
                TableName = table.Column<string>("NVARCHAR2(2000)", nullable: true),
                DateTime = table.Column<DateTime>("TIMESTAMP(7)", nullable: false),
                OldValues = table.Column<string>("NVARCHAR2(2000)", nullable: true),
                NewValues = table.Column<string>("NVARCHAR2(2000)", nullable: true),
                AffectedColumns = table.Column<string>("NVARCHAR2(2000)", nullable: true),
                PrimaryKey = table.Column<string>("NVARCHAR2(2000)", nullable: true),
                TenantId = table.Column<string>("NVARCHAR2(64)", maxLength: 64, nullable: false)
            },
            constraints: table => { table.PrimaryKey("PK_AuditTrails", x => x.Id); });

        migrationBuilder.CreateTable(
            "Brands",
            schema: "CATALOG",
            columns: table => new
            {
                Id = table.Column<Guid>("RAW(16)", nullable: false),
                Name = table.Column<string>("NVARCHAR2(256)", maxLength: 256, nullable: false),
                Description = table.Column<string>("NVARCHAR2(2000)", nullable: true),
                TenantId = table.Column<string>("NVARCHAR2(64)", maxLength: 64, nullable: false),
                CreatedBy = table.Column<Guid>("RAW(16)", nullable: false),
                CreatedOn = table.Column<DateTime>("TIMESTAMP(7)", nullable: false),
                LastModifiedBy = table.Column<Guid>("RAW(16)", nullable: false),
                LastModifiedOn = table.Column<DateTime>("TIMESTAMP(7)", nullable: true),
                DeletedOn = table.Column<DateTime>("TIMESTAMP(7)", nullable: true),
                DeletedBy = table.Column<Guid>("RAW(16)", nullable: true)
            },
            constraints: table => { table.PrimaryKey("PK_Brands", x => x.Id); });

        migrationBuilder.CreateTable(
            "Roles",
            schema: "IDENTITY",
            columns: table => new
            {
                Id = table.Column<string>("NVARCHAR2(450)", nullable: false),
                Description = table.Column<string>("NVARCHAR2(2000)", nullable: true),
                TenantId = table.Column<string>("NVARCHAR2(64)", maxLength: 64, nullable: false),
                Name = table.Column<string>("NVARCHAR2(256)", maxLength: 256, nullable: true),
                NormalizedName = table.Column<string>("NVARCHAR2(256)", maxLength: 256, nullable: true),
                ConcurrencyStamp = table.Column<string>("NVARCHAR2(2000)", nullable: true)
            },
            constraints: table => { table.PrimaryKey("PK_Roles", x => x.Id); });

        migrationBuilder.CreateTable(
            "Users",
            schema: "IDENTITY",
            columns: table => new
            {
                Id = table.Column<string>("NVARCHAR2(450)", nullable: false),
                FirstName = table.Column<string>("NVARCHAR2(2000)", nullable: true),
                LastName = table.Column<string>("NVARCHAR2(2000)", nullable: true),
                ImageUrl = table.Column<string>("NVARCHAR2(2000)", nullable: true),
                IsActive = table.Column<bool>("NUMBER(1)", nullable: false),
                RefreshToken = table.Column<string>("NVARCHAR2(2000)", nullable: true),
                RefreshTokenExpiryTime = table.Column<DateTime>("TIMESTAMP(7)", nullable: false),
                ObjectId = table.Column<string>("NVARCHAR2(256)", maxLength: 256, nullable: true),
                TenantId = table.Column<string>("NVARCHAR2(64)", maxLength: 64, nullable: false),
                UserName = table.Column<string>("NVARCHAR2(256)", maxLength: 256, nullable: true),
                NormalizedUserName = table.Column<string>("NVARCHAR2(256)", maxLength: 256, nullable: true),
                Email = table.Column<string>("NVARCHAR2(256)", maxLength: 256, nullable: true),
                NormalizedEmail = table.Column<string>("NVARCHAR2(256)", maxLength: 256, nullable: true),
                EmailConfirmed = table.Column<bool>("NUMBER(1)", nullable: false),
                PasswordHash = table.Column<string>("NVARCHAR2(2000)", nullable: true),
                SecurityStamp = table.Column<string>("NVARCHAR2(2000)", nullable: true),
                ConcurrencyStamp = table.Column<string>("NVARCHAR2(2000)", nullable: true),
                PhoneNumber = table.Column<string>("NVARCHAR2(2000)", nullable: true),
                PhoneNumberConfirmed = table.Column<bool>("NUMBER(1)", nullable: false),
                TwoFactorEnabled = table.Column<bool>("NUMBER(1)", nullable: false),
                LockoutEnd = table.Column<DateTimeOffset>("TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                LockoutEnabled = table.Column<bool>("NUMBER(1)", nullable: false),
                AccessFailedCount = table.Column<int>("NUMBER(10)", nullable: false)
            },
            constraints: table => { table.PrimaryKey("PK_Users", x => x.Id); });

        migrationBuilder.CreateTable(
            "Products",
            schema: "CATALOG",
            columns: table => new
            {
                Id = table.Column<Guid>("RAW(16)", nullable: false),
                Name = table.Column<string>("NVARCHAR2(1024)", maxLength: 1024, nullable: false),
                Description = table.Column<string>("NVARCHAR2(2000)", nullable: true),
                Rate = table.Column<decimal>("DECIMAL(18, 2)", nullable: false),
                ImagePath = table.Column<string>("NCLOB", maxLength: 2048, nullable: true),
                BrandId = table.Column<Guid>("RAW(16)", nullable: false),
                TenantId = table.Column<string>("NVARCHAR2(64)", maxLength: 64, nullable: false),
                CreatedBy = table.Column<Guid>("RAW(16)", nullable: false),
                CreatedOn = table.Column<DateTime>("TIMESTAMP(7)", nullable: false),
                LastModifiedBy = table.Column<Guid>("RAW(16)", nullable: false),
                LastModifiedOn = table.Column<DateTime>("TIMESTAMP(7)", nullable: true),
                DeletedOn = table.Column<DateTime>("TIMESTAMP(7)", nullable: true),
                DeletedBy = table.Column<Guid>("RAW(16)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Products", x => x.Id);
                table.ForeignKey(
                    "FK_Products_Brands_BrandId",
                    x => x.BrandId,
                    principalSchema: "CATALOG",
                    principalTable: "Brands",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            "RoleClaims",
            schema: "IDENTITY",
            columns: table => new
            {
                Id = table.Column<int>("NUMBER(10)", nullable: false)
                    .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                Description = table.Column<string>("NVARCHAR2(2000)", nullable: true),
                Group = table.Column<string>("NVARCHAR2(2000)", nullable: true),
                CreatedBy = table.Column<string>("NVARCHAR2(2000)", nullable: true),
                CreatedOn = table.Column<DateTime>("TIMESTAMP(7)", nullable: false),
                LastModifiedBy = table.Column<string>("NVARCHAR2(2000)", nullable: true),
                LastModifiedOn = table.Column<DateTime>("TIMESTAMP(7)", nullable: true),
                TenantId = table.Column<string>("NVARCHAR2(64)", maxLength: 64, nullable: false),
                RoleId = table.Column<string>("NVARCHAR2(450)", nullable: false),
                ClaimType = table.Column<string>("NVARCHAR2(2000)", nullable: true),
                ClaimValue = table.Column<string>("NVARCHAR2(2000)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_RoleClaims", x => x.Id);
                table.ForeignKey(
                    "FK_RoleClaims_Roles_RoleId",
                    x => x.RoleId,
                    principalSchema: "IDENTITY",
                    principalTable: "Roles",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            "UserClaims",
            schema: "IDENTITY",
            columns: table => new
            {
                Id = table.Column<int>("NUMBER(10)", nullable: false)
                    .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                UserId = table.Column<string>("NVARCHAR2(450)", nullable: false),
                ClaimType = table.Column<string>("NVARCHAR2(2000)", nullable: true),
                ClaimValue = table.Column<string>("NVARCHAR2(2000)", nullable: true),
                TenantId = table.Column<string>("NVARCHAR2(64)", maxLength: 64, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_UserClaims", x => x.Id);
                table.ForeignKey(
                    "FK_UserClaims_Users_UserId",
                    x => x.UserId,
                    principalSchema: "IDENTITY",
                    principalTable: "Users",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            "UserLogins",
            schema: "IDENTITY",
            columns: table => new
            {
                Id = table.Column<string>("NVARCHAR2(450)", nullable: false),
                LoginProvider = table.Column<string>("NVARCHAR2(450)", nullable: false),
                ProviderKey = table.Column<string>("NVARCHAR2(450)", nullable: false),
                ProviderDisplayName = table.Column<string>("NVARCHAR2(2000)", nullable: true),
                UserId = table.Column<string>("NVARCHAR2(450)", nullable: false),
                TenantId = table.Column<string>("NVARCHAR2(64)", maxLength: 64, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_UserLogins", x => x.Id);
                table.ForeignKey(
                    "FK_UserLogins_Users_UserId",
                    x => x.UserId,
                    principalSchema: "IDENTITY",
                    principalTable: "Users",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            "UserRoles",
            schema: "IDENTITY",
            columns: table => new
            {
                UserId = table.Column<string>("NVARCHAR2(450)", nullable: false),
                RoleId = table.Column<string>("NVARCHAR2(450)", nullable: false),
                TenantId = table.Column<string>("NVARCHAR2(64)", maxLength: 64, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                table.ForeignKey(
                    "FK_UserRoles_Roles_RoleId",
                    x => x.RoleId,
                    principalSchema: "IDENTITY",
                    principalTable: "Roles",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    "FK_UserRoles_Users_UserId",
                    x => x.UserId,
                    principalSchema: "IDENTITY",
                    principalTable: "Users",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            "UserTokens",
            schema: "IDENTITY",
            columns: table => new
            {
                UserId = table.Column<string>("NVARCHAR2(450)", nullable: false),
                LoginProvider = table.Column<string>("NVARCHAR2(450)", nullable: false),
                Name = table.Column<string>("NVARCHAR2(450)", nullable: false),
                Value = table.Column<string>("NVARCHAR2(2000)", nullable: true),
                TenantId = table.Column<string>("NVARCHAR2(64)", maxLength: 64, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                table.ForeignKey(
                    "FK_UserTokens_Users_UserId",
                    x => x.UserId,
                    principalSchema: "IDENTITY",
                    principalTable: "Users",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            "IX_Products_BrandId",
            schema: "CATALOG",
            table: "Products",
            column: "BrandId");

        migrationBuilder.CreateIndex(
            "IX_RoleClaims_RoleId",
            schema: "IDENTITY",
            table: "RoleClaims",
            column: "RoleId");

        migrationBuilder.CreateIndex(
            "RoleNameIndex",
            schema: "IDENTITY",
            table: "Roles",
            columns: new[] { "NormalizedName", "TenantId" },
            unique: true,
            filter: "\"NormalizedName\" IS NOT NULL");

        migrationBuilder.CreateIndex(
            "IX_UserClaims_UserId",
            schema: "IDENTITY",
            table: "UserClaims",
            column: "UserId");

        migrationBuilder.CreateIndex(
            "IX_UserLogins_LoginProvider_ProviderKey_TenantId",
            schema: "IDENTITY",
            table: "UserLogins",
            columns: new[] { "LoginProvider", "ProviderKey", "TenantId" },
            unique: true);

        migrationBuilder.CreateIndex(
            "IX_UserLogins_UserId",
            schema: "IDENTITY",
            table: "UserLogins",
            column: "UserId");

        migrationBuilder.CreateIndex(
            "IX_UserRoles_RoleId",
            schema: "IDENTITY",
            table: "UserRoles",
            column: "RoleId");

        migrationBuilder.CreateIndex(
            "EmailIndex",
            schema: "IDENTITY",
            table: "Users",
            column: "NormalizedEmail");

        migrationBuilder.CreateIndex(
            "UserNameIndex",
            schema: "IDENTITY",
            table: "Users",
            columns: new[] { "NormalizedUserName", "TenantId" },
            unique: true,
            filter: "\"NormalizedUserName\" IS NOT NULL");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            "AuditTrails",
            "AUDITING");

        migrationBuilder.DropTable(
            "Products",
            "CATALOG");

        migrationBuilder.DropTable(
            "RoleClaims",
            "IDENTITY");

        migrationBuilder.DropTable(
            "UserClaims",
            "IDENTITY");

        migrationBuilder.DropTable(
            "UserLogins",
            "IDENTITY");

        migrationBuilder.DropTable(
            "UserRoles",
            "IDENTITY");

        migrationBuilder.DropTable(
            "UserTokens",
            "IDENTITY");

        migrationBuilder.DropTable(
            "Brands",
            "CATALOG");

        migrationBuilder.DropTable(
            "Roles",
            "IDENTITY");

        migrationBuilder.DropTable(
            "Users",
            "IDENTITY");
    }
}