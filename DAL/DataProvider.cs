using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BadmintonManager.DAO
{
    public class DataProvider
    {
        private static DataProvider instance;
        public static DataProvider Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataProvider();
                }
                return instance;
            }
            private set => instance = value;
        }

        private DataProvider() { }

        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BadmintonManager.Properties.Settings.QuanLySanConnectionString"].ConnectionString;

        public DataTable ExecuteQuery(string query, object[] parameters = null)
        {
            DataTable data = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                if (parameters != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            // Thêm tham số với kiểu dữ liệu rõ ràng
                            var parameterValue = parameters[i];
                            SqlParameter sqlParameter = new SqlParameter(item, parameterValue ?? DBNull.Value);

                            // Xác định kiểu dữ liệu của tham số
                            if (parameterValue is DateTime)
                            {
                                sqlParameter.SqlDbType = SqlDbType.DateTime;
                            }
                            else if (parameterValue is decimal)
                            {
                                sqlParameter.SqlDbType = SqlDbType.Decimal;
                            }
                            else if (parameterValue is int)
                            {
                                sqlParameter.SqlDbType = SqlDbType.Int;
                            }
                            else
                            {
                                sqlParameter.SqlDbType = SqlDbType.NVarChar;
                            }

                            command.Parameters.Add(sqlParameter);
                            i++;
                        }
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                connection.Close();
            }
            return data;
        }

        public int ExecuteNonQuery(string query, object[] parameters = null)
        {
            int data = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                if (parameters != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            // Thêm tham số với kiểu dữ liệu rõ ràng
                            var parameterValue = parameters[i];
                            SqlParameter sqlParameter = new SqlParameter(item, parameterValue ?? DBNull.Value);

                            // Xác định kiểu dữ liệu của tham số
                            if (parameterValue is DateTime)
                            {
                                sqlParameter.SqlDbType = SqlDbType.DateTime;
                            }
                            else if (parameterValue is decimal)
                            {
                                sqlParameter.SqlDbType = SqlDbType.Decimal;
                            }
                            else if (parameterValue is int)
                            {
                                sqlParameter.SqlDbType = SqlDbType.Int;
                            }
                            else
                            {
                                sqlParameter.SqlDbType = SqlDbType.NVarChar;
                            }

                            command.Parameters.Add(sqlParameter);
                            i++;
                        }
                    }
                }

                data = command.ExecuteNonQuery();
                connection.Close();
            }
            return data;
        }

        public object ExecuteScalar(string query, object[] parameters = null)
        {
            object data = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                if (parameters != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            // Thêm tham số với kiểu dữ liệu rõ ràng
                            var parameterValue = parameters[i];
                            SqlParameter sqlParameter = new SqlParameter(item, parameterValue ?? DBNull.Value);

                            // Xác định kiểu dữ liệu của tham số
                            if (parameterValue is DateTime)
                            {
                                sqlParameter.SqlDbType = SqlDbType.DateTime;
                            }
                            else if (parameterValue is decimal)
                            {
                                sqlParameter.SqlDbType = SqlDbType.Decimal;
                            }
                            else if (parameterValue is int)
                            {
                                sqlParameter.SqlDbType = SqlDbType.Int;
                            }
                            else
                            {
                                sqlParameter.SqlDbType = SqlDbType.NVarChar;
                            }

                            command.Parameters.Add(sqlParameter);
                            i++;
                        }
                    }
                }

                data = command.ExecuteScalar();
                connection.Close();
            }
            return data;
        }

        public void ExecuteStoredProcedure(string storedProcedureName, SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(storedProcedureName, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddRange(parameters);

                        // Thực thi thủ tục và lấy kết quả
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }
}
