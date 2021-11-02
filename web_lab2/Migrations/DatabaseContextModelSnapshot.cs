﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using web_lab2.Models;

namespace web_lab2.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BookSage", b =>
                {
                    b.Property<int>("BooksId")
                        .HasColumnType("int");

                    b.Property<int>("SagesId")
                        .HasColumnType("int");

                    b.HasKey("BooksId", "SagesId");

                    b.HasIndex("SagesId");

                    b.ToTable("SageBook");
                });

            modelBuilder.Entity("web_lab2.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("web_lab2.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Customer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrderNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("web_lab2.Models.OrdersBooks", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.HasKey("OrderId", "BookId");

                    b.HasIndex("BookId");

                    b.ToTable("OrdersBooks");
                });

            modelBuilder.Entity("web_lab2.Models.Sage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Photo")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("Sages");
                });

            modelBuilder.Entity("BookSage", b =>
                {
                    b.HasOne("web_lab2.Models.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("web_lab2.Models.Sage", null)
                        .WithMany()
                        .HasForeignKey("SagesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("web_lab2.Models.OrdersBooks", b =>
                {
                    b.HasOne("web_lab2.Models.Book", "Book")
                        .WithMany("OrdersDetails")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("web_lab2.Models.Order", "Order")
                        .WithMany("OrdersDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("web_lab2.Models.Book", b =>
                {
                    b.Navigation("OrdersDetails");
                });

            modelBuilder.Entity("web_lab2.Models.Order", b =>
                {
                    b.Navigation("OrdersDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
