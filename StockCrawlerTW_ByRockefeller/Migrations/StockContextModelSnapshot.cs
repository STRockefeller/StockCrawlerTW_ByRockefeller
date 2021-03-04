﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StockCrawlerTW_ByRockefeller;

namespace StockCrawlerTW_ByRockefeller.Migrations
{
    [DbContext(typeof(StockContext))]
    partial class StockContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.3");

            modelBuilder.Entity("StockCrawlerTW_ByRockefeller.Stock", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("PERatio")
                        .HasColumnType("TEXT");

                    b.Property<string>("closingPrice")
                        .HasColumnType("TEXT");

                    b.Property<string>("codeName")
                        .HasColumnType("TEXT");

                    b.Property<string>("marketValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("maxPrice")
                        .HasColumnType("TEXT");

                    b.Property<string>("minPrice")
                        .HasColumnType("TEXT");

                    b.Property<string>("openingPrice")
                        .HasColumnType("TEXT");

                    b.Property<string>("spread")
                        .HasColumnType("TEXT");

                    b.Property<string>("stockId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("tradingDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("tradingMoney")
                        .HasColumnType("TEXT");

                    b.Property<string>("tradingTurnover")
                        .HasColumnType("TEXT");

                    b.Property<string>("tradingVolume")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("stocks");
                });
#pragma warning restore 612, 618
        }
    }
}
