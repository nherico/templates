using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccess;
using Model;

namespace BusinessLogic
{
    public class EmailAddressBL
    {
        public List<EmailAddress> GetEmailAddressList(int customerID)
        {
            EmailAddressDAL objEmailAddressDAL = new EmailAddressDAL();
            return objEmailAddressDAL.GetEmailAddressList(customerID);
        }
    }
}
