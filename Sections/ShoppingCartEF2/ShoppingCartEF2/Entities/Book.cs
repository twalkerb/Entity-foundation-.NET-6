using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartEF2.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("PrimaryLibrary")]
        public int? PrimaryLibraryId { get; set; }
        public Library PrimaryLibrary { get; set; }

        [ForeignKey("OnLoanLibrary")]
        public int? OnLoanLibraryId { get; set; }
        public Library OnLoanLibrary { get; set; }

        [Column("PurchasePrice", TypeName = "decimal(18, 2)")]
        public decimal UnitPrice { get; set; }

    }
}
