using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartEF6.Entities
{
    public class vwCustomerGroupBorrowedBook
    {
        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string CustomerGroup { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal PurchasePrice { get; set; }
        public string Name { get; set; }
        public string InternationStandardBookNumber { get; set; }
    }
}
