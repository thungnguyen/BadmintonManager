using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BadmintonManager.GUI
{
    public partial class LichDatSan : Form
    {
        // Connection string for the database (update with your actual connection string)
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BadmintonManager.Properties.Settings.QuanLySanConnectionString"].ConnectionString;

        public LichDatSan()
        {
            InitializeComponent();
            SetupDataGridView();
            LoadBookingData(DateTime.Today); // Load today's bookings by default
            LichtheoNgaypicker.ValueChanged += LichtheoNgaypicker_ValueChanged; // Attach event handler
        }

        private void LichDatSan_Load(object sender, EventArgs e)
        {
            LoadBookingData(LichtheoNgaypicker.Value); // Ensure data loads when the form is displayed
        }


        private void SetupDataGridView()
        {
            dgvDatSan.Rows.Clear();    // Clear rows first to avoid invalid state.
            dgvDatSan.Columns.Clear(); // Clear columns next.

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Fetch courts and create columns
                string courtQuery = "SELECT MaSan, TenSan FROM San ORDER BY MaSan";
                DataTable courtsTable = new DataTable();
                using (SqlDataAdapter courtAdapter = new SqlDataAdapter(courtQuery, connection))
                {
                    courtAdapter.Fill(courtsTable);
                }

                // Add a "Time" column for the hour labels
                dgvDatSan.Columns.Add("Time", "Time");

                // Add columns for each court
                foreach (DataRow row in courtsTable.Rows)
                {
                    dgvDatSan.Columns.Add($"Court{row["MaSan"]}", row["TenSan"].ToString());
                }
            }

            // Add rows for each hour (8 AM to 10 PM)
            for (int hour = 8; hour <= 22; hour++)
            {
                int rowIndex = dgvDatSan.Rows.Add();
                dgvDatSan.Rows[rowIndex].Cells[0].Value = $"{hour:00}:00"; // Set the time label in the first column
            }

            dgvDatSan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        private void LoadBookingData(DateTime selectedDate)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string bookingQuery = @"
                        SELECT 
                            lds.MaSan, 
                            kh.TenKH AS CustomerName,
                            DATEPART(HOUR, lds.TuGio) AS StartHour
                        FROM 
                            LichDatSan lds
                        JOIN 
                            KhachHang kh ON lds.MaKH = kh.MaKH
                        WHERE 
                            @SelectedDate BETWEEN lds.TuNgay AND lds.DenNgay";

                    using (SqlCommand cmd = new SqlCommand(bookingQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@SelectedDate", selectedDate.Date);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int courtId = reader.GetInt32(0);
                                string customerName = reader.GetString(1);
                                int startHour = reader.GetInt32(2);

                                // Find the corresponding cell and update it
                                int columnIndex = dgvDatSan.Columns[$"Court{courtId}"].Index;
                                int rowIndex = startHour - 8; // Since row starts at 8 AM
                                if (rowIndex >= 0 && rowIndex < dgvDatSan.Rows.Count)
                                {
                                    dgvDatSan.Rows[rowIndex].Cells[columnIndex].Value = customerName;
                                    dgvDatSan.Rows[rowIndex].Cells[columnIndex].Style.BackColor = System.Drawing.Color.LightCoral;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading booking data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Optionally handle the cell click event if you need to take action on clicking a row
        }

        private void Addbookingbtn_Click(object sender, EventArgs e)
        {

        }

        private void LichtheoNgaypicker_ValueChanged(object sender, EventArgs e)
        {
            LoadBookingData(LichtheoNgaypicker.Value);
        }

        private void refreshbtn_Click(object sender, EventArgs e)
        {
            LoadBookingData(LichtheoNgaypicker.Value);
        }
    }
}
