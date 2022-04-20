using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCartEF2.Data;
using ShoppingCartEF4.Repositories;
using System.IO;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddCustomerTest()
        {
            var context = CreateDbContext();
            var customerRepo = new CustomerRepository(context);
            var customer = customerRepo.Add("FirstName", "LastName", "Early-Adopters", 2, "123 Any Street", "Bourbon", "Texas", "USA");
            Assert.IsNotNull(customer);
            Assert.IsTrue(customer.Id > 0);
        }

        public ShoppingCartDS CreateDbContext()
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