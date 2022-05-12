﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShoppingCartEF2.Data;

#nullable disable

namespace ShoppingCartMigrations.Migrations
{
    [DbContext(typeof(ShoppingCartDS))]
    [Migration("20220511045846_BorrowedBookActual")]
    partial class BorrowedBookActual
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Shopping")
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("Schema Version", "3.2");

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ShoppingCartEF2.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("InternationStandardBookNumber");

                    b.Property<string>("Name")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("OnLoanLibraryId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("PrimaryLibraryId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("PurchasePrice");

                    b.HasKey("Id");

                    b.HasAlternateKey("ISBN");

                    b.HasIndex("Name");

                    b.HasIndex("OnLoanLibraryId");

                    b.HasIndex("PrimaryLibraryId");

                    b.ToTable("LibaryBooks", "Shopping");
                });

            modelBuilder.Entity("ShoppingCartEF2.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CreditDays")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(30);

                    b.Property<decimal>("CreditLimit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("CreditScore")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreditScoreDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("CustomerBudget")
                        .HasColumnType("decimal(18,6)");

                    b.Property<string>("CustomerGroup")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CustomerTypeId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(1);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(2);

                    b.HasKey("Id");

                    b.HasIndex("CustomerTypeId");

                    b.ToTable("Customers", "Shopping");
                });

            modelBuilder.Entity("ShoppingCartEF2.Entities.Library", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("LibraryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Libaries", "Shopping");
                });

            modelBuilder.Entity("ShoppingCartEF2.Entities.Note", b =>
                {
                    b.Property<int>("NoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Note_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NoteId"), 1L, 1);

                    b.Property<DateTime>("LastUpdated")
                        .HasPrecision(3)
                        .HasColumnType("datetime2(3)");

                    b.Property<string>("NoteText")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<decimal>("Score")
                        .HasPrecision(14, 2)
                        .HasColumnType("decimal(14,2)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasColumnName("UrlSmall")
                        .HasComment("The URL of the web page the note is about");

                    b.HasKey("NoteId");

                    b.ToTable("CustomerNotes", "dbo");
                });

            modelBuilder.Entity("ShoppingCartEF2.Entities.Order", b =>
                {
                    b.Property<string>("OrderId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PackageIndex")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PackagePrefix")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrderId");

                    b.ToTable("Orders", "Shopping");
                });

            modelBuilder.Entity("ShoppingCartEF2.Entities.Part", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("ListPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("PartName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Parts", "Shopping", t => t.ExcludeFromMigrations());
                });

            modelBuilder.Entity("ShoppingCartEF3.Entities.CustomerAddress", b =>
                {
                    b.Property<int>("CustomerAddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerAddressId"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AddressOfCustomerId")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerAddressId");

                    b.HasIndex("AddressOfCustomerId")
                        .IsUnique();

                    b.ToTable("CustomerAddress", "Shopping");
                });

            modelBuilder.Entity("ShoppingCartEF3.Entities.CustomerBook", b =>
                {
                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<DateTime>("LoanDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.HasKey("CustomerId", "BookId");

                    b.HasIndex("BookId");

                    b.ToTable("CustomerBook", "Shopping");
                });

            modelBuilder.Entity("ShoppingCartEF3.Entities.CustomerSearchResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CustomSearchResults", "Shopping");
                });

            modelBuilder.Entity("ShoppingCartEF3.Entities.CustomerType", b =>
                {
                    b.Property<int>("CustomerTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerTypeID"), 1L, 1);

                    b.Property<string>("CustomerTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerTypeID");

                    b.ToTable("CustomerType", "Shopping");
                });

            modelBuilder.Entity("ShoppingCartEF2.Entities.Book", b =>
                {
                    b.HasOne("ShoppingCartEF2.Entities.Library", "OnLoanLibrary")
                        .WithMany("BooksOnLoan")
                        .HasForeignKey("OnLoanLibraryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShoppingCartEF2.Entities.Library", "PrimaryLibrary")
                        .WithMany("PrimaryBooks")
                        .HasForeignKey("PrimaryLibraryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OnLoanLibrary");

                    b.Navigation("PrimaryLibrary");
                });

            modelBuilder.Entity("ShoppingCartEF2.Entities.Customer", b =>
                {
                    b.HasOne("ShoppingCartEF3.Entities.CustomerType", "CustomerType")
                        .WithMany("Customers")
                        .HasForeignKey("CustomerTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CustomerType");
                });

            modelBuilder.Entity("ShoppingCartEF3.Entities.CustomerAddress", b =>
                {
                    b.HasOne("ShoppingCartEF2.Entities.Customer", "Customer")
                        .WithOne("Address")
                        .HasForeignKey("ShoppingCartEF3.Entities.CustomerAddress", "AddressOfCustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("ShoppingCartEF3.Entities.CustomerBook", b =>
                {
                    b.HasOne("ShoppingCartEF2.Entities.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShoppingCartEF2.Entities.Customer", "Customer")
                        .WithMany("BorrowedBooks")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("ShoppingCartEF2.Entities.Customer", b =>
                {
                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("BorrowedBooks");
                });

            modelBuilder.Entity("ShoppingCartEF2.Entities.Library", b =>
                {
                    b.Navigation("BooksOnLoan");

                    b.Navigation("PrimaryBooks");
                });

            modelBuilder.Entity("ShoppingCartEF3.Entities.CustomerType", b =>
                {
                    b.Navigation("Customers");
                });
#pragma warning restore 612, 618
        }
    }
}
