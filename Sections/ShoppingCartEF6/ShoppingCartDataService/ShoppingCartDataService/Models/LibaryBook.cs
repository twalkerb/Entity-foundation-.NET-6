using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFCore6Demo.DataServices.ShoppingCart.Models
{
    [Table("LibaryBooks", Schema = "Shopping")]
    [Index("InternationStandardBookNumber", Name = "AK_LibaryBooks_InternationStandardBookNumber", IsUnique = true)]
    [Index("Name", Name = "IX_LibaryBooks_Name")]
    [Index("OnLoanLibraryId", Name = "IX_LibaryBooks_OnLoanLibraryId")]
    [Index("PrimaryLibraryId", Name = "IX_LibaryBooks_PrimaryLibraryId")]
    public partial class LibaryBook
    {
        public LibaryBook()
        {
            CustomerBooks = new HashSet<CustomerBook>();
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int PrimaryLibraryId { get; set; }
        public int OnLoanLibraryId { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal PurchasePrice { get; set; }
        [StringLength(10)]
        [Unicode(false)]
        public string InternationStandardBookNumber { get; set; } = null!;

        [ForeignKey("OnLoanLibraryId")]
        [InverseProperty("LibaryBookOnLoanLibraries")]
        public virtual Libary OnLoanLibrary { get; set; } = null!;
        [ForeignKey("PrimaryLibraryId")]
        [InverseProperty("LibaryBookPrimaryLibraries")]
        public virtual Libary PrimaryLibrary { get; set; } = null!;
        [InverseProperty("Book")]
        public virtual ICollection<CustomerBook> CustomerBooks { get; set; }
    }
}
