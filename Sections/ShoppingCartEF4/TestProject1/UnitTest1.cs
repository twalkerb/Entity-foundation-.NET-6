using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCartEF2.Data;
using ShoppingCartEF4.Repositories;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

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

        [TestMethod]
        public void GetCustomerTest()
        {
            var context = CreateDbContext();
            var customerRepo = new CustomerRepository(context);
            var customer = customerRepo.Get(5);
            Assert.IsNotNull(customer);
            Assert.IsTrue(customer.Id > 0);
        }


        [TestMethod]
        public async Task GetCustomerTestAsync()
        {
            var context = CreateDbContext();
            var customerRepo = new CustomerRepository(context);
            var customer = await customerRepo.GetAsync(5);
            Assert.IsNotNull(customer);
            Assert.IsTrue(customer.Id > 0);
        }

        [TestMethod]
        public void GetAllCustomerTest()
        {
            var context = CreateDbContext();
            var customerRepo = new CustomerRepository(context);
            var customers = customerRepo.GetAll();

            Assert.IsNotNull(customers);
            Assert.IsTrue(customers.Count() > 0);
        }

        [TestMethod]
        public void FindCustomerTest()
        {
            var context = CreateDbContext();
            var customerRepo = new CustomerRepository(context);
            var customer = customerRepo.Find("FirstName", "LastName");
            Assert.IsNotNull(customer);
        }

        [TestMethod]
        public async Task FindCustomerTestAsync()
        {
            var context = CreateDbContext();
            var customerRepo = new CustomerRepository(context);
            var customer = await customerRepo.FindAsync("FirstName", "LastName");
            Assert.IsNotNull(customer);
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