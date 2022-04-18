﻿// <auto-generated />
using System;
using BookStoreWeb.Models.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookStoreWeb.Migrations
{
    [DbContext(typeof(ContextBook))]
    partial class ContextBookModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AutorBook", b =>
                {
                    b.Property<int>("AutorsId")
                        .HasColumnType("int");

                    b.Property<int>("BooksId")
                        .HasColumnType("int");

                    b.HasKey("AutorsId", "BooksId");

                    b.HasIndex("BooksId");

                    b.ToTable("AutorBook");
                });

            modelBuilder.Entity("BookGenre", b =>
                {
                    b.Property<int>("BooksId")
                        .HasColumnType("int");

                    b.Property<int>("GenresId")
                        .HasColumnType("int");

                    b.HasKey("BooksId", "GenresId");

                    b.HasIndex("GenresId");

                    b.ToTable("BookGenre");
                });

            modelBuilder.Entity("BookStoreWeb.Models.Data.Autor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Biography")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsReader")
                        .HasColumnType("bit");

                    b.Property<string>("Secondname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Autors");
                });

            modelBuilder.Entity("BookStoreWeb.Models.Data.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Annotation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Autor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Img")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsFavorite")
                        .HasColumnType("bit");

                    b.Property<int?>("StockId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("StockId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("BookStoreWeb.Models.Data.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("BookStoreWeb.Models.Data.Stock", b =>
                {
                    b.Property<int>("StockId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StockId"), 1L, 1);

                    b.Property<int>("CountBook")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.HasKey("StockId");

                    b.ToTable("Stocks");
                });

            modelBuilder.Entity("AutorBook", b =>
                {
                    b.HasOne("BookStoreWeb.Models.Data.Autor", null)
                        .WithMany()
                        .HasForeignKey("AutorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookStoreWeb.Models.Data.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookGenre", b =>
                {
                    b.HasOne("BookStoreWeb.Models.Data.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookStoreWeb.Models.Data.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookStoreWeb.Models.Data.Book", b =>
                {
                    b.HasOne("BookStoreWeb.Models.Data.Stock", null)
                        .WithMany("Books")
                        .HasForeignKey("StockId");
                });

            modelBuilder.Entity("BookStoreWeb.Models.Data.Stock", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
