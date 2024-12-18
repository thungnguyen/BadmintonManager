using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace BadmintonManager.DAL
{
    public class DatabaseProvider
    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BadmintonManager.Properties.Settings.QuanLySanConnectionString"].ConnectionString;

        private static DatabaseProvider instance;

        public static DatabaseProvider Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DatabaseProvider();
                }
                return instance;
            }
        }

        // Hàm thực thi truy vấn SELECT và trả về DataTable
        public DataTable ExecuteQuery(string query, object[] parameters = null)
        {
            DataTable data = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                if (parameters != null)
                {
                    string[] listParams = query.Split(' ');
                    int index = 0;
                    foreach (string param in listParams)
                    {
                        if (param.Contains('@'))
                        {
                            command.Parameters.AddWithValue(param, parameters[index]);
                            index++;
                        }
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);

                connection.Close();
            }

            return data;
        }

        // Hàm thực thi truy vấn INSERT, UPDATE, DELETE, trả về số dòng bị ảnh hưởng
        public int ExecuteNonQuery(string query, object[] parameters = null)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                if (parameters != null)
                {
                    string[] listParams = query.Split(' ');
                    int index = 0;
                    foreach (string param in listParams)
                    {
                        if (param.Contains('@'))
                        {
                            command.Parameters.AddWithValue(param, parameters[index]);
                            index++;
                        }
                    }
                }

                rowsAffected = command.ExecuteNonQuery();
                connection.Close();
            }

            return rowsAffected;
        }

        // Hàm thực thi truy vấn và trả về kết quả đơn lẻ (Scalar)
        public object ExecuteScalar(string query, object[] parameters = null)
        {
            object result = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                if (parameters != null)
                {
                    string[] listParams = query.Split(' ');
                    int index = 0;
                    foreach (string param in listParams)
                    {
                        if (param.Contains('@'))
                        {
                            command.Parameters.AddWithValue(param, parameters[index]);
                            index++;
                        }
                    }
                }

                result = command.ExecuteScalar();
                connection.Close();
            }

            return result;
        }
    }
}
