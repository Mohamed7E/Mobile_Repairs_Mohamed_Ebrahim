using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Mobile_Repairs_Mohamed_Ebrahim
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (UNameTb.Text == "" || Password.Text == "")
            {
                MessageBox.Show("Missing Data !!!!");
            }
            else if (UNameTb.Text == "Mohamed" && Password.Text == "Ebrahim")
            {
                Customers Custform = new Customers();
                Custform.Show();
                this.Hide();
            }
            else
            {
                UNameTb.Text = "";
                Password.Text = "";

            }
        }
    }
}
