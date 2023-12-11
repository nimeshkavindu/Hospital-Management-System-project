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
    public partial class DoctorForm : Class_closefun
    {
        
        public DoctorForm()
        {
            InitializeComponent();
            LoadAppointments();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=XTREMELITE-PC\SQLEXPRESS;Initial Catalog=Users;Integrated Security=True");

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
        //Load Data Grid View
        private void LoadAppointments()
        {
            try
            {
                conn.Open();

                string query = "SELECT Name, AppoinmentNo, PatientID, Age, Bloodgroup, Gender FROM Appoinments";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable appointmentsData = new DataTable();
                    adapter.Fill(appointmentsData);

                    dataGridViewAppointments.DataSource = appointmentsData;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }


        private void btnSubmit_Click(object sender, EventArgs e)
        {
            DialogResult logout = MessageBox.Show("Are you sure you want to Logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if(logout == DialogResult.Yes)
            {
                Home home = new Home();
                home.Show();

                this.Close();
            }
        }

        private void btnRefreshGrid_Click(object sender, EventArgs e)
        {
            dataGridViewAppointments.Refresh();
        }

        private void DoctorForm_Load(object sender, EventArgs e)
        {
            //Connect selectDrugs combobox with Drugs table
            comboboxload();

            selectDrugs.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            selectDrugs.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        //Connect selectDrugs combobox with Drugs table
        private void comboboxload()
        {
            String querry = "SELECT DrugID, DrugName FROM Drugs";

            SqlCommand cmd = new SqlCommand(querry, conn);
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;

            DataTable dt = new DataTable();
            sda.Fill(dt);

            selectDrugs.DataSource = dt;
            selectDrugs.DisplayMember = "DrugName";
            selectDrugs.ValueMember = "DrugID";

            selectDrugs.SelectedIndex = -1;
        }

        //Add selected drugs to list
        private void btn_Add_Click(object sender, EventArgs e)
        {
            //Add selected Drug to the list
            DataRowView selectedDataRowView = (DataRowView)selectDrugs.SelectedItem;
            string drugName = selectedDataRowView["DrugName"].ToString();

            object dosage = comboDosage.SelectedItem;
            object frequency = comboFrequency.SelectedItem;
            object period = comboPeriod.SelectedItem;

            drugList.Items.Add(drugName + " | " + dosage + " | " + frequency + " | " + period);

            //Clear Comboboxes
            selectDrugs.SelectedIndex = -1;
            comboDosage.SelectedIndex = -1;
            comboFrequency.SelectedIndex = -1;
            comboPeriod.SelectedIndex = -1;


        }

        private void btnSendToPharma_Click(object sender, EventArgs e)
        {
            SendtoPharma();
            AddtoHistory();
            RemovefromPending();
            LoadAppointments();
            Cleartext();
        }

        private void btnMoreDetails_Click(object sender, EventArgs e)
        {
            string patientID = txtPatientID.Text;

            ViewMoreDetails more = new ViewMoreDetails(patientID);
            more.ShowDialog();

        }
        //Send prescription to pharmacy
        private void SendtoPharma()
        {
            try
            {
                conn.Open();

                string patientID = txtPatientID.Text;
                string appointmentNo = txtAppNo.Text;
                string name = txtName.Text;
                string prescription = "";
                foreach (string item in drugList.Items)
                {
                    prescription += item + "\n";
                }

                // Create a parameterized SQL query
                string query = "INSERT INTO Prescription_Table (PatientID, AppointmentNO, Name, Prescription) " +
                               "VALUES (@PatientID, @AppointmentNo, @Name, @Prescription)";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    // Add parameters
                    command.Parameters.AddWithValue("@Prescription", prescription);
                    command.Parameters.AddWithValue("@PatientID", patientID);
                    command.Parameters.AddWithValue("@AppointmentNo", appointmentNo);
                    command.Parameters.AddWithValue("@Name", name);

                    // Execute the query
                    command.ExecuteNonQuery();
                }

                conn.Close();

                MessageBox.Show("Prescription Sent to the Pharmacy Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Add details to patient history
        private void AddtoHistory()
        {
            try
            {
                conn.Open();
                // Extract additional information (PatientID, AppointmentNo, Name)
                string patientID = txtPatientID.Text;
                string symptoms = txtSymptoms.Text;
                string comments = txtComments.Text;
                string prescription = "";
                foreach (string item in drugList.Items)
                {
                    prescription += item + "\n";
                }
                // Create a parameterized SQL query
                string query = "INSERT INTO PatientHistory_Table (PatientID, Symptoms, Prescription, Comments) " +
                               "VALUES (@PatientID, @Symptoms, @Prescription, @Comments)";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    // Add parameters
                    command.Parameters.AddWithValue("@Prescription", prescription);
                    command.Parameters.AddWithValue("@PatientID", patientID);
                    command.Parameters.AddWithValue("@Symptoms", symptoms);
                    command.Parameters.AddWithValue("@Comments", comments);

                    // Execute the query
                    command.ExecuteNonQuery();
                }


                conn.Close();
             
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //remove patient from pending list
        private void RemovefromPending()
        {
            int patientID = Convert.ToInt32(txtPatientID.Text);
            conn.Open();

            string deleteQuery = "DELETE FROM Appoinments WHERE PatientID = @PatientID";

            using (SqlCommand command = new SqlCommand(deleteQuery, conn))
            {
                // Add parameters to the query
                command.Parameters.AddWithValue("@PatientID", patientID);

                // Execute the DELETE query
                command.ExecuteNonQuery();
            }
            conn.Close();
        }

        private void Cleartext()
        {
            txtSymptoms.Clear();
            txtComments.Clear();
            drugList.Items.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string newDrug = txtNewDrug.Text;
            drugList.Items.Add(newDrug);

            txtNewDrug.Clear();
        }

        private void dataGridViewAppointments_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridViewAppointments.Rows.Count)
            {
                DataGridViewRow selectedRow = dataGridViewAppointments.Rows[e.RowIndex];

                string appNo = selectedRow.Cells["AppoinmentNo"].Value.ToString();
                string patientID = selectedRow.Cells["PatientID"].Value.ToString();
                string name = selectedRow.Cells["Name"].Value.ToString();
                int age = Convert.ToInt32(selectedRow.Cells["Age"].Value);
                int bloodGroup = Convert.ToInt32(selectedRow.Cells["Bloodgroup"].Value);
                int gender = Convert.ToInt32(selectedRow.Cells["Gender"].Value);

                //Display items in texbox
                txtAppNo.Text = appNo;
                txtPatientID.Text = patientID;
                txtName.Text = name;
                txtAge.Text = age.ToString();
                comboBlood.SelectedIndex = bloodGroup;
                comboGender.SelectedIndex = gender;


            }

        }
    }
}
