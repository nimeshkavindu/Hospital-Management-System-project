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
    public partial class UserSignUp : Form
    {
        public UserSignUp()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=XTREMELITE-PC\SQLEXPRESS;Initial Catalog=Users;Integrated Security=True");

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            int ID = GenerateId();
            string name = txtName.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;
            string role = txtRole.Text;

            // Validate if username and password are not empty
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate if password and confirm password match
            if (password != confirmPassword)
            {
                MessageBox.Show("Password and confirm password do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if the username already exists in the database
            if (UsernameExists(username))
            {
                MessageBox.Show("Username already exists. Please choose a different username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Signup(ID, name, username, password, role);
           
            

            
            ClearForm();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private bool UsernameExists(string username)
        {

            conn.Open();

            string selectQuery = "SELECT COUNT(*) FROM login_Table WHERE Username = @Username";

            using (SqlCommand command = new SqlCommand(selectQuery, conn))
            {
                command.Parameters.AddWithValue("@Username", username);

                int count = (int)command.ExecuteScalar();

                // If count is greater than 0, the username already exists
                return count > 0;
                
            }

          

        }

        private void ClearForm()
        {
            txtName.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            txtConfirmPassword.Clear();
            txtRole.Clear();


        }

        private void Signup(int ID, string name, string username, string password, string role)
        {
            try
            {
               

                string querry = "INSERT INTO Signup_Table (ID, Name, username, password, role) VALUES (@ID, @Name, @Username, @Password, @Role)";

                using (SqlCommand cmd = new SqlCommand(querry, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.Parameters.AddWithValue("@Role", role);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Pending for admin's approval", "Pending", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Signup: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                string query = "SELECT MAX(ID) FROM Signup_Table";
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
    }
}
