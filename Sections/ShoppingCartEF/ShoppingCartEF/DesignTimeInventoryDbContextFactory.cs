using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using ShoppingCartEF.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartEF
{
    public class DesignTimeInventoryDbContextFactory :
           IDesignTimeDbContextFactory<InventoryLiteDS>
    {

        public InventoryLiteDS CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("InventoryConnection");

            var builder = new DbContextOptionsBuilder<InventoryLiteDS>();
            builder.UseSqlite(connectionString);

            return new InventoryLiteDS(builder.Options, connectionString);


        }
    }
}
