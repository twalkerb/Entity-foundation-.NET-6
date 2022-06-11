using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFCore6Demo.DataServices.ShoppingCart.Models
{
    public partial class CustomerNote
    {
        [Key]
        [Column("Note_id")]
        public int NoteId { get; set; }
        /// <summary>
        /// The URL of the web page the note is about
        /// </summary>
        [StringLength(200)]
        [Unicode(false)]
        public string UrlSmall { get; set; } = null!;
        [StringLength(500)]
        public string NoteText { get; set; } = null!;
        [Column(TypeName = "decimal(14, 2)")]
        public decimal Score { get; set; }
        [Precision(3)]
        public DateTime LastUpdated { get; set; }
    }
}
