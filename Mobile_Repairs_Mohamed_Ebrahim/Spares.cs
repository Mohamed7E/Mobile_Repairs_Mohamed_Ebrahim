﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Mobile_Repairs_Mohamed_Ebrahim
{
    public partial class Spares : Form
    {
        Function con;
        public Spares()
        {
            InitializeComponent();
            con = new Function();
            ShowSpare();
        }
        private void ShowSpare()
        {
            String Query = "Select * from SpareTb";
            PartsList.DataSource = con.GetData(Query);
        }
        private void clear()
        {
            PartNameTb.Text = "";
            PartCostTb.Text = "";
        }
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (PartNameTb.Text == "" || PartCostTb.Text == "")
            {
                MessageBox.Show("Missing Data");
            }
            else
            {
                try
                {
                    String PName = PartNameTb.Text;
                    int PCost = Convert.ToInt32(PartCostTb.Text);
                    String Query = "insert into SpareTb values ('{0}',{1})";
                    Query = String.Format(Query, PName, PCost);
                    con.SetData(Query);
                    MessageBox.Show("Spare Add !!!!");
                    ShowSpare();
                    clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        int key = 0;
        private void PartsList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PartNameTb.Text = PartsList.SelectedRows[0].Cells[1].Value.ToString();
            PartCostTb.Text = PartsList.SelectedRows[0].Cells[2].Value.ToString();
            if (PartNameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(PartsList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (PartNameTb.Text == "" || PartCostTb.Text == "")
            {
                MessageBox.Show("Missing Data");
            }
            else
            {
                try
                {
                    String PName = PartNameTb.Text;
                    int PCost = Convert.ToInt32(PartCostTb.Text);
                    String Query = "Update SpareTb set SpNzme = '{0}', SpCost = {1} where SpCode ={2}";
                    Query = String.Format(Query, PName, PCost, key);
                    con.SetData(Query);
                    MessageBox.Show("Spare Updated !!!!");
                    ShowSpare();
                    clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select Spare");
            }
            else
            {
                try
                {
                    String Query = "Delete from SpareTb where SpCode = {0}";
                    Query = String.Format(Query, key);
                    con.SetData(Query);
                    MessageBox.Show("Spare Deleted !!!!");
                    ShowSpare();
                    clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            login obj = new login();
            obj.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Spares obj = new Spares();
            obj.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Repairs obj = new Repairs();
            obj.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Customers obj = new Customers();
            obj.Show();
            this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
