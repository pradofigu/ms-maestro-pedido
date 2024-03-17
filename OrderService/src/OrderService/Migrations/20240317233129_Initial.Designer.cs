﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using OrderService.Databases;

#nullable disable

namespace OrderService.Migrations
{
    [DbContext(typeof(OrderDbContext))]
    [Migration("20240317233129_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("OrderService.Domain.OrderItems.OrderItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text")
                        .HasColumnName("created_by");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_on");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text")
                        .HasColumnName("last_modified_by");

                    b.Property<DateTimeOffset?>("LastModifiedOn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("last_modified_on");

                    b.Property<Guid?>("OrderId")
                        .HasColumnType("uuid")
                        .HasColumnName("order_id");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer")
                        .HasColumnName("quantity");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("numeric")
                        .HasColumnName("total_price");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("numeric")
                        .HasColumnName("unit_price");

                    b.HasKey("Id")
                        .HasName("pk_order_items");

                    b.HasIndex("OrderId")
                        .HasDatabaseName("ix_order_items_order_id");

                    b.ToTable("order_items", (string)null);
                });

            modelBuilder.Entity("OrderService.Domain.OrderPayments.OrderPayment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("CVV")
                        .HasColumnType("text")
                        .HasColumnName("cvv");

                    b.Property<string>("CardHolderName")
                        .HasColumnType("text")
                        .HasColumnName("card_holder_name");

                    b.Property<string>("CardNumber")
                        .HasColumnType("text")
                        .HasColumnName("card_number");

                    b.Property<string>("CardToken")
                        .HasColumnType("text")
                        .HasColumnName("card_token");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text")
                        .HasColumnName("created_by");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_on");

                    b.Property<string>("Currency")
                        .HasColumnType("text")
                        .HasColumnName("currency");

                    b.Property<string>("ExpiryDate")
                        .HasColumnType("text")
                        .HasColumnName("expiry_date");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text")
                        .HasColumnName("last_modified_by");

                    b.Property<DateTimeOffset?>("LastModifiedOn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("last_modified_on");

                    b.Property<string>("Method")
                        .HasColumnType("text")
                        .HasColumnName("method");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uuid")
                        .HasColumnName("order_id");

                    b.Property<string>("Status")
                        .HasColumnType("text")
                        .HasColumnName("status");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("numeric")
                        .HasColumnName("total_amount");

                    b.Property<Guid>("TransactionId")
                        .HasColumnType("uuid")
                        .HasColumnName("transaction_id");

                    b.HasKey("Id")
                        .HasName("pk_order_payments");

                    b.ToTable("order_payments", (string)null);
                });

            modelBuilder.Entity("OrderService.Domain.Orders.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("CorrelationId")
                        .HasColumnType("uuid")
                        .HasColumnName("correlation_id");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text")
                        .HasColumnName("created_by");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_on");

                    b.Property<string>("CustomerNotes")
                        .HasColumnType("text")
                        .HasColumnName("customer_notes");

                    b.Property<string>("DiscountCode")
                        .HasColumnType("text")
                        .HasColumnName("discount_code");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text")
                        .HasColumnName("last_modified_by");

                    b.Property<DateTimeOffset?>("LastModifiedOn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("last_modified_on");

                    b.Property<int>("Number")
                        .HasColumnType("integer")
                        .HasColumnName("number");

                    b.Property<string>("Status")
                        .HasColumnType("text")
                        .HasColumnName("status");

                    b.HasKey("Id")
                        .HasName("pk_orders");

                    b.ToTable("orders", (string)null);
                });

            modelBuilder.Entity("OrderService.Domain.OrderItems.OrderItem", b =>
                {
                    b.HasOne("OrderService.Domain.Orders.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("fk_order_items_orders_order_id");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("OrderService.Domain.Orders.Order", b =>
                {
                    b.HasOne("OrderService.Domain.OrderPayments.OrderPayment", "OrderPayment")
                        .WithOne("Order")
                        .HasForeignKey("OrderService.Domain.Orders.Order", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_orders_order_payments_id");

                    b.Navigation("OrderPayment");
                });

            modelBuilder.Entity("OrderService.Domain.OrderPayments.OrderPayment", b =>
                {
                    b.Navigation("Order");
                });

            modelBuilder.Entity("OrderService.Domain.Orders.Order", b =>
                {
                    b.Navigation("OrderItems");
                });
#pragma warning restore 612, 618
        }
    }
}