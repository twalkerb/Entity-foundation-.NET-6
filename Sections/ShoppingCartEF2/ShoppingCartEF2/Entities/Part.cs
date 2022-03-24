using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartEF.Entities
{
    public class Part
    {
        public int Id { get; set; }
        public string PartName { get; set; }
        public decimal ListPrice { get; set; }
    }
}
