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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;

namespace HMS_project
{
    public partial class PatientForm : Class_closefun
    {
        SqlConnection conn = new SqlConnection(@"Data Source=XTREMELITE-PC\SQLEXPRESS;Initial Catalog=Users;Integrated Security=True");
        
        private int currentAppointmentNumber = 0;
        public PatientForm()
        {
            InitializeComponent();
        }
        //Code for the Title bar
        private void btnHome_Click(object sender, EventArgs e)
        {
            base.Home_Click(sender, e);
        }

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
        //Registration button
        private void btnRegister_Click(object sender, EventArgs e)
        {

            // Gather patient registration data
            String name = txtName.Text;
            String address = txtAddress.Text;
            DateTime bday = dateTimePicker1.Value;
            String bloodGroup = selectBlood.SelectedIndex.ToString();
            String gender = selectGender.SelectedIndex.ToString();
            String remark = txtRemark.Text;
            int age = int.Parse(txtAge.Text);
            String phone = txtPhone.Text;
            String nic = txtNIC.Text;

            // Check if NIC is already registered
            if (IsNicAlreadyRegistered(nic))
            {
                MessageBox.Show("This person is already registered.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearForm();
                return;
            }


            //Generate Patient ID
            int patientID = GeneratePatientId();

            

            // Insert data into the database
            InsertPatientData(patientID, name, address, bday, age, bloodGroup, gender, phone, nic, remark);

            MessageBox.Show("Patient Registered Successfully!\n" + "Patient ID: " + patientID);
            //recently registered patient
            lblName.Text = "Name:\n" + name;
            lblPatientID.Text ="Patient ID\n" + patientID;

            // Clear the form for the next registration

            ClearForm();

        }
        //Clear button
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void InsertPatientData (int patientID, String name, String address, DateTime dateOfBirth, int age, String bloodGroup, String gender, String phone, String nic, String remark)
        {
            try
            {
                conn.Open();

                String querry = "INSERT INTO regpatient_Table (patientID, name, address, dateOfBirth, age,bloodGroup, gender, phone, nic, remark) " +
                                "VALUES (@PatientID, @Name, @Address, @DateOfBirth, @Age, @BloodGroup, @Gender, @Phone, @NIC, @Remark)";

                using (SqlCommand cmd = new SqlCommand(querry, conn))
                {
                    cmd.Parameters.AddWithValue("@PatientID", patientID);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
                    cmd.Parameters.AddWithValue("@Age", age);
                    cmd.Parameters.AddWithValue("@BloodGroup", bloodGroup);
                    cmd.Parameters.AddWithValue("@Gender", gender);
                    cmd.Parameters.AddWithValue("@Phone", phone);
                    cmd.Parameters.AddWithValue("@NIC", nic);
                    cmd.Parameters.AddWithValue("@Remark", remark);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private void ClearForm()
        {
            txtName.Clear();
            txtAddress.Clear();
            txtAge.Clear();
            txtPhone.Clear();
            txtNIC.Clear();
            txtRemark.Clear();
            selectGender.SelectedIndex = -1;
            selectBlood.SelectedIndex = -1;
            dateTimePicker1.Value = DateTime.Now;
        }

        private int GetCurrentMaxPatientId()
        {
            int maxPatientId = 0;

            try
            {
                conn.Open();

                string query = "SELECT MAX(PatientID) FROM regpatient_Table";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    object result = cmd.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        maxPatientId = Convert.ToInt32(result);
                    }
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

            return maxPatientId;
        }
        //Generate ID for patient

        public int GeneratePatientId()
        {
            int currentMaxPatientId = GetCurrentMaxPatientId();
            return currentMaxPatientId + 1;
        }

        public string GenerateAppointmentNumber()
        {
            currentAppointmentNumber++;
            return $"{currentAppointmentNumber:00}";
        }

        private bool IsNicAlreadyRegistered(string nic)
        {
            try
            {
                conn.Open();

                string query = "SELECT COUNT(*) FROM regpatient_Table WHERE NIC = @NIC";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NIC", nic);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SearchPatientForm search = new SearchPatientForm();
            search.Show();
            this.Hide();
        }

        //Submit registered patient ID
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            String patientID = txtEnterPatientID.Text.Trim();

            if (!string.IsNullOrEmpty(patientID))
            {
                // Fetch patient information from the database
                DataTable patientData = GetPatientData(patientID);

                // Check if patient information is retrieved
                if (patientData.Rows.Count > 0)
                {
                    // Display information in TextBoxes
                    lbl_ID.Text = patientData.Rows[0]["PatientID"].ToString();

                    lbl_Name.Text ="Name: " + patientData.Rows[0]["Name"].ToString();
                    lbl_Address.Text ="Address: " + patientData.Rows[0]["Address"].ToString();
                    lbl_Age.Text = "Age: " + patientData.Rows[0]["Age"].ToString();
                    lbl_NIC.Text = "NIC: " + patientData.Rows[0]["NIC"].ToString();
                    
                }
                else
                {
                    MessageBox.Show("Patient not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter a PatientID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Get patient data from database table
        private DataTable GetPatientData(string patientID)
        {
            DataTable patientData = new DataTable();

            try
            {
                conn.Open();

                string query = "SELECT PatientID, Name, Address, Age, Bloodgroup, Gender, NIC FROM regpatient_Table WHERE PatientID = @PatientID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PatientID", patientID);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(patientData);
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

            return patientData;
        }

        private void btnAppointment_Click(object sender, EventArgs e)
        {
            string patientID = lbl_ID.Text.Trim();

            if (!string.IsNullOrEmpty(patientID))
            {
                // Fetch patient information from the database
                DataTable patientData = GetPatientData(patientID);

                // Check if patient information is retrieved
                if (patientData.Rows.Count > 0)
                {
                    // Extract patient details
                    string appointmentNo = GenerateAppointmentNumber();
                    string name = patientData.Rows[0]["Name"].ToString();
                    int age = Convert.ToInt32(patientData.Rows[0]["Age"]);
                    string bloodGroup = patientData.Rows[0]["BloodGroup"].ToString();
                    string gender = patientData.Rows[0]["Gender"].ToString();
                    lblAppNo.Text = "Appoinment Number:\n" + appointmentNo;

                    // Create a new appointment
                    CreateAppointment(patientID,appointmentNo,name,age,bloodGroup,gender);

                    MessageBox.Show("Appointment created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Patient not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter a PatientID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }

        private void CreateAppointment(String patientID,String appoinmentNo, String name, int age, String bloodGroup, String gender )
        {
            try
            {
                conn.Open();

                string query = "INSERT INTO Appoinments (PatientID, AppoinmentNo, Name, Age, Bloodgroup, Gender) " +
                               "VALUES (@PatientID,@AppoinmentNo, @Name, @Age, @BloodGroup, @Gender)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PatientID", patientID);
                    cmd.Parameters.AddWithValue("@AppoinmentNo", appoinmentNo);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Age", age);
                    cmd.Parameters.AddWithValue("@BloodGroup", bloodGroup);
                    cmd.Parameters.AddWithValue("@Gender", gender);

                    cmd.ExecuteNonQuery();
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


    }
}

