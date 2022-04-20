
using ShoppingCartEF3.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartEF2.Entities
{
    public class Customer : PersonBase
    {
        public string CustomerGroup { get; set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal CustomerBudget { get; set; }

        [NotMapped]
        public DateTime LastSavedToDatabase { get; set; }

        public int? CreditScore { get; set; }
        public DateTime CreditScoreDate { get; set; }

        public decimal CreditLimit { get; set; }
        public int CreditDays { get; set; }

        // one-to-one
        public CustomerAddress Address { get; set; }

        // one-to-many
        public int CustomerTypeId { get; set; }
        public CustomerType CustomerType { get; set; }



    }
}
