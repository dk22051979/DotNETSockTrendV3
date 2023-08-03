using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace InputCsvDisplayChartForms
{
    class DBAccess
    {
        private static SqlConnection objConnection;
        private static SqlDataAdapter objDataAdapter;
        public static string ConnectionString = "Data Source=CORESIXTEEN;Initial Catalog=nse_eq_2020;Integrated Security=true;";
        public static string ConnectionStringfo = "Data Source=CORESIXTEEN;Initial Catalog=nse_fo_2020;Integrated Security=true;";
        public static string ConnectionStringfot = "Data Source=CORESIXTEEN;Initial Catalog=nse_fo_2020;Integrated Security=true;";
        public static string ConnectionStringNifty = "Data Source=CORESIXTEEN;Initial Catalog=indices;Integrated Security=true;";
        
        private static void OpenConnection()
        {
            try
            {
                if (objConnection == null)
                {
                    objConnection = new SqlConnection(ConnectionString);
                    objConnection.Open();
                }
                else
                {
                    if (objConnection.State != System.Data.ConnectionState.Open)
                    {
                        objConnection = new SqlConnection(ConnectionString);
                        objConnection.Open();
                    }
                }
            }
            catch (Exception ex) { }
        }
        private static void CloseConnection()
        {
            try
            {
                if (!(objConnection == null))
                {
                    if (objConnection.State == System.Data.ConnectionState.Open)
                    {
                        objConnection.Close();
                        objConnection.Dispose();
                    }
                }
            }
            catch { }
        }
        public static bool ExecuteNiftyQuery(string query)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionStringNifty))
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool ExecuteQuery(string query)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool ExecuteFOQuery(string query)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionStringfo))
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool ExecuteFOTQuery(string query)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionStringfot))
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
