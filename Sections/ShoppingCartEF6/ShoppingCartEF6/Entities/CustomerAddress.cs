using ShoppingCartEF2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartEF3.Entities
{
    public class CustomerAddress
    {
        public int CustomerAddressId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public int AddressOfCustomerId { get; set; }
        public Customer Customer { get; set; }

    }
}
