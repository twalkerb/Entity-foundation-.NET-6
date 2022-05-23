using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShoppingCartBusinessServices.BusinessObjects;
using ShoppingCartEF2.Data;
using ShoppingCartEF4.Repositories;

namespace ShoppingCartBusinessServices
{
    public class ShoppingCartService
    {
        ShoppingCartDS _dbContext;

        public ShoppingCartService()
        {

            _dbContext = CreateDbContext();

        }

        public CustomerBO GetCustomer(string custFirst, string custLast)
        {
            var custRepo = new CustomerRepository(_dbContext);

            var custDataObject = custRepo.Find(custFirst, custLast);
            return new CustomerBO( custDataObject.First());

        }

        private ShoppingCartDS CreateDbContext()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var builder = new DbContextOptionsBuilder<ShoppingCartDS>();
            builder.UseSqlServer(connectionString);

            return new ShoppingCartDS(builder.Options, connectionString);
        }

    }
}