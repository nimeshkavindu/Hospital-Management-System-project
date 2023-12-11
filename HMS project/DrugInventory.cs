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
using System.Drawing.Printing;

namespace HMS_project
{
    public partial class DrugInventory : Form
    {
        public DrugInventory()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=XTREMELITE-PC\SQLEXPRESS;Initial Catalog=Users;Integrated Security=True");

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DrugInventory_Load(object sender, EventArgs e)
        {
            LoadDrugData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string drugID = txtDrugID.Text;
            string drugName = txtName.Text;
            int quantity = Convert.ToInt32(txtQuantity.Text);
            

            AddDrug(drugID, drugName, quantity);

            // Clear input fields after adding a drug
            txtDrugID.Clear();
            txtName.Clear();
            txtQuantity.Clear();

            LoadDrugData();
        }

       

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Check if a row is selected in the DataGridView
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Confirm deletion with the user
                DialogResult result = MessageBox.Show("Are you sure you want to delete this drug?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Get the selected row
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                    // Get the drug information from the selected row
                    int drugId = Convert.ToInt32(selectedRow.Cells["DrugID"].Value);
                    string drugName = selectedRow.Cells["DrugName"].Value.ToString();
                    int quantity = Convert.ToInt32(selectedRow.Cells["Quantity"].Value);
                    //Delete logic

                    conn.Open();

                    
                    string deleteQuery = "DELETE FROM Drugs WHERE DrugID = @DrugID";

                    using (SqlCommand command = new SqlCommand(deleteQuery, conn))
                    {
                        
                        command.Parameters.AddWithValue("@DrugID", drugId);

                        
                        command.ExecuteNonQuery();
                    }
                    conn.Close();
                    
                    // After deletion, reload the drug data
                    LoadDrugData();
                }
            }
        }
        private void LoadDrugData()
        {
            try
            {
                conn.Open();
                string query = "SELECT DrugID, DrugName, Quantity FROM Drugs";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
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

        private void AddDrug(string drugID, string drugName, int quantity )
        {
            try
            {
                conn.Open();

                // Check if the drug already exists in the inventory
                string checkQuery = "SELECT DrugID, Quantity FROM Drugs WHERE DrugName = @DrugName";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@DrugName", drugName);

                    SqlDataReader reader = checkCmd.ExecuteReader();
                    if (reader.Read())
                    {
                        // If the drug exists, update the quantity
                        int existingDrugId = reader.GetInt32(0);
                        int existingQuantity = reader.GetInt32(1);
                        reader.Close();

                        int newQuantity = existingQuantity + quantity;

                        // Update the quantity of the existing drug
                        string updateQuery = "UPDATE Drugs SET Quantity = @NewQuantity WHERE DrugID = @ExistingDrugId";
                        using (SqlCommand updateCmd = new SqlCommand(updateQuery, conn))
                        {
                            updateCmd.Parameters.AddWithValue("@NewQuantity", newQuantity);
                            updateCmd.Parameters.AddWithValue("@ExistingDrugId", existingDrugId);

                            updateCmd.ExecuteNonQuery();
                        }
                        
                    }
                    else
                    {
                        reader.Close();

                        // If the drug doesn't exist, insert a new record
                        string insertQuery = "INSERT INTO Drugs (DrugID, DrugName, Quantity) VALUES (@DrugID, @DrugName, @Quantity)";
                        using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                        {
                            insertCmd.Parameters.AddWithValue("@DrugID", drugID);
                            insertCmd.Parameters.AddWithValue("@DrugName", drugName);
                            insertCmd.Parameters.AddWithValue("@Quantity", quantity);
                            

                            insertCmd.ExecuteNonQuery();
                        }
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

            LoadDrugData();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printDialog1.Document = printDocument1;

            // Show the PrintDialog
            DialogResult result = printDialog1.ShowDialog();

            // If the user clicks OK in the PrintDialog, print the document
            if (result == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Bitmap drugview = new Bitmap(dataGridView1.Width, dataGridView1.Height);
            dataGridView1.DrawToBitmap(drugview, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));
            e.Graphics.DrawImage(drugview, 120, 20);
        }
    }
}
