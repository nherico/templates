using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Web.Configuration;
using System.Data;

namespace DataAccess
{
    public class EmailAddressDAL : SqlBase
    {
        public SqlParameter[] SetParam_EmailAddressList(int customerID)
        {
            SqlParameter[] sqlParameter = new SqlParameter[1];
            sqlParameter[0] = new SqlParameter("@CustomerID", SqlDbType.Int);
            sqlParameter[0].Value = (object)customerID ?? DBNull.Value;
            return sqlParameter;
        }
        
        public List<EmailAddress> GetEmailAddressList(int customerID)
        {
            List<Customer> objCustomerList = new List<Customer>();
            base.GetData("Customer_GetEmailAddressList", SetParam_EmailAddressList(customerID));

            List<EmailAddress> objEmailAddressList = new List<EmailAddress>();
            foreach (DataRow dr in base.DataTable.Rows)
            {
                EmailAddress objNewEmailAddress = new EmailAddress();
                objNewEmailAddress.EmailAddressID = Convert.ToInt32(dr["EmailAddressID"]);
                objNewEmailAddress.CustomerID = Convert.ToInt32(dr["CustomerID"]);
                objNewEmailAddress.Email = dr["Email"].ToString();
                objEmailAddressList.Add(objNewEmailAddress);
            }
            return objEmailAddressList;
        }
    }
}
