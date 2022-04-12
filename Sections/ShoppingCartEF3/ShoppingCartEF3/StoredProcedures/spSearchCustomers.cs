using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ShoppingCartEF2.Data;
using ShoppingCartEF2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartEF3.StoredProcedures
{
    public class spSearchCustomers
    {
        ShoppingCartDS _context;

        public spSearchCustomers(ShoppingCartDS context)
        {
            _context = context;
        }

        public IEnumerable<Customer> FindCustomers(string searchValue)
        {
            var functionName = "spSearchCustomers";

            var sqlParameters = new List<SqlParameter>();

            var parameters = new string[1];

            parameters[0] = string.Format("@p{0}", 0);

            sqlParameters.Add(new SqlParameter(parameters[0], searchValue));

            var rawCommand = string.Format("EXECUTE {0}  {1}", functionName, parameters[0]);

            var results = _context.Customers
                .FromSqlRaw(rawCommand, sqlParameters.ToArray()).ToList();

            return results;
        }

    }
}
