using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartEF2.Entities
{
    public class Library
    {
        public int Id { get; set; }
        public string LibraryName { get; set; }

        [InverseProperty("PrimaryLibrary")]
        public ICollection<Book> PrimaryBooks { get; set; }

        [InverseProperty("OnLoanLibrary")]
        public ICollection<Book> BooksOnLoan { get; set; }

    }
}
