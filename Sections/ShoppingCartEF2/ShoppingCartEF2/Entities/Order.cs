using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartEF2.Entities
{
    public class Order
    {
        public string OrderId { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;

        //public string PackageSerial { get; set; } = string.Empty;
        public string PackagePrefix { get; set; } = string.Empty;
        public string PackageIndex { get; set; } = string.Empty;


    }
}
