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
        public Customer GetWithRelated(int id)
        {
            return _context.Customers
                .Include(i => i.Address)
                .Include(i => i.CustomerType)
                .Single(w => w.Id == id);
        }

        public async Task<Customer?> GetWithRelatedAsync(int id)
        {
            return await _context.Customers
                .Where(w => w.Id == id)
                .Include(i => i.Address)
                .Include(i => i.CustomerType)
                .FirstOrDefaultAsync();
        }

        public async Task<Customer?> GetAsync(int id)
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
            //return customers.ToList();
            //return customers.AsEnumerable();
            return customers;

        }

        /// <summary>
        /// Section 5 Video 3
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns></returns>
        public IEnumerable<Customer> FindIncludeChildrenSimple(string firstName, string lastName)
        {
            var customers = _context.Customers
                .Include("Address")
                .Include("CustomerType")
                .Include("BorrowedBooks")
                .Where(w => w.FirstName == firstName && w.LastName == lastName);
            //return customers.ToList();
            return customers.AsEnumerable();
            //return customers;

        }
        public IEnumerable<Customer> FindIncludeChildrenSimple2(string firstName, string lastName)
        {
            var customers = _context.Customers
                .Include(i => i.Address)
                .Include(i => i.CustomerType)
                .Include(i => i.BorrowedBooks)
                .Where(w => w.FirstName == firstName && w.LastName == lastName);
            //return customers.ToList();
            return customers.AsEnumerable();
            //return customers;

        }
        public IEnumerable<Customer> FindIncludeChildrenFull(string firstName, string lastName)
        {
            var customers = _context.Customers
                .Include(i => i.Address)
                .Include(i => i.CustomerType)
                .Include(i => i.BorrowedBooks)
                .ThenInclude(borrowedBook => borrowedBook.Book)
                .ThenInclude(book => book.PrimaryLibrary)
                .Where(w => w.FirstName == firstName && w.LastName == lastName);
            //return customers.ToList();
            return customers.AsEnumerable();
            //return customers;

        }

        // Find returning IQuerable - Section 5 Video 2
        public IQueryable<Customer> FindQ(string firstName, string lastName)
        {
            var customers = _context.Customers.AsQueryable();

            customers = customers.Where(w => w.FirstName == firstName && w.LastName == lastName);
            return customers;

        }

        // Count returning int as rows of Customers - Section 5 Video 2
        public int Count()
        {
            return _context.Customers.Count();
        }

        public List<Customer> List(string firstName, string lastName)
        {
            var customers = _context.Customers
                .Include(i => i.Address)
                .Include(i => i.CustomerType)
                .Where(w => w.FirstName == firstName && w.LastName == lastName);
            return customers.ToList();

        }

        public async Task<List<Customer>> ListAsync(string firstName, string lastName)
        {
            var dataSet = _context.Customers
                .Include(i => i.Address)
                .Include(i => i.CustomerType)
                .AsQueryable();

            dataSet = dataSet.Where(w => w.FirstName == firstName && w.LastName == lastName);

            return await dataSet.ToListAsync();

        }

        public async Task<IEnumerable<Customer>> FindAsync(string firstName, string lastName)
        {
            var dataSet = _context.Customers.AsQueryable();

            dataSet = dataSet.Where(w => w.FirstName == firstName && w.LastName == lastName);

            return await dataSet.ToListAsync();

        }

        public Customer Update(Customer customer)
        {
            //var updateCust = DbContext.Customers.Single(w => w.Id == customer.Id);
            _context.Customers.Update(customer);
            _context.SaveChanges();

            return customer;
        }
        public Customer Update(int id, string lastName, string firstName)
        {
            var customer = _context.Customers.Single(w => w.Id == id);
            customer.LastName = lastName;
            customer.FirstName = firstName;

            _context.Customers.Update(customer);
            _context.SaveChanges();

            return customer;
        }
        public void Delete(int id)
        {
            var customer = _context.Customers.Single(w => w.Id == id);
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }
        public void Delete(Customer customer)
        {
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }

        public void Delete(IEnumerable<Customer> customers)
        {
            _context.Customers.RemoveRange(customers);
            _context.SaveChanges();
        }

    }
}

