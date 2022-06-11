using Microsoft.EntityFrameworkCore;
using ShoppingCartEF2.Data;
using ShoppingCartEF2.Entities;
using ShoppingCartEF6.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartEF5.Repositories
{
    public class CustomerGroupBorrrowedBooksRepository
    {
        ShoppingCartDS _context;

        public CustomerGroupBorrrowedBooksRepository(ShoppingCartDS context)
        {
            _context = context;
        }


        public IEnumerable<vwCustomerGroupBorrowedBook> Find(string bookName)
        {
            var results = _context.vwCustomerGroupBorrowedBooks.Where(w => w.Name.Contains(bookName));
            return results;

        }
      
    }
}
