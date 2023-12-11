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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Xml.Linq;

namespace HMS_project
{
    public partial class usermanagement : Form
    {
        public usermanagement()
        {
            InitializeComponent();

        }

        SqlConnection conn = new SqlConnection(@"Data Source=XTREMELITE-PC\SQLEXPRESS;Initial Catalog=Users;Integrated Security=True");

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void usermanagement_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                conn.Open();
                string query = "SELECT * FROM login_Table";
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddData();
            LoadData();
            Clearform();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateData();
            LoadData();
            Clearform();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteData();
            LoadData();
            Clearform();
        }

        private void AddData()
        {
            string name = txtName.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string role = txtRole.Text;
            string userID = txtUserID.Text;
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void UpdateData()
        {
            string name = txtName.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string role = txtRole.Text;
            string userID = txtUserID.Text;

            try
            {
                conn.Open();

                string updateQuery = "UPDATE login_Table SET Name = @Name, username = @Username, password = @Password, role = @Role WHERE UserID = @UserID";

                using (SqlCommand command = new SqlCommand(updateQuery, conn))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@Role", role);
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

        private void DeleteData()
        {
            string name = txtName.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string role = txtRole.Text;
            string userID = txtUserID.Text;

            try
            {
                conn.Open();

                string updateQuery = "DELETE FROM login_Table WHERE UserID = @UserID";

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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                string userID = selectedRow.Cells["UserID"].Value.ToString();
                string name = selectedRow.Cells["Name"].Value.ToString();
                string username = selectedRow.Cells["username"].Value.ToString();
                string password = selectedRow.Cells["password"].Value.ToString();
                string role = selectedRow.Cells["role"].Value.ToString();

                txtUserID.Text = userID;
                txtName.Text = name;
                txtUsername.Text = username;
                txtPassword.Text = password;
                txtRole.Text = role;
            }
        }

        private void Clearform()
        {
            txtName.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            txtRole.Clear();
            txtUserID.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clearform();
        }
    }
}
