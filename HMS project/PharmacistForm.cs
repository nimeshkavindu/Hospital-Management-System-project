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
    public partial class PharmacistForm : Class_closefun
    {
        public PharmacistForm()
        {
            InitializeComponent();
            LoadPrescriptions();
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

        private void button1_Click(object sender, EventArgs e)
        {
            DrugInventory drugs = new DrugInventory();
            drugs.ShowDialog();
        }

        //Load prescription table to datagridview

        private void LoadPrescriptions()
        {
            try
            {
                conn.Open();

                string query = "SELECT PatientID, AppointmentNO, Name, Prescription FROM Prescription_Table";

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
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }


        //Remove patient fom pending list
        private void RemovefromPending()
        {
            int patientID = Convert.ToInt32(txtPatientID.Text);
            conn.Open();

            string deleteQuery = "DELETE FROM Prescription_Table WHERE PatientID = @PatientID";

            using (SqlCommand command = new SqlCommand(deleteQuery, conn))
            {
                // Add parameters to the query
                command.Parameters.AddWithValue("@PatientID", patientID);

                // Execute the DELETE query
                command.ExecuteNonQuery();
            }
            conn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                string appNo = selectedRow.Cells["AppointmentNO"].Value.ToString();
                string patientID = selectedRow.Cells["PatientID"].Value.ToString();
                string name = selectedRow.Cells["Name"].Value.ToString();
                string prescription = selectedRow.Cells["Prescription"].Value.ToString();

                //Display items in texbox
                txtAppNo.Text = appNo;
                txtPatientID.Text = patientID;
                txtName.Text = name;
                txtPrescription.Text = prescription;



            }
        }

        private void txtDrugName_TextChanged(object sender, EventArgs e)
        {
            DrugSuggest();
        }


       
        private void PharmacistForm_Load(object sender, EventArgs e)
        {
            

        }

        private void DrugSuggest()
        {
            try
            {
                AutoCompleteStringCollection col = new AutoCompleteStringCollection();
                conn.Open();
                string querry = "SELECT DrugName From Drugs";

                SqlCommand cmd = new SqlCommand(querry, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    // Add suggestions to AutoCompleteCustomSource
                    col.Add(reader["DrugName"].ToString());
                }
                reader.Close();

                txtDrugName.AutoCompleteCustomSource = col;
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string drugName = txtDrugName.Text.Trim();
            int neededAmount;

            if (string.IsNullOrEmpty(drugName) || !int.TryParse(txtAmount.Text, out neededAmount))
            {
                MessageBox.Show("Please enter valid drug name and amount.");
                return;
            }

            // Check if drug is available in the database
            if (IsDrugAvailable(drugName))
            {
                // Check if the needed amount is available in stock
                if (IsStockAvailable(drugName, neededAmount))
                {
                    // Reduce stock amount in the database
                    ReduceStock(drugName, neededAmount);

                    // Add drug to dispensed drugs list
                    dispensedDrugs.Items.Add(drugName);
                    
                }
                else
                {
                    // Add drug to purchase list if needed amount is not available
                    purchaseDrugs.Items.Add(drugName);
                    MessageBox.Show($"Insufficient stock for {drugName}. Added to purchase list.");
                }
            }
            else
            {
                // Add drug to purchase list if it is not available
                purchaseDrugs.Items.Add(drugName);
                MessageBox.Show($"{drugName} not available in the pharmacy. Added to purchase list.");
            }

            txtDrugName.Clear();
            txtAmount.Clear();
        }

        private bool IsDrugAvailable(string drugName)
        {
            
            string query = $"SELECT COUNT(*) FROM Drugs WHERE DrugName = '{drugName}'";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                conn.Close();
                return count > 0;
            }
        }

        private bool IsStockAvailable(string drugName, int neededAmount)
        {
            
            string query = $"SELECT Quantity FROM Drugs WHERE DrugName = '{drugName}'";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                int quantity = (int)cmd.ExecuteScalar();
                conn.Close();
                return quantity >= neededAmount;
            }
        }

        private void ReduceStock(string drugName, int reductionAmount)
        {
            
            string query = $"UPDATE Drugs SET Quantity = Quantity - {reductionAmount} WHERE DrugName = '{drugName}'";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            DialogResult logout = MessageBox.Show("Are you sure you want to Logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (logout == DialogResult.Yes)
            {
                Home home = new Home();
                home.Show();

                this.Close();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument1; 

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
               
                printDocument1.Print();
            }

            RemovefromPending();


        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // Patient information
            string patientInfo = $"Patient ID: {txtPatientID.Text}\nName: {txtName.Text}\nPrescription: {txtPrescription.Text}\n\n";

            // Dispensed drugs
            string dispensedDrugsInfo = "Dispensed Drugs:\n";
            foreach (var item in dispensedDrugs.Items)
            {
                dispensedDrugsInfo += $"{item}\n";
            }

            // Purchase drugs
            string purchaseDrugsInfo = "\nPurchase Drugs:\n";
            foreach (var item in purchaseDrugs.Items)
            {
                purchaseDrugsInfo += $"{item}\n";
            }

            // Combine all information
            string contentToPrint = patientInfo + dispensedDrugsInfo + purchaseDrugsInfo;

            
            Font printFont = new Font("Arial", 12);
            SolidBrush brush = new SolidBrush(Color.Black);

            
            RectangleF rect = new RectangleF(e.MarginBounds.Left, e.MarginBounds.Top, e.MarginBounds.Width, e.MarginBounds.Height);

            
            e.Graphics.DrawString(contentToPrint, printFont, brush, rect, StringFormat.GenericTypographic);
        }

        
    }
}
