﻿// <auto-generated />
using System;
using Cashbox.MVVM.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Cashbox.Migrations
{
    [DbContext(typeof(CashBoxDataContext))]
    [Migration("20240208161118_initSQLite")]
    partial class initSQLite
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Cashbox.MVVM.Models.AuthHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Datetime")
                        .HasColumnType("datetime")
                        .HasColumnName("datetime");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AuthHistory", (string)null);
                });

            modelBuilder.Entity("Cashbox.MVVM.Models.AutoDreport", b =>
                {
                    b.Property<int>("DailyReportId")
                        .HasColumnType("int")
                        .HasColumnName("daily_report_id");

                    b.Property<double>("AutoProceeds")
                        .HasColumnType("float")
                        .HasColumnName("auto_proceeds");

                    b.Property<double>("Award")
                        .HasColumnType("float")
                        .HasColumnName("award");

                    b.Property<double>("Forfeit")
                        .HasColumnType("float")
                        .HasColumnName("forfeit");

                    b.Property<double>("Salary")
                        .HasColumnType("float")
                        .HasColumnName("salary");

                    b.HasKey("DailyReportId");

                    b.ToTable("AutoDReport", (string)null);
                });

            modelBuilder.Entity("Cashbox.MVVM.Models.DailyReport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<TimeOnly>("CloseTime")
                        .HasColumnType("time")
                        .HasColumnName("close_time");

                    b.Property<DateOnly>("Data")
                        .HasColumnType("date")
                        .HasColumnName("data");

                    b.Property<TimeOnly>("OpenTime")
                        .HasColumnType("time")
                        .HasColumnName("open_time");

                    b.Property<double>("Proceeds")
                        .HasColumnType("float")
                        .HasColumnName("proceeds");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("DailyReport", (string)null);
                });

            modelBuilder.Entity("Cashbox.MVVM.Models.MoneyBox", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Money")
                        .HasColumnType("float")
                        .HasColumnName("money");

                    b.HasKey("Id");

                    b.ToTable("MoneyBox", (string)null);
                });

            modelBuilder.Entity("Cashbox.MVVM.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Discount")
                        .HasColumnType("float")
                        .HasColumnName("discount");

                    b.Property<int>("PaymentMethodId")
                        .HasColumnType("int")
                        .HasColumnName("payment_method_id");

                    b.Property<double>("SellCost")
                        .HasColumnType("float")
                        .HasColumnName("sell_cost");

                    b.Property<DateTime>("SellDatetime")
                        .HasColumnType("datetime")
                        .HasColumnName("sell_datetime");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("PaymentMethodId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Cashbox.MVVM.Models.OrderProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("int")
                        .HasColumnName("amount");

                    b.Property<int>("OrderId")
                        .HasColumnType("int")
                        .HasColumnName("order_id");

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("product_id");

                    b.Property<double>("PurchaseСost")
                        .HasColumnType("float")
                        .HasColumnName("purchase_сost");

                    b.Property<double>("SellCost")
                        .HasColumnType("float")
                        .HasColumnName("sell_cost");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderProduct", (string)null);
                });

            modelBuilder.Entity("Cashbox.MVVM.Models.PaymentMethod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Method")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("method");

                    b.HasKey("Id");

                    b.ToTable("PaymentMethod", (string)null);
                });

            modelBuilder.Entity("Cashbox.MVVM.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ArticulCode")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("articul_code");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("brand");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("category_id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("description");

                    b.Property<byte[]>("Image")
                        .HasColumnType("image")
                        .HasColumnName("image");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<double>("PurchaseСost")
                        .HasColumnType("float")
                        .HasColumnName("purchase_сost");

                    b.Property<double>("SellCost")
                        .HasColumnType("float")
                        .HasColumnName("sell_cost");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("Cashbox.MVVM.Models.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("category");

                    b.HasKey("Id");

                    b.ToTable("ProductCategory", (string)null);
                });

            modelBuilder.Entity("Cashbox.MVVM.Models.Refund", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("BuyDate")
                        .HasColumnType("date")
                        .HasColumnName("buy_date");

                    b.Property<bool>("IsPurchased")
                        .HasColumnType("bit")
                        .HasColumnName("isPurchased");

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("product_id");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("reason");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Refund", (string)null);
                });

            modelBuilder.Entity("Cashbox.MVVM.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Role1")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("role");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Cashbox.MVVM.Models.Stock", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("product_id");

                    b.Property<int>("Amount")
                        .HasColumnType("int")
                        .HasColumnName("amount");

                    b.HasKey("ProductId");

                    b.ToTable("Stock", (string)null);
                });

            modelBuilder.Entity("Cashbox.MVVM.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("login");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("password");

                    b.Property<int>("Pin")
                        .HasColumnType("int")
                        .HasColumnName("pin");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Cashbox.MVVM.Models.UserInfo", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("isActive");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("location");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.Property<string>("Patronymic")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("patronymic");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("phone");

                    b.Property<int>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("role_id");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("surname");

                    b.HasKey("UserId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserInfo", (string)null);
                });

            modelBuilder.Entity("Cashbox.MVVM.Models.AuthHistory", b =>
                {
                    b.HasOne("Cashbox.MVVM.Models.User", "User")
                        .WithMany("AuthHistories")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_AuthHistory_Users");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Cashbox.MVVM.Models.AutoDreport", b =>
                {
                    b.HasOne("Cashbox.MVVM.Models.DailyReport", "DailyReport")
                        .WithOne("AutoDreport")
                        .HasForeignKey("Cashbox.MVVM.Models.AutoDreport", "DailyReportId")
                        .IsRequired()
                        .HasConstraintName("FK_AutoDReport_DailyReport");

                    b.Navigation("DailyReport");
                });

            modelBuilder.Entity("Cashbox.MVVM.Models.DailyReport", b =>
                {
                    b.HasOne("Cashbox.MVVM.Models.User", "User")
                        .WithMany("DailyReports")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_DailyReport_Users");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Cashbox.MVVM.Models.Order", b =>
                {
                    b.HasOne("Cashbox.MVVM.Models.PaymentMethod", "PaymentMethod")
                        .WithMany("Orders")
                        .HasForeignKey("PaymentMethodId")
                        .IsRequired()
                        .HasConstraintName("FK_Orders_PaymentMethod");

                    b.HasOne("Cashbox.MVVM.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_Orders_Users");

                    b.Navigation("PaymentMethod");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Cashbox.MVVM.Models.OrderProduct", b =>
                {
                    b.HasOne("Cashbox.MVVM.Models.Order", "Order")
                        .WithMany("OrderProducts")
                        .HasForeignKey("OrderId")
                        .IsRequired()
                        .HasConstraintName("FK_OrderProduct_Orders");

                    b.HasOne("Cashbox.MVVM.Models.Product", "Product")
                        .WithMany("OrderProducts")
                        .HasForeignKey("ProductId")
                        .IsRequired()
                        .HasConstraintName("FK_OrderProduct_Product");

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Cashbox.MVVM.Models.Product", b =>
                {
                    b.HasOne("Cashbox.MVVM.Models.ProductCategory", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .IsRequired()
                        .HasConstraintName("FK_Product_ProductCategory");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Cashbox.MVVM.Models.Refund", b =>
                {
                    b.HasOne("Cashbox.MVVM.Models.Product", "Product")
                        .WithMany("Refunds")
                        .HasForeignKey("ProductId")
                        .IsRequired()
                        .HasConstraintName("FK_Refund_Product");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Cashbox.MVVM.Models.Stock", b =>
                {
                    b.HasOne("Cashbox.MVVM.Models.Product", "Product")
                        .WithOne("Stock")
                        .HasForeignKey("Cashbox.MVVM.Models.Stock", "ProductId")
                        .IsRequired()
                        .HasConstraintName("FK_Stock_Product");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Cashbox.MVVM.Models.UserInfo", b =>
                {
                    b.HasOne("Cashbox.MVVM.Models.Role", "Role")
                        .WithMany("UserInfos")
                        .HasForeignKey("RoleId")
                        .IsRequired()
                        .HasConstraintName("FK_UserInfo_Roles");

                    b.HasOne("Cashbox.MVVM.Models.User", "User")
                        .WithOne("UserInfo")
                        .HasForeignKey("Cashbox.MVVM.Models.UserInfo", "UserId")
                        .IsRequired()
                        .HasConstraintName("FK_UserInfo_Users");

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Cashbox.MVVM.Models.DailyReport", b =>
                {
                    b.Navigation("AutoDreport");
                });

            modelBuilder.Entity("Cashbox.MVVM.Models.Order", b =>
                {
                    b.Navigation("OrderProducts");
                });

            modelBuilder.Entity("Cashbox.MVVM.Models.PaymentMethod", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Cashbox.MVVM.Models.Product", b =>
                {
                    b.Navigation("OrderProducts");

                    b.Navigation("Refunds");

                    b.Navigation("Stock");
                });

            modelBuilder.Entity("Cashbox.MVVM.Models.ProductCategory", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Cashbox.MVVM.Models.Role", b =>
                {
                    b.Navigation("UserInfos");
                });

            modelBuilder.Entity("Cashbox.MVVM.Models.User", b =>
                {
                    b.Navigation("AuthHistories");

                    b.Navigation("DailyReports");

                    b.Navigation("Orders");

                    b.Navigation("UserInfo");
                });
#pragma warning restore 612, 618
        }
    }
}