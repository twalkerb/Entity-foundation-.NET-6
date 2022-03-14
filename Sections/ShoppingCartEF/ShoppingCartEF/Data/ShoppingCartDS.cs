using Microsoft.EntityFrameworkCore;
using ShoppingCartEF.Entities;
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
        public ShoppingCartDS()
        {
            _connectionString = "Data Source = DevOne; Initial Catalog = ShoppingCartDev; integrated security = True; ";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
     => options.UseSqlServer(_connectionString);
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Part>()
                .ToTable("Parts", t => t.ExcludeFromMigrations());
        }

    }
}
