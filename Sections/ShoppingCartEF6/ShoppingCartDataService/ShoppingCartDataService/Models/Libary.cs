using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFCore6Demo.DataServices.ShoppingCart.Models
{
    [Table("Libaries", Schema = "Shopping")]
    public partial class Libary
    {
        public Libary()
        {
            LibaryBookOnLoanLibraries = new HashSet<LibaryBook>();
            LibaryBookPrimaryLibraries = new HashSet<LibaryBook>();
        }

        [Key]
        public int Id { get; set; }
        public string LibraryName { get; set; } = null!;

        [InverseProperty("OnLoanLibrary")]
        public virtual ICollection<LibaryBook> LibaryBookOnLoanLibraries { get; set; }
        [InverseProperty("PrimaryLibrary")]
        public virtual ICollection<LibaryBook> LibaryBookPrimaryLibraries { get; set; }
    }
}
