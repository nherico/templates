using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Model;
using DataAccess;

namespace BusinessLogic
{
    public class CustomerBL
    {
        public List<Customer> GetCustomerList(Customer objCustomer)
        {
            CustomerDAL objCustomerDAL = new CustomerDAL();
            return objCustomerDAL.GetCustomerList(objCustomer);
        }
    }
}
