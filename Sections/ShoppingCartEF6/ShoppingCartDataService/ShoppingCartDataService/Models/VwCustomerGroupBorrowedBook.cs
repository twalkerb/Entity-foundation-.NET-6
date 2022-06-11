using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFCore6Demo.DataServices.ShoppingCart.Models
{
    [Keyless]
    public partial class VwCustomerGroupBorrowedBook
    {
        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string CustomerGroup { get; set; } = null!;
        [Column(TypeName = "decimal(18, 2)")]
        public decimal PurchasePrice { get; set; }
        [StringLength(450)]
        public string Name { get; set; } = null!;
        [StringLength(10)]
        [Unicode(false)]
        public string InternationStandardBookNumber { get; set; } = null!;
    }
}
