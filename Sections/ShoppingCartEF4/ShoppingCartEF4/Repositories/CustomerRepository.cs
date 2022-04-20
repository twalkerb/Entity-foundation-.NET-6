using Microsoft.EntityFrameworkCore;
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
 
    
        public Customer Get(int id)
        {
            return _context.Customers.Single(w => w.Id == id);
        }
        public async Task<Customer> GetAsync(int id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }


        public IEnumerable<Customer> Find(string firstName, string lastName)
        {
            var customers = _context.Customers.Where(w => w.FirstName == firstName && w.LastName == lastName);
            return customers.ToList();

        }
        public async Task<IEnumerable<Customer>> FindAsync(string firstName, string lastName)
        {
            var dataSet = _context.Customers.AsQueryable();

            dataSet = dataSet.Where(w => w.FirstName == firstName && w.LastName == lastName);

            return await dataSet.ToListAsync();

        }

    }
}

