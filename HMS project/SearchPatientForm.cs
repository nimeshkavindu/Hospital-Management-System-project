using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HMS_project
{
    public partial class SearchPatientForm : Class_closefun
    {
        public SearchPatientForm()
        {
            InitializeComponent();
        }

       

        //Title bar buttons
        private void Exit_Click(object sender, EventArgs e)
        {
            base.btnClose_Click(sender, e);
        }

        private void Maximize_Click(object sender, EventArgs e)
        {
            base.btnMaximize_Click(sender, e);
        }

        private void Minimize_Click(object sender, EventArgs e)
        {
            base.btnMinimize_Click(sender, e);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            base.Home_Click(sender, e);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            txtSearch.ForeColor = Color.Black;
        }
        //Search Click
        private void btnSearch_Click(object sender, EventArgs e)
        {
            String searchTerm = txtSearch.Text.Trim();

            DataTable searchResults = SearchInDatabase(searchTerm);

            dataGridView1.DataSource = searchResults;
        }

        private DataTable SearchInDatabase(string searchTerm)
        {
            DataTable resultsTable = new DataTable();

            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=XTREMELITE-PC\SQLEXPRESS;Initial Catalog=Users;Integrated Security=True"))
                {
                    conn.Open();

                    String query = "SELECT PatientID, Name, Address, NIC, Phone FROM regpatient_Table WHERE Name LIKE @SearchTerm OR NIC LIKE @SearchTerm ";
                    
                    using(SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm + "%");

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(resultsTable);
                    }
                } 
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return resultsTable;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];


                string name = selectedRow.Cells["Name"].Value.ToString();
                string address = selectedRow.Cells["Address"].Value.ToString();
                string patientID = selectedRow.Cells["PatientID"].Value.ToString();
                string nic = selectedRow.Cells["NIC"].Value.ToString();
                string phone = selectedRow.Cells["Phone"].Value.ToString();


                txtPatientID.Text = patientID;

                lblName.Text = "Name: " + name;
                lblAddress.Text = "Address: " + address;
                lblNIC.Text = "NIC: " + nic;
                lblPhone.Text = "Contact Number: " + phone;
            }
        }

        private void btnAppointment_Click(object sender, EventArgs e)
        {
            PatientForm patient = new PatientForm();
            patient.Show();
            this.Hide();
        }

        private void btnMoreDetails_Click(object sender, EventArgs e)
        {
            String patientID = txtPatientID.Text;
            Loginform2 login = new Loginform2(patientID);
            login.ShowDialog();
        }
    }
}
