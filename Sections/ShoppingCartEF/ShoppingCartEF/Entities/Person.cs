using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartEF.Entities
{
    public class Person : HumanBase
    {
        [Column(Order = 2)]
        public string LastName { get; set; }
        [Column(Order = 1)]
        public string FirstName { get; set; }
    }
}
