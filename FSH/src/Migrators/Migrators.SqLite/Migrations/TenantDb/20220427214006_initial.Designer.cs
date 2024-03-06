﻿// <auto-generated />

using System;
using FSH.Infrastructure.Multitenancy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Migrators.SqLite.Migrations.TenantDb
{
    [DbContext(typeof(TenantDbContext))]
    [Migration("20220427214006_initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.4");

            modelBuilder.Entity("FSH.Infrastructure.Multitenancy.FSHTenantInfo", b =>
            {
                b.Property<string>("Id")
                    .HasMaxLength(64)
                    .HasColumnType("TEXT");

                b.Property<string>("AdminEmail")
                    .IsRequired()
                    .HasColumnType("TEXT");

                b.Property<string>("ConnectionString")
                    .IsRequired()
                    .HasColumnType("TEXT");

                b.Property<string>("Identifier")
                    .IsRequired()
                    .HasColumnType("TEXT");

                b.Property<bool>("IsActive")
                    .HasColumnType("INTEGER");

                b.Property<string>("Issuer")
                    .HasColumnType("TEXT");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasColumnType("TEXT");

                b.Property<DateTime>("ValidUpto")
                    .HasColumnType("TEXT");

                b.HasKey("Id");

                b.HasIndex("Identifier")
                    .IsUnique();

                b.ToTable("Tenants", "MultiTenancy");
            });
#pragma warning restore 612, 618
        }
    }
}