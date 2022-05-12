using ShoppingCartEF3.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartBusinessServices.BusinessObjects
{
    public class CustomerTypeBO
    {
        private CustomerType _dataObject;
        public CustomerTypeBO()
        {
            _dataObject = new CustomerType();
        }
        internal CustomerTypeBO(CustomerType dataObject)
        {
            _dataObject = dataObject;

        }
    }
}
