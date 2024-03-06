using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrators.SqLite.Migrations.TenantDb;

public partial class Initial : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.EnsureSchema(
            "MultiTenancy");

        migrationBuilder.CreateTable(
            "Tenants",
            schema: "MultiTenancy",
            columns: table => new
            {
                Id = table.Column<string>("TEXT", maxLength: 64, nullable: false),
                Identifier = table.Column<string>("TEXT", nullable: false),
                Name = table.Column<string>("TEXT", nullable: false),
                ConnectionString = table.Column<string>("TEXT", nullable: false),
                AdminEmail = table.Column<string>("TEXT", nullable: false),
                IsActive = table.Column<bool>("INTEGER", nullable: false),
                ValidUpto = table.Column<DateTime>("TEXT", nullable: false),
                Issuer = table.Column<string>("TEXT", nullable: true)
            },
            constraints: table => { table.PrimaryKey("PK_Tenants", x => x.Id); });

        migrationBuilder.CreateIndex(
            "IX_Tenants_Identifier",
            schema: "MultiTenancy",
            table: "Tenants",
            column: "Identifier",
            unique: true);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            "Tenants",
            "MultiTenancy");
    }
}