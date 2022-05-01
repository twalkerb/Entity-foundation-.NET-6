using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCartEF2.Data;
using ShoppingCartEF2.Entities;
using ShoppingCartEF4.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            var customers = customerRepo.Find("FirstName", "LastName");
            Assert.IsNotNull(customers);

            foreach(var cust in customers)
            {

            }
        }


        [TestMethod]
        public void ListCustomerTest()
        {
            var context = CreateDbContext();
            var customerRepo = new CustomerRepository(context);
            var customers = customerRepo.List("FirstName", "LastName");
            Assert.IsNotNull(customers);
            foreach(var customer in customers)
            {
                Assert.IsNotNull(customer.Address);
                Assert.IsNotNull(customer.CustomerType);
            }
        }

        [TestMethod]
        public async Task ListCustomerTestAsync()
        {
            var context = CreateDbContext();
            var customerRepo = new CustomerRepository(context);
            var customers = await customerRepo.ListAsync("FirstName", "LastName");
            Assert.IsNotNull(customers);
            foreach (var customer in customers)
            {
                Assert.IsNotNull(customer.Address);
                Assert.IsNotNull(customer.CustomerType);
            }
        }

        [TestMethod]
        public async Task FindCustomerTestAsync()
        {
            var context = CreateDbContext();
            var customerRepo = new CustomerRepository(context);
            var customer = await customerRepo.FindAsync("FirstName", "LastName");
            Assert.IsNotNull(customer);
        }

        [TestMethod]
        public void UpdateCustomerTest()
        {
            var context = CreateDbContext();
            var customerRepo = new CustomerRepository(context);
            var customer = customerRepo.Get(5);
            customer.LastName = "Updated";
            var updatedCustomer = customerRepo.Update(customer);

            Assert.IsNotNull(updatedCustomer);
            Assert.IsTrue(customer.LastName == updatedCustomer.LastName);
        }


        [TestMethod]
        public void UpdateCustomerLastNameFirstName()
        {
            var context = CreateDbContext();
            var customerRepo = new CustomerRepository(context);

            var customerId = 5;
            var lastName = "LastUpdate";
            var firstName = "FirstUpdate";
            var updatedCustomer = customerRepo.Update(customerId, lastName, firstName);

            Assert.IsNotNull(updatedCustomer);
            Assert.IsTrue(updatedCustomer.LastName == lastName);
        }

        [TestMethod]
        public void DeleteCustomerByIdTest()
        {
            var context = CreateDbContext();
            var customerRepo = new CustomerRepository(context);
            customerRepo.Delete(8);

            try
            {
                var customerGone = customerRepo.Get(8);

            }
            catch (Exception e)
            {
                Assert.IsTrue(e.Message.Contains("Sequence contains no elements"));
            }
        }


        [TestMethod]
        public void DeleteCustomerInstanceTest()
        {
            var context = CreateDbContext();
            var customerRepo = new CustomerRepository(context);
            var customer = customerRepo.Get(9);
            Assert.IsNotNull(customer);
            customerRepo.Delete(customer);

            try
            {
                var customerGone = customerRepo.Get(9);

            }
            catch (Exception e)
            {
                Assert.IsTrue(e.Message.Contains("Sequence contains no elements"));
            }
        }

        [TestMethod]
        public void DeleteCustomerRangeTest()
        {
            var context = CreateDbContext();
            var customerRepo = new CustomerRepository(context);
            var customer1 = customerRepo.Get(10);
            var customer2 = customerRepo.Get(11);
            var customers = new List<Customer>();
            customers.Add(customer1);
            customers.Add(customer2);

            customerRepo.Delete(customers);

            try
            {
                var customerGone = customerRepo.Get(11);

            }
            catch (Exception e)
            {
                Assert.IsTrue(e.Message.Contains("Sequence contains no elements"));
            }
        }

        [TestMethod]
        public void GetCustomerWithRelatedTest()
        {
            var context = CreateDbContext();
            var customerRepo = new CustomerRepository(context);

            var customer = customerRepo.Get(5);
            Assert.IsNotNull(customer);
            Assert.IsNull(customer.Address);
            Assert.IsNull(customer.CustomerType);

            var customerWithRelated = customerRepo.GetWithRelated(5);

            Assert.IsNotNull(customerWithRelated);
            Assert.IsNotNull(customerWithRelated.Address);
            Assert.IsNotNull(customerWithRelated.CustomerType);

        }

        [TestMethod]
        public async Task GetCustomerWithRelatedAsycTest()
        {
            var context = CreateDbContext();
            var customerRepo = new CustomerRepository(context);

            var customer = customerRepo.Get(5);
            Assert.IsNotNull(customer);
            Assert.IsNull(customer.Address);
            Assert.IsNull(customer.CustomerType);

            var customerWithRelated = await customerRepo.GetWithRelatedAsync(5);

            Assert.IsNotNull(customerWithRelated);
            Assert.IsNotNull(customerWithRelated.Address);
            Assert.IsNotNull(customerWithRelated.CustomerType);

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