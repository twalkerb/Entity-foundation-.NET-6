using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ShoppingCartEF2.Entities;
using ShoppingCartEF2.Generator;
using ShoppingCartEF3.Entities;
using ShoppingCartEF6.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartEF2.Data
{
    public class ShoppingCartDS : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Library> Libaries { get; set; }
        public DbSet<vwCustomerGroupBorrowedBook> vwCustomerGroupBorrowedBooks { get; set; }


        // raw Sql Support
        public DbSet<CustomerSearchResult> CustomSearchResults { get; set; }

        private string _connectionString = "";

        public ShoppingCartDS(DbContextOptions<ShoppingCartDS> options, string connectionString) : base(options)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
             => options
                .UseSqlServer(_connectionString, b => b.MigrationsAssembly("ShoppingCartMigrations6"))
                .ReplaceService<IMigrationsSqlGenerator, ShoppingMigrationSqlGenerator>();
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Part>()
                .ToTable("Parts", t => t.ExcludeFromMigrations());

            //Configure default schema
            modelBuilder.HasDefaultSchema("Shopping");


            // model wide annotation applied in Db
            modelBuilder
                .HasAnnotation("Schema Version", "3.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            //Map entity to table
            modelBuilder.Entity<Book>().ToTable("LibaryBooks");

            //Override the Data Annotations for Note table name, move to dbo schema
            modelBuilder.Entity<Note>().ToTable("CustomerNotes", "dbo");


            // alternate key - book ISBN needed
            modelBuilder.Entity<Book>().HasAlternateKey("ISBN");

            // Additional index on book name
            modelBuilder.Entity<Book>().HasIndex("Name");

            modelBuilder.Entity<Book>()
                .Property(b => b.ISBN).HasColumnName("InternationStandardBookNumber")
                .HasColumnType("varchar")
                .HasMaxLength(10);

            // nullability
            modelBuilder.Entity<Customer>()
            .Property(b => b.CreditScore).IsRequired(false);

            // default value
            modelBuilder.Entity<Customer>()
            .Property(b => b.CreditDays).HasDefaultValue(30);

            modelBuilder.Entity<Book>().Property(b => b.Name).IsRowVersion();
            //modelBuilder.Entity<Book>().Property(b => b.Name).IsConcurrencyToken(true);


            // one-to-one
            modelBuilder.Entity<Customer>()
                       .HasOne<CustomerAddress>(s => s.Address)
                       .WithOne(ad => ad.Customer)
                       .HasForeignKey<CustomerAddress>(ad => ad.AddressOfCustomerId);

            // one-to-many
            modelBuilder.Entity<Customer>()
            .HasOne<CustomerType>(s => s.CustomerType)
            .WithMany(g => g.Customers)
            .HasForeignKey(s => s.CustomerTypeId);

            // many-to-many
            // the foreign keys must be the composite primary key in the joining table.
            // This can only be configured using Fluent API
            modelBuilder.Entity<CustomerBook>().HasKey(cb => new { cb.CustomerId, cb.BookId });

            modelBuilder.Entity<vwCustomerGroupBorrowedBook>()
                .ToView(nameof(vwCustomerGroupBorrowedBooks))
                .HasKey(t => t.InternationStandardBookNumber);
        }

    }
}
