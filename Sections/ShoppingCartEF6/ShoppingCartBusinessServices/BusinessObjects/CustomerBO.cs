using ShoppingCartEF2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartBusinessServices.BusinessObjects
{
    public class CustomerBO
    {
        private Customer _dataObject;

        public CustomerBO()
        { 
            _dataObject = new Customer();
        }
        internal CustomerBO(Customer dataObject)
        {
            _dataObject = dataObject;

            if (_dataObject != null && _dataObject.CustomerType != null)
                this.CustomerTypeBO = new CustomerTypeBO(_dataObject.CustomerType);
            //if (_dataObject != null && _dataObject.Address != null)
            //    this.AddresssBO = new AddressBO(_dataObject.Address);

        }
        public string CustomerGroup { get { return _dataObject.CustomerGroup; } set { _dataObject.CustomerGroup = value; } }
        public decimal CustomerBudget { get { return _dataObject.CustomerBudget; } set { _dataObject.CustomerBudget = value; } }

        public DateTime LastSavedToDatabase { get { return _dataObject.LastSavedToDatabase; } set { _dataObject.LastSavedToDatabase = value; } }

        public int? CreditScore { get { return _dataObject.CreditScore; } set { _dataObject.CreditScore = value; } }
        public DateTime CreditScoreDate { get { return _dataObject.CreditScoreDate; } set { _dataObject.CreditScoreDate = value; } }

        public decimal CreditLimit { get { return _dataObject.CreditLimit; } set { _dataObject.CreditLimit = value; } }
        public int CreditDays { get { return _dataObject.CreditDays; } set { _dataObject.CreditDays = value; } }

        //public CustomerAddress Address { get; set; }

        public int CustomerTypeId { get { return _dataObject.CustomerTypeId; } set { _dataObject.CustomerTypeId = value; } }
        public CustomerTypeBO CustomerTypeBO { get; set; }

        // many-to-many
        //public IList<CustomerBook> BorrowedBooks { get; set; }

    }
}
