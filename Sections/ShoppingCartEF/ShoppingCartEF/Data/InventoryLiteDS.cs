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
    public class InventoryLiteDS : DbContext
    {
        public DbSet<Part> Parts { get; set; }
        private string _connectionString = "";
        public InventoryLiteDS(DbContextOptions<InventoryLiteDS> options, string connectionString) : base(options)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options
                .UseSqlite(_connectionString, b => b.MigrationsAssembly("ShoppingCartMigrations"))
                .ReplaceService<IMigrationsSqlGenerator, ShoppingMigrationSqlGenerator>();
        }
    }
}
