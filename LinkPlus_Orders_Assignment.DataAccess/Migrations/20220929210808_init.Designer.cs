﻿// <auto-generated />
using System;
using LinkPlus_Orders_Assignment.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LinkPlus_Orders_Assignment.DataAccess.Migrations
{
    [DbContext(typeof(OrdersDbContext))]
    [Migration("20220929210808_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("LinkPlus_Orders_Assignment.Domain.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrderName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("OrderPrice")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            OrderDate = new DateTime(2022, 9, 29, 23, 8, 8, 15, DateTimeKind.Local).AddTicks(7906),
                            OrderName = "Order 1",
                            OrderPrice = 250
                        },
                        new
                        {
                            Id = 2,
                            OrderDate = new DateTime(2022, 9, 29, 23, 8, 8, 15, DateTimeKind.Local).AddTicks(7909),
                            OrderName = "Order 2",
                            OrderPrice = 550
                        },
                        new
                        {
                            Id = 3,
                            OrderDate = new DateTime(2022, 9, 29, 23, 8, 8, 15, DateTimeKind.Local).AddTicks(7913),
                            OrderName = "Order 2",
                            OrderPrice = 750
                        });
                });
#pragma warning restore 612, 618
        }
    }
}