using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrators.MSSQL.Migrations.Tenant;

public partial class InitialMigrations : Migration
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
                Id = table.Column<string>("nvarchar(64)", maxLength: 64, nullable: false),
                Identifier = table.Column<string>("nvarchar(450)", nullable: false),
                Name = table.Column<string>("nvarchar(max)", nullable: false),
                ConnectionString = table.Column<string>("nvarchar(max)", nullable: false),
                AdminEmail = table.Column<string>("nvarchar(max)", nullable: false),
                IsActive = table.Column<bool>("bit", nullable: false),
                ValidUpto = table.Column<DateTime>("datetime2", nullable: false),
                Issuer = table.Column<string>("nvarchar(max)", nullable: true)
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