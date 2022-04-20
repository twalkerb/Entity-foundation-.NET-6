using ShoppingCartEF2.Data;
using ShoppingCartEF2.Entities;
using ShoppingCartEF3.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartEF4.Repositories
{
    public class CustomerRepository
    {
        ShoppingCartDS _context;

        public CustomerRepository(ShoppingCartDS context)
        {
            _context = context;
        }

        public Customer Add(string firstName, string lastName, string customerGroup,
            int customerTypeId, string address, string city, string state, string country)
        {
            var customer = new Customer()
            {
                FirstName = firstName,
                LastName = lastName,
                CustomerGroup = customerGroup,
                Address = new CustomerAddress()
                {
                    Address = address,
                    City = city,
                    State = state,
                    Country = country
                },
                CreditDays = 30,
                CustomerTypeId = customerTypeId
            };

            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer;
        }
    }
}

