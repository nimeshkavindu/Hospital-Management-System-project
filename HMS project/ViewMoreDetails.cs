using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS_project
{
    public partial class ViewMoreDetails : Form
    {
        public string PatientID { get; set; }

        public ViewMoreDetails(string patient_ID)
        {
            InitializeComponent();
            PatientID = patient_ID;
            LoadPatientData(patient_ID);
        }
        SqlConnection conn = new SqlConnection(@"Data Source=XTREMELITE-PC\SQLEXPRESS;Initial Catalog=Users;Integrated Security=True");
        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();

        }


        private void ViewMoreDetails_Load(object sender, EventArgs e)
        {
            LoadGridView();
        }


        private void LoadPatientData(string patientID)
        {
            try
            {
                conn.Open();
                string query = "SELECT * FROM regpatient_Table WHERE PatientID = @PatientID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PatientID", patientID);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtPatientID.Text = reader["PatientID"].ToString();
                            txtName.Text = reader["Name"].ToString();
                            txtAge.Text = reader["Age"].ToString();
                            txtAddress.Text = reader["Address"].ToString();
                            txtBDay.Text = reader["Dateofbirth"].ToString();
                            txtPhone.Text = reader["Phone"].ToString();
                            comboGender.Items.Add(reader["Gender"].ToString());
                            comboBlood.Items.Add(reader["Bloodgroup"].ToString());
                            txtRemark.Text = reader["Remark"].ToString();

                        }
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error with Loading Patient Data: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void LoadGridView()
        {
            try
            {
                conn.Open();

                string query = "SELECT * FROM PatientHistory_Table WHERE PatientID = '"+ txtPatientID.Text+"'";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable appointmentsData = new DataTable();
                    adapter.Fill(appointmentsData);

                    dataGridView1.DataSource = appointmentsData;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error with Load GridView: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                string symptoms = selectedRow.Cells["Symptoms"].Value.ToString();
                string prescription = selectedRow.Cells["Prescription"].Value.ToString();
                string comments = selectedRow.Cells["Comments"].Value.ToString();

                //Display items in texbox

                txtSymptoms.Text = symptoms;
                txtComments.Text = comments;
                txtPrescription.Text = prescription;
            }
        }
    }
}
