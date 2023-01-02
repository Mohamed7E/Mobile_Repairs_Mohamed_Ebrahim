using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Mobile_Repairs_Mohamed_Ebrahim
{
    public partial class Repairs : Form
    {
        Function con;
        public Repairs()
        {
            InitializeComponent();
            con = new Function();
            ShowRepairs();
        }
        private void ShowRepairs()
        {
            string Query = "Select * from RepairTB";
            SparesList.DataSource = con.GetData(Query);

        }
        private void GetCustomer()
        {
            string Query = "Select * from CustomerTb";
            CustCb.DisplayMember = con.GetData(Query).Columns["CustName"].ToString();
            CustCb.ValueMember = con.GetData(Query).Columns["CustCode"].ToString();
            CustCb.DataSource = con.GetData(Query);
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (CustCb.SelectedIndex == -1 || PhoneTb.Text == "" || ProblemTb.Text == "" || DNameTb.Text == ""
               || ModelTb.Text == "" || SpareCb.SelectedIndex == -1 || TotalTb.Text == "" || SpareCostTb.Text == "")
            {
                MessageBox.Show("Missing Data");
            }
            else
            {
                try
                {
                    string RDate = RepDateTb.Value.Date.ToString("yyyyMMdd");
                    int Customer = Convert.ToInt32(CustCb.SelectedValue.ToString());
                    string CPhone = PhoneTb.Text;
                    string DeviceName = DNameTb.Text;
                    string DeviceModle = ModelTb.Text;
                    string Problem = ProblemTb.Text;
                    int Spare = Convert.ToInt32(SpareCb.SelectedValue.ToString());
                    int Total = Convert.ToInt32(TotalTb.Text);
                    int GrdTotal = Convert.ToInt32(SpareCostTb.Text) + Total;
                    string Query = "insert into RepairTB values ('{0}',{1},'{2}','{3}','{4}','{5}',{6},{7})";
                    Query = string.Format(Query, RDate, Customer, CPhone, DeviceName, DeviceModle, Problem, Spare, GrdTotal);
                    con.SetData(Query);
                    MessageBox.Show("Repair Add !!!!");
                    ShowRepairs();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
    }
}
