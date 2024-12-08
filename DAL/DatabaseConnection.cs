using System;
using System.Data.SqlClient;

namespace BadmintonManager.DAL
{
    internal class DatabaseConnection
    {
        /// <summary>
        /// Manages database connection and provides utility methods for database interactions
        /// </summary>

        // Connection string from app.config or connection settings
        private static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BadmintonManager.Properties.Settings.QuanLySanConnectionString"].ConnectionString;

        /// <summary>
        /// Creates and returns a new SQL connection
        /// </summary>
        public static SqlConnection GetConnection()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();  // Open the connection here
                return connection;
            }
            catch (Exception ex)
            {
                // Log error here
                throw new InvalidOperationException("Database connection could not be established.", ex);
            }
        }

        /// <summary>
        /// Safely closes a database connection
        /// </summary>
        public static void CloseConnection(SqlConnection connection)
        {
            if (connection != null)
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
                connection.Dispose(); // Ensure it is disposed
            }
        }
    }
}
