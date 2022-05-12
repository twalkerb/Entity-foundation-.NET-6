using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCartEF2.Data;
using ShoppingCartEF4.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    [TestClass]
    public class IQueryableTests
    {

        [TestMethod]
        public void FindExpressionTreeTests()
        {
            var context = CreateDbContext();
            var customerRepo = new CustomerRepository(context);
            var firstName = "FirstName";
            var lastName = "LastName";

            var itemsIQuerable = customerRepo.FindQ(firstName, lastName);
            var exprTree = itemsIQuerable.Expression;
            var exprTreeText = exprTree.ToString();

        }

        [TestMethod]
        public void InsertForVolumeTests()
        {
            var rowCountDesired = 200;
            var context = CreateDbContext();
            var customerRepo = new CustomerRepository(context);

            var rowCount = customerRepo.Count();
            for (int i = rowCount; i < rowCountDesired; i++)
            {
                var firstName = "FirstName-" + DateTime.Now.ToString();
                var lastName = "LastName" + DateTime.Now.ToString();

                var customer = customerRepo.Add(firstName, lastName, "Early-Adopters", 2, "123 Any Street", "Bourbon", "Texas", "USA");
                Assert.IsNotNull(customer);
                Assert.IsTrue(customer.Id > 0);
            }
            rowCount = customerRepo.Count();
            Assert.IsTrue(rowCount >= rowCountDesired);
        }

        [TestMethod]
        public void FindVolumeTests()
        {
            var context = CreateDbContext();
            var customerRepo = new CustomerRepository(context);
            var firstName = "FirstName";
            var lastName = "LastName";

            var startTime = DateTime.Now;
            var itemsIEnumberable = customerRepo.Find(firstName, lastName).ToList();
            var startEndTime = DateTime.Now;
            var itemsIQuerable = customerRepo.FindQ(firstName, lastName).ToList();
            var endTime = DateTime.Now;

            var ienumTime = startEndTime.Subtract(startTime);
            var iqueryTime = endTime.Subtract(startEndTime);
            Assert.IsTrue(ienumTime > iqueryTime);

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
