using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartEF.Entities
{
    public class HumanBase
    {
        [Column(Order = 0)]
        public int Id { get; set; }
    }
}
