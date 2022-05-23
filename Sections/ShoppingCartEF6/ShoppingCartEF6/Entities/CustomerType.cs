using ShoppingCartEF2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartEF3.Entities
{
    public class CustomerType
    {
        public int CustomerTypeID { get; set; }
        public string CustomerTypeName { get; set; }

        // one-to-many
        public ICollection<Customer> Customers { get; set; }
    }
}
