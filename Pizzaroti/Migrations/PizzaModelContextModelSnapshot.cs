﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pizzaroti.Data;

#nullable disable

namespace Pizzaroti.Migrations
{
    [DbContext(typeof(PizzaModelContext))]
    partial class PizzaModelContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Pizzaroti.Models.PizzaOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PizzaName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("PizzaPrice")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("PizzaOrders");
                });

            modelBuilder.Entity("Pizzaroti.Models.PizzasModel", b =>
                {
                    b.Property<int>("PizzaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PizzaId"), 1L, 1);

                    b.Property<float>("BasePrice")
                        .HasColumnType("real");

                    b.Property<bool>("Beef")
                        .HasColumnType("bit");

                    b.Property<bool>("Cheese")
                        .HasColumnType("bit");

                    b.Property<bool>("Chicken")
                        .HasColumnType("bit");

                    b.Property<float>("FinalPrice")
                        .HasColumnType("real");

                    b.Property<bool>("Ham")
                        .HasColumnType("bit");

                    b.Property<string>("ImageTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Mushroom")
                        .HasColumnType("bit");

                    b.Property<bool>("Peperoni")
                        .HasColumnType("bit");

                    b.Property<bool>("Pineapple")
                        .HasColumnType("bit");

                    b.Property<string>("PizzaName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TomatoSauce")
                        .HasColumnType("bit");

                    b.Property<bool>("Tuna")
                        .HasColumnType("bit");

                    b.HasKey("PizzaId");

                    b.ToTable("PizzaModel");
                });

            modelBuilder.Entity("Pizzaroti.Models.TransactionModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PizzaName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PizzaPrice")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("TrxRef")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
