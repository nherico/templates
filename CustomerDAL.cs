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
    public class CustomerDAL : SqlBase
    {
        SqlParameter[] SetParam_CustomerList(Customer objCustomer)
        {
            SqlParameter[] sqlParameter = new SqlParameter[6];
            sqlParameter[0] = new SqlParameter("@CustomerID", SqlDbType.Int);
            sqlParameter[0].Value = (object)objCustomer.CustomerID ?? DBNull.Value;
            sqlParameter[1] = new SqlParameter("@Firstname", SqlDbType.VarChar);
            sqlParameter[1].Value = (object)objCustomer.Firstname ?? DBNull.Value;
            sqlParameter[2] = new SqlParameter("@Middlename", SqlDbType.VarChar);
            sqlParameter[2].Value = (object)objCustomer.Middlename ?? DBNull.Value;
            sqlParameter[3] = new SqlParameter("@Lastname", SqlDbType.VarChar);
            sqlParameter[3].Value = (object)objCustomer.Lastname ?? DBNull.Value;
            sqlParameter[4] = new SqlParameter("@BirthDate", SqlDbType.DateTime);
            sqlParameter[4].Value = (object)objCustomer.BirthDate ?? DBNull.Value;
            sqlParameter[5] = new SqlParameter("@Gender", SqlDbType.VarChar);
            sqlParameter[5].Value = (object)objCustomer.Gender ?? DBNull.Value;
            return sqlParameter;
        }

        public List<Customer> GetCustomerList(Customer objCustomer)
        {
            List<Customer> objCustomerList = new List<Customer>();
            DataTable dtCustomer = new DataTable();

            base.GetData("Customer_GetCustomerList", SetParam_CustomerList(objCustomer));
            dtCustomer = base.DataTable;

            foreach (DataRow drCustomer in dtCustomer.Rows)
            {
                Customer objNewCustomer = new Customer();
                objNewCustomer.CustomerID = Convert.ToInt32(drCustomer["CustomerID"]);
                objNewCustomer.Firstname = drCustomer["Firstname"].ToString();
                objNewCustomer.Middlename = drCustomer["Middlename"].ToString();
                objNewCustomer.Lastname = drCustomer["Lastname"].ToString();
                objNewCustomer.BirthDate = Convert.ToDateTime(drCustomer["BirthDate"]);
                objNewCustomer.Gender = drCustomer["Gender"].ToString();
                objNewCustomer.DateCreated = Convert.ToDateTime(drCustomer["DateCreated"]);

                List<EmailAddressDAL> objEmailAddressList = new List<EmailAddressDAL>();
                DataTable dtEmailAddress = new DataTable();
                EmailAddressDAL objEmailAddressDAL = new EmailAddressDAL();

                dtEmailAddress = objEmailAddressDAL.GetData("Customer_GetEmailAddressList", objEmailAddressDAL.SetParam_EmailAddressList(objNewCustomer.CustomerID.GetValueOrDefault()));

                foreach (DataRow drEmailAddress in dtEmailAddress.Rows)
                {
                    EmailAddress objEmailAddress = new EmailAddress();
                    objEmailAddress.EmailAddressID = Convert.ToInt32(drEmailAddress["EmailAddressID"]);
                    objEmailAddress.CustomerID = Convert.ToInt32(drEmailAddress["CustomerID"]);
                    objEmailAddress.Email = drEmailAddress["Email"].ToString();
                    objNewCustomer.EmailAdress.Add(objEmailAddress);
                }
                objCustomerList.Add(objNewCustomer);
            }
            return objCustomerList;
        }
    }
}
