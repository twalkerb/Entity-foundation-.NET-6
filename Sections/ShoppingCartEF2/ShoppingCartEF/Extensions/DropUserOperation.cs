using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartEF.Extensions
{
    public class DropUserOperation : MigrationOperation
    {
        public string Name { get; set; }
    }
}
