using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using ShoppingCartEF.Entities;
using ShoppingCartEF.Generator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartEF.Data
{
    public class ShoppingCartDS : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Part> Parts { get; set; }

        private string _connectionString = "";

        public ShoppingCartDS(DbContextOptions<ShoppingCartDS> options, string connectionString) : base(options)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
             => options
                .UseSqlServer(_connectionString, b => b.MigrationsAssembly("ShoppingCartMigrations2"))
                .ReplaceService<IMigrationsSqlGenerator, ShoppingMigrationSqlGenerator>();
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Part>()
                .ToTable("Parts", t => t.ExcludeFromMigrations());
        }

    }
}
