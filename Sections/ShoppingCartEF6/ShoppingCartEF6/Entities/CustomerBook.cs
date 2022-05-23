using ShoppingCartEF2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartEF3.Entities
{
    public class CustomerBook
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }


        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }

    }
}
