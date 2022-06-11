using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFCore6Demo.DataServices.ShoppingCart.Models
{
    [Table("CustomerAddress", Schema = "Shopping")]
    [Index("AddressOfCustomerId", Name = "IX_CustomerAddress_AddressOfCustomerId", IsUnique = true)]
    public partial class CustomerAddress
    {
        [Key]
        public int CustomerAddressId { get; set; }
        public string Address { get; set; } = null!;
        public string City { get; set; } = null!;
        public string State { get; set; } = null!;
        public string Country { get; set; } = null!;
        public int AddressOfCustomerId { get; set; }

        [ForeignKey("AddressOfCustomerId")]
        [InverseProperty("CustomerAddress")]
        public virtual Customer AddressOfCustomer { get; set; } = null!;
    }
}
