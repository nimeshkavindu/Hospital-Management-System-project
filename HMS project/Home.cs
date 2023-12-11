using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS_project
{
    public partial class Home : Class_closefun
    {
        public Home()
        {
            InitializeComponent();

            
        }

        //Code for the Title bar

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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm(this);
            login.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PatientForm Fpatient = new PatientForm();
            Fpatient.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SearchPatientForm search = new SearchPatientForm();
            search.Show();
            this.Hide();
        }
    }
}
