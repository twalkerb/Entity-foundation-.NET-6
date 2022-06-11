using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFCore6Demo.DataServices.ShoppingCart.Models
{
    [Table("Customers", Schema = "Shopping")]
    [Index("CustomerTypeId", Name = "IX_Customers_CustomerTypeId")]
    public partial class Customer
    {
        public Customer()
        {
            CustomerBooks = new HashSet<CustomerBook>();
        }

        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string CustomerGroup { get; set; } = null!;
        [Column(TypeName = "decimal(18, 6)")]
        public decimal CustomerBudget { get; set; }
        public int CreditDays { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal CreditLimit { get; set; }
        public int? CreditScore { get; set; }
        public DateTime CreditScoreDate { get; set; }
        public int CustomerTypeId { get; set; }

        [ForeignKey("CustomerTypeId")]
        [InverseProperty("Customers")]
        public virtual CustomerType CustomerType { get; set; } = null!;
        [InverseProperty("AddressOfCustomer")]
        public virtual CustomerAddress CustomerAddress { get; set; } = null!;
        [InverseProperty("Customer")]
        public virtual ICollection<CustomerBook> CustomerBooks { get; set; }
    }
}
