using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ShoppingCartEF2.Data;
using ShoppingCartEF3.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartEF3.RawSql
{
    public class SearchCustomers
    {
        ShoppingCartDS _context;
        public SearchCustomers(ShoppingCartDS context)
        {
            _context = context;
        }
        public IEnumerable<CustomerSearchResult> FindCustomers(string searchValue)
        {
            var sqlParameters = new List<SqlParameter>();

            var parameters = new string[1];

            parameters[0] = string.Format("@p{0}", 0);

            sqlParameters.Add(new SqlParameter(parameters[0], searchValue));

            // apply to default schema 'Shopping' - set in previous lesson Fluent API configuration
            var sqlStatement = "Select Id, FirstName, LastName from Shopping.Customers where FirstName like @p0 +'%' or LastName like @p0 +'%' ";

            var rawCommand = string.Format("EXECUTE {0}  {1}", sqlStatement, parameters[0]);

            var results = _context.CustomSearchResults

                .FromSqlRaw(rawCommand, sqlParameters.ToArray()).ToList();

            return (IEnumerable<CustomerSearchResult>)results;
        }
    }
}
