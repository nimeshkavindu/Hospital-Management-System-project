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
    public partial class LoginForm : Form
    {
        private Home homeForm;

        public LoginForm(Home homeForm)
        {
            InitializeComponent();
            this.homeForm = homeForm;
            this.Shown += LoginForm_Shown;
        }

        //Focus username textbox
        private void LoginForm_Shown(object sender, EventArgs e)
        {
            
            txt_Username.Focus();
        }


        SqlConnection conn = new SqlConnection(@"Data Source=XTREMELITE-PC\SQLEXPRESS;Initial Catalog=Users;Integrated Security=True");

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            String username, password, role;
            username = txt_Username.Text;
            password = txt_Password.Text;

            try
            {
                String query = "SELECT * FROM login_Table WHERE username = @Username AND password = @Password";
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                sda.SelectCommand.Parameters.AddWithValue("@Username", username);
                sda.SelectCommand.Parameters.AddWithValue("@Password", password);

                DataTable dtable = new DataTable();
                sda.Fill(dtable);

                if (dtable.Rows.Count > 0)
                {
                    username = txt_Username.Text;
                    password = txt_Password.Text;
                    role = dtable.Rows[0]["role"].ToString(); 

                    switch (role.ToLower())
                    {
                        case "doctor":
                            DoctorForm docForm = new DoctorForm();
                            docForm.Show();
                            break;

                        case "admin":
                            AdminForm adminForm = new AdminForm();
                            adminForm.Show();
                            break;

                        case "pharmacist":
                            PharmacistForm pharmacistForm = new PharmacistForm();
                            pharmacistForm.Show();
                            break;

                        default:
                            MessageBox.Show("Unknown user", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }

                    this.Hide();
                    homeForm.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid Username or Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btn_signUp_Click(object sender, EventArgs e)
        {
            UserSignUp signUp = new UserSignUp();
            signUp.ShowDialog();
            this.Close();
        }
    }
}
