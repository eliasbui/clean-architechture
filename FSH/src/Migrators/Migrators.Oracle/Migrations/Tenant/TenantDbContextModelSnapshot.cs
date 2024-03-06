﻿// <auto-generated />

using System;
using FSH.Infrastructure.Multitenancy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace Migrators.Oracle.Migrations.Tenant
{
    [DbContext(typeof(TenantDbContext))]
    partial class TenantDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FSH.Infrastructure.Multitenancy.FSHTenantInfo", b =>
            {
                b.Property<string>("Id")
                    .HasMaxLength(64)
                    .HasColumnType("NVARCHAR2(64)");

                b.Property<string>("AdminEmail")
                    .IsRequired()
                    .HasColumnType("NVARCHAR2(2000)");

                b.Property<string>("ConnectionString")
                    .IsRequired()
                    .HasColumnType("NVARCHAR2(2000)");

                b.Property<string>("Identifier")
                    .IsRequired()
                    .HasColumnType("NVARCHAR2(450)");

                b.Property<bool>("IsActive")
                    .HasColumnType("NUMBER(1)");

                b.Property<string>("Issuer")
                    .HasColumnType("NVARCHAR2(2000)");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasColumnType("NVARCHAR2(2000)");

                b.Property<DateTime>("ValidUpto")
                    .HasColumnType("TIMESTAMP(7)");

                b.HasKey("Id");

                b.HasIndex("Identifier")
                    .IsUnique();

                b.ToTable("Tenants", "MULTITENANCY");
            });
#pragma warning restore 612, 618
        }
    }
}