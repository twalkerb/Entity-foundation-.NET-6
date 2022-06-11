using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFCore6Demo.DataServices.ShoppingCart.Models
{
    [Table("Orders", Schema = "Shopping")]
    public partial class Order
    {
        [Key]
        public string OrderId { get; set; } = null!;
        public string CustomerName { get; set; } = null!;
        public string? PackageType { get; set; }
        public string? PackageSequence { get; set; }
    }
}
