using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using EFCore6Demo.DataServices.ShoppingCart.Models;

namespace EFCore6Demo.DataServices.ShoppingCart.Data
{
    public partial class ShoppingCartContext : DbContext
    {
        public ShoppingCartContext()
        {
        }

        public ShoppingCartContext(DbContextOptions<ShoppingCartContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CustomSearchResult> CustomSearchResults { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<CustomerAddress> CustomerAddresses { get; set; } = null!;
        public virtual DbSet<CustomerBook> CustomerBooks { get; set; } = null!;
        public virtual DbSet<CustomerNote> CustomerNotes { get; set; } = null!;
        public virtual DbSet<CustomerType> CustomerTypes { get; set; } = null!;
        public virtual DbSet<Libary> Libaries { get; set; } = null!;
        public virtual DbSet<LibaryBook> LibaryBooks { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<VwCustomerGroupBorrowedBook> VwCustomerGroupBorrowedBooks { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DevOne;Initial Catalog=ShoppingCartDev;integrated security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CreditDays).HasDefaultValueSql("((30))");

                entity.Property(e => e.CreditScoreDate).HasDefaultValueSql("('0001-01-01T00:00:00.0000000')");
            });

            modelBuilder.Entity<CustomerBook>(entity =>
            {
                entity.HasKey(e => new { e.CustomerId, e.BookId });
            });

            modelBuilder.Entity<CustomerNote>(entity =>
            {
                entity.Property(e => e.UrlSmall).HasComment("The URL of the web page the note is about");
            });

            modelBuilder.Entity<LibaryBook>(entity =>
            {
                entity.HasOne(d => d.OnLoanLibrary)
                    .WithMany(p => p.LibaryBookOnLoanLibraries)
                    .HasForeignKey(d => d.OnLoanLibraryId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.PrimaryLibrary)
                    .WithMany(p => p.LibaryBookPrimaryLibraries)
                    .HasForeignKey(d => d.PrimaryLibraryId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.CustomerName).HasDefaultValueSql("(N'')");
            });

            modelBuilder.Entity<VwCustomerGroupBorrowedBook>(entity =>
            {
                entity.ToView("vwCustomerGroupBorrowedBooks");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
