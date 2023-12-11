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
    public partial class Loginform2 : Form
    {
        public string PatientID {get;set;}
        public Loginform2(String patientID)
        {
            InitializeComponent();
            PatientID = patientID;
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
                            ViewMoreDetails details = new ViewMoreDetails(PatientID);
                            details.ShowDialog();
                            this.Hide();
                            break;
                        default:
                            MessageBox.Show("You are not authorized to View user details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }

                    this.Hide();
                    
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
    }
}
