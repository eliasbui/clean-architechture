using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrators.MySQL.Migrations.Application;

/// <inheritdoc />
public partial class _202436_fixapplication : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            "Description",
            schema: "Identity",
            table: "RoleClaims");

        migrationBuilder.DropColumn(
            "Group",
            schema: "Identity",
            table: "RoleClaims");

        migrationBuilder.DropColumn(
            "LastModifiedBy",
            schema: "Identity",
            table: "RoleClaims");

        migrationBuilder.DropColumn(
            "LastModifiedOn",
            schema: "Identity",
            table: "RoleClaims");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<string>(
                "Description",
                schema: "Identity",
                table: "RoleClaims",
                type: "longtext",
                nullable: true)
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.AddColumn<string>(
                "Group",
                schema: "Identity",
                table: "RoleClaims",
                type: "longtext",
                nullable: true)
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.AddColumn<string>(
                "LastModifiedBy",
                schema: "Identity",
                table: "RoleClaims",
                type: "longtext",
                nullable: true)
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.AddColumn<DateTime>(
            "LastModifiedOn",
            schema: "Identity",
            table: "RoleClaims",
            type: "datetime(6)",
            nullable: true);
    }
}