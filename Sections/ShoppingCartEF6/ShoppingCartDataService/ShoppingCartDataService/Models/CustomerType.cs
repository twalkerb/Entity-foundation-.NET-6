using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFCore6Demo.DataServices.ShoppingCart.Models
{
    [Table("CustomerType", Schema = "Shopping")]
    public partial class CustomerType
    {
        public CustomerType()
        {
            Customers = new HashSet<Customer>();
        }

        [Key]
        [Column("CustomerTypeID")]
        public int CustomerTypeId { get; set; }
        public string CustomerTypeName { get; set; } = null!;

        [InverseProperty("CustomerType")]
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
