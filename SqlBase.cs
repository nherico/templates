using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace DataAccess
{
    public abstract class SqlBase
    {
        private DataSet dataSet;
        private DataTable dataTable;
        private SqlParameter[] sqlParameter;
        string connectionString = WebConfigurationManager.ConnectionStrings["DemoDB"].ConnectionString;

        protected void PostData(string storedProcedure)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(storedProcedure, sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.CommandTimeout = 0;
                        sqlCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException e)
            {
                throw new SystemException(e.ToString());
            }
        }

        protected void PostData(string storedProcedure, SqlParameter[] sqlParameter)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(storedProcedure, sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.CommandTimeout = 0;
                        sqlCommand.Parameters.AddRange(sqlParameter);
                        sqlCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException e)
            {
                throw new SystemException(e.ToString());
            }
        }

        public DataTable GetData(string storedProcedure)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(storedProcedure, sqlConnection))
                    {
                        adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                        adapter.SelectCommand.CommandTimeout = 0;
                        adapter.Fill(dt);
                        dataTable = dt;
                    }
                }
            }
            catch (SqlException e)
            {
                throw new SystemException(e.ToString());
            }
            return dataTable;
        }

        public DataTable GetData(string storedProcedure, SqlParameter[] sqlParameter)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(storedProcedure, sqlConnection))
                    {
                        adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                        adapter.SelectCommand.CommandTimeout = 0;
                        adapter.SelectCommand.Parameters.AddRange(sqlParameter);
                        adapter.Fill(dt);
                        dataTable = dt;
                    }
                }
            }
            catch (SqlException e)
            {
                throw new SystemException(e.ToString());
            }
            return dataTable;
        }

        protected SqlParameter[] SqlParameter
        {
            get { return sqlParameter; }
            set { sqlParameter = value; }
        }

        protected DataTable DataTable
        {
            get { return dataTable; }
            set { dataTable = value; }
        }
    }
}
