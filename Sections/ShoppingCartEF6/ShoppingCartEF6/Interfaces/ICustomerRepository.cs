using ShoppingBase.Interfaces;
using ShoppingCartEF2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartEF6.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer GetWithRelated(int id);
        Task<Customer?> GetWithRelatedAsync(int id);
    }
}
