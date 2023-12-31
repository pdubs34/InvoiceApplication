﻿// <auto-generated />
using System;
using InvoiceApplication.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InvoiceApplication.Migrations
{
    [DbContext(typeof(InvoiceApplicationContext))]
    [Migration("20231114025333_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("InvoiceApplication.Models.DayData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Precipitation")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("Retail")
                        .HasColumnType("double");

                    b.Property<string>("Temp")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("DayData");
                });

            modelBuilder.Entity("InvoiceApplication.Models.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("InvoiceDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("InvoiceNum")
                        .HasColumnType("int");

                    b.Property<int>("StoreId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StoreId");

                    b.ToTable("Invoice");
                });

            modelBuilder.Entity("InvoiceApplication.Models.InvoiceItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("InvoiceId")
                        .HasColumnType("int");

                    b.Property<int?>("InvoiceId1")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId");

                    b.HasIndex("InvoiceId1");

                    b.HasIndex("ItemId");

                    b.ToTable("InvoiceItem");
                });

            modelBuilder.Entity("InvoiceApplication.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("StoreCode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("InvoiceApplication.Models.Store", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Store");
                });

            modelBuilder.Entity("InvoiceApplication.Models.Invoice", b =>
                {
                    b.HasOne("InvoiceApplication.Models.Store", "Store")
                        .WithMany()
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Store");
                });

            modelBuilder.Entity("InvoiceApplication.Models.InvoiceItem", b =>
                {
                    b.HasOne("InvoiceApplication.Models.Invoice", null)
                        .WithMany("DeliveredItems")
                        .HasForeignKey("InvoiceId");

                    b.HasOne("InvoiceApplication.Models.Invoice", null)
                        .WithMany("ReturnedItems")
                        .HasForeignKey("InvoiceId1");

                    b.HasOne("InvoiceApplication.Models.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");
                });

            modelBuilder.Entity("InvoiceApplication.Models.Invoice", b =>
                {
                    b.Navigation("DeliveredItems");

                    b.Navigation("ReturnedItems");
                });
#pragma warning restore 612, 618
        }
    }
}
