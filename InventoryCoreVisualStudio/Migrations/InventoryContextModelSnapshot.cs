﻿// <auto-generated />
using InventoryCoreVisualStudio.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace InventoryCoreVisualStudio.Migrations
{
    [DbContext(typeof(InventoryContext))]
    partial class InventoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("InventoryCoreVisualStudio.Models.Caliber", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("DecimalSize")
                        .HasColumnType("decimal(4,3)");

                    b.Property<string>("MetricSize");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Caliber");
                });

            modelBuilder.Entity("InventoryCoreVisualStudio.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int?>("ParentId");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("InventoryCoreVisualStudio.Models.FiringAction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("FiringAction");
                });

            modelBuilder.Entity("InventoryCoreVisualStudio.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CaliberId");

                    b.Property<int>("CategoryId");

                    b.Property<string>("Color");

                    b.Property<int>("FiringActionId");

                    b.Property<decimal>("ListPrice");

                    b.Property<int>("LocationId");

                    b.Property<int>("ManufacturerId");

                    b.Property<string>("Model");

                    b.Property<string>("Name");

                    b.Property<string>("PartNumber");

                    b.Property<int>("PlatformId");

                    b.Property<DateTime>("PurchaseDate");

                    b.Property<string>("PurchaseFrom");

                    b.Property<decimal>("PurchasePrice");

                    b.Property<int?>("RetailerId");

                    b.Property<string>("SerialNumber");

                    b.Property<DateTime>("SoldDate");

                    b.Property<decimal>("SoldPrice");

                    b.Property<string>("SoldTo");

                    b.Property<decimal>("Weight");

                    b.Property<string>("WeightUnitOfMeasure");

                    b.HasKey("Id");

                    b.HasIndex("CaliberId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("FiringActionId");

                    b.HasIndex("LocationId");

                    b.HasIndex("ManufacturerId");

                    b.HasIndex("PlatformId");

                    b.HasIndex("RetailerId");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("InventoryCoreVisualStudio.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("InventoryCoreVisualStudio.Models.Manufacturer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<string>("Name");

                    b.Property<string>("State");

                    b.Property<string>("Website");

                    b.HasKey("Id");

                    b.ToTable("Manufacturer");
                });

            modelBuilder.Entity("InventoryCoreVisualStudio.Models.Part", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Cost");

                    b.Property<string>("Description");

                    b.Property<int>("ItemId");

                    b.Property<int?>("ManufacturerId");

                    b.Property<string>("Name");

                    b.Property<string>("PartNumber");

                    b.Property<string>("ShortName");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("ManufacturerId");

                    b.ToTable("Part");
                });

            modelBuilder.Entity("InventoryCoreVisualStudio.Models.Platform", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Platform");
                });

            modelBuilder.Entity("InventoryCoreVisualStudio.Models.Retailer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<string>("Name");

                    b.Property<string>("State");

                    b.Property<string>("Website");

                    b.HasKey("Id");

                    b.ToTable("Retailer");
                });

            modelBuilder.Entity("InventoryCoreVisualStudio.Models.Category", b =>
                {
                    b.HasOne("InventoryCoreVisualStudio.Models.Category", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("InventoryCoreVisualStudio.Models.Item", b =>
                {
                    b.HasOne("InventoryCoreVisualStudio.Models.Caliber", "Caliber")
                        .WithMany()
                        .HasForeignKey("CaliberId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("InventoryCoreVisualStudio.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("InventoryCoreVisualStudio.Models.FiringAction", "FiringAction")
                        .WithMany()
                        .HasForeignKey("FiringActionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("InventoryCoreVisualStudio.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("InventoryCoreVisualStudio.Models.Manufacturer", "Manufacturer")
                        .WithMany()
                        .HasForeignKey("ManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("InventoryCoreVisualStudio.Models.Platform", "Platform")
                        .WithMany()
                        .HasForeignKey("PlatformId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("InventoryCoreVisualStudio.Models.Retailer", "Retailer")
                        .WithMany()
                        .HasForeignKey("RetailerId");
                });

            modelBuilder.Entity("InventoryCoreVisualStudio.Models.Part", b =>
                {
                    b.HasOne("InventoryCoreVisualStudio.Models.Item", "Item")
                        .WithMany("Parts")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("InventoryCoreVisualStudio.Models.Manufacturer", "Manufacturer")
                        .WithMany()
                        .HasForeignKey("ManufacturerId");
                });
#pragma warning restore 612, 618
        }
    }
}
