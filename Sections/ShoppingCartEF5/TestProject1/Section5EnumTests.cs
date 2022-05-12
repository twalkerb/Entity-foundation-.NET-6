using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCartEF2.Data;
using ShoppingCartEF4.Repositories;
using ShoppingCartEF5.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{

    [TestClass]
    public class Section5EnumTests
    {
        [TestMethod]
        public void EnumBasics()
        {
            List<int> integerList = new List<int>()
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10
            };
            var QuerySyntax = from item in integerList
                              where item > 5
                              select item;


            foreach (var item in QuerySyntax)
            {
                Debug.WriteLine(item + " ");
            }
        }

        [TestMethod]
        public void EnumBasics2()
        {
            List<int> integerList = new List<int>()
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10
            };

            IEnumerable<int> QuerySyntax2 = from obj in integerList
                                            where obj > 5
                                            select obj;

            foreach (var item in QuerySyntax2)
            {
                Debug.WriteLine(item + " ");
            }

        }

        // Section 5 tests
        [TestMethod]
        public void OfTypeEnumTest()
        {
            System.Collections.ArrayList fruits = new System.Collections.ArrayList(4);
            fruits.Add("Mango");
            fruits.Add("Orange");
            fruits.Add("Apple");
            fruits.Add(3.0);
            fruits.Add("Banana");

            // Apply OfType() to the ArrayList.
            IEnumerable<string> query1 = fruits.OfType<string>();
            Debug.WriteLine("Elements of type 'string' are:");
            foreach (string fruit in query1)
            {
                Debug.WriteLine(fruit);
            }

            // or to generate an exection and catch it, attemp to cast elements to desired type
            try
            {
                foreach (string fruit in fruits)
                {
                    Debug.WriteLine(fruit);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            // or to generate an exection and catch it, attemp to cast elements to desired type
            try
            {
                foreach (var item in fruits)
                {
                    if (item.GetType() == typeof(string))
                    {
                        var fruit = (string)item;
                    }
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            // or to generate an exection and catch it, attemp to cast elements to desired type
            try
            {
                // defered execution -- will throw error on first item in for..each loop
                var query3 = query1.Cast<int>(); // Note: query1 is IEnumberable<string>

                // error will be thrown here - as it attempts to cast string to int
                foreach (var item in query3)
                {
                    if (item.GetType() == typeof(int))
                    {
                        var fruitValue = (int)item;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            // The following query shows that the standard query operators such as
            // Where() can be applied to the ArrayList type after calling OfType().
            IEnumerable<string> query2 =
                fruits.OfType<string>().Where(fruit => fruit.ToLower().Contains("n"));

            Debug.WriteLine("\nThe following strings contain 'n':");
            foreach (string fruit in query2)
            {
                Debug.WriteLine(fruit);
            }
        }

        [TestMethod]
        public void IEnumTestSimple()
        {
            var context = CreateDbContext();
            var customerRepo = new CustomerRepository(context);
            var customers = customerRepo.Find("FirstName", "LastName").ToList();
        }

        [TestMethod]
        public void IncludeIEnumTestSimple()
        {
            var context = CreateDbContext();
            var customerRepo = new CustomerRepository(context);
            var customers = customerRepo.FindIncludeChildrenSimple("FirstName", "LastName").ToList();
        }

        [TestMethod]
        public void IncludeIEnumTestSimple2()
        {
            var context = CreateDbContext();
            var customerRepo = new CustomerRepository(context);
            var customers = customerRepo.FindIncludeChildrenSimple2("FirstName", "LastName").ToList();
        }

        [TestMethod]
        public void IncludeIEnumTestFull()
        {
            var context = CreateDbContext();
            var customerRepo = new CustomerRepository(context);
            var customers = customerRepo.FindIncludeChildrenFull("FirstName", "LastName").ToList();
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
