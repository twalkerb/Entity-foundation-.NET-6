using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartEF.Entities
{
    [Table("CustomerNotes")]
    public class Note
    {
        [Column("Note_id", Order = 1)]
        public int NoteId { get; set; }

        [Column(TypeName = "varchar(200)", Order = 0)]
        [Comment("The URL of the web page the note is about")]
        public string Url { get; set; }

        [MaxLength(500)]
        [Required]
        public string NoteText { get; set; }

        [Precision(14, 2)] // decimal(14,2)
        public decimal Score { get; set; }
        [Precision(3)] // precision 3 will cause a column of type datetime2(3)
        public DateTime LastUpdated { get; set; }

    }
}
