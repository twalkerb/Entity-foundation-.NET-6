using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFCore6Demo.DataServices.ShoppingCart.Models
{
    [Table("CustomerBook", Schema = "Shopping")]
    [Index("BookId", Name = "IX_CustomerBook_BookId")]
    public partial class CustomerBook
    {
        [Key]
        public int CustomerId { get; set; }
        [Key]
        public int BookId { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        [ForeignKey("BookId")]
        [InverseProperty("CustomerBooks")]
        public virtual LibaryBook Book { get; set; } = null!;
        [ForeignKey("CustomerId")]
        [InverseProperty("CustomerBooks")]
        public virtual Customer Customer { get; set; } = null!;
    }
}
