using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS_project
{
    public class Class_closefun : Form
    {
        private bool isMaximized = false;
        private int storedWidth, storedHeight;
        //Code for the Title bar
        public Class_closefun()
        {
            //Create Minimize button
            Button btnMinimize = new Button();
            btnMinimize.Text = "Minimize";
            btnMinimize.Click += new EventHandler(btnMinimize_Click);


            //Create Maximize button
            Button btnMaximize = new Button();
            btnMaximize.Text = "Maximize";
            btnMaximize.Click += new EventHandler(btnMaximize_Click);


            //Create Close button
            Button btnClose = new Button();
            btnClose.Text = "Close";
            btnClose.Click += new EventHandler(btnClose_Click);

            
        }


        public void btnMinimize_Click(object sender, EventArgs e)
        {
            // Minimize the form
            this.WindowState = FormWindowState.Minimized;
        }

        public void btnMaximize_Click(object sender, EventArgs e)
        {
            if (isMaximized)
            {
                // Restore down
                this.WindowState = FormWindowState.Normal;
                isMaximized = false;
            }
            else
            {
                // Maximize
                storedWidth = this.Width;
                storedHeight = this.Height;
                this.WindowState = FormWindowState.Maximized;
                isMaximized = true;
            }
        }

        public void btnClose_Click(object sender, EventArgs e)
        {

            DialogResult close = MessageBox.Show("Are you sure You want to Exit?", "Warning",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);

            if (close == DialogResult.Yes)
            {
                Application.Exit();
            }
            

        }

        public void Home_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }
    }
}
