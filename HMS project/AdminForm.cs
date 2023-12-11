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
    public partial class AdminForm : Class_closefun
    {
        public AdminForm()
        {
            InitializeComponent();
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

        private void AdminForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnUserManagement_Click(object sender, EventArgs e)
        {
            usermanagement user = new usermanagement();
            user.ShowDialog();
        }


        private void btnPatientManagement_Click(object sender, EventArgs e)
        {

        }

        private void LoadData()
        {
            try
            {
                conn.Open();
                string querry = "SELECT * FROM Signup_Table";

                using (SqlCommand cmd = new SqlCommand(querry, conn))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    dataGridView1.DataSource = table;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in connecting datagridview" + ex.Message);
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
                string userID = selectedRow.Cells["ID"].Value.ToString();
                string name = selectedRow.Cells["Name"].Value.ToString();
                string username = selectedRow.Cells["username"].Value.ToString();
                string password = selectedRow.Cells["password"].Value.ToString();
                string role = selectedRow.Cells["role"].Value.ToString();


                //Display items in texbox
                txtName.Text = name;
                txtUsername.Text = username;
                txtPassword.Text = password;
                txtRole.Text = role;
                txtUserID.Text = userID;



            }
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            approve();
            reject();
            LoadData();
            ClearForm();
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            reject();
            LoadData();
            ClearForm();
        }

        private void approve()
        {
            string name = txtName.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string role = txtRole.Text;
            int userID = GenerateId(); 
            try
            {
                conn.Open();

                string insertQuery = "INSERT INTO login_Table (UserID, Name, username, password, role) VALUES (@UserID, @Name, @Username, @Password, @Role)";

                using (SqlCommand command = new SqlCommand(insertQuery, conn))
                {
                    command.Parameters.AddWithValue("@UserID", userID);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@Role", role);


                    command.ExecuteNonQuery();

                    MessageBox.Show("User added successfully");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void reject()
        {
            string name = txtName.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string role = txtRole.Text;
            string userID = txtUserID.Text;

            try
            {
                conn.Open();

                string updateQuery = "DELETE FROM Signup_Table WHERE ID = @UserID";

                using (SqlCommand command = new SqlCommand(updateQuery, conn))
                {

                    command.Parameters.AddWithValue("@UserID", userID);

                    command.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private int GetCurrentMaxId()
        {
            int maxId = 0;

            try
            {
                conn.Open();

                string query = "SELECT MAX(UserID) FROM login_Table";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    object result = cmd.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        maxId = Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Generating ID: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }

            return maxId;
        }
        //Generate ID for Users

        public int GenerateId()
        {
            int currentMaxId = GetCurrentMaxId();
            return currentMaxId + 1;
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

        private void ClearForm()
        {
            txtName.Clear();
            txtPassword.Clear();
            txtRole.Clear();
            txtUserID.Clear();
            txtUsername.Clear();
        }
    }
}
