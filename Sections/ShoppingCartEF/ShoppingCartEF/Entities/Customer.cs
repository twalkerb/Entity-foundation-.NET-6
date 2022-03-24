using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartEF.Entities
{
    public class Customer : Person
    {
        [Column(Order = 3)]
        public string PostalZipCode { get; set; }

        public string Department { get; set; }
        public decimal MaxCredit { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
