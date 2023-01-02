using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Mobile_Repairs_Mohamed_Ebrahim
{
    class Function
    {
        private SqlConnection Con;
        private SqlCommand Cmd;
        private DataTable dt;
        private SqlDataAdapter sda;
        private String Connstr;

        public Function()
        {
            Connstr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\fg\Desktop\Tasks_C#\Mobile_Repairs_Mohamed_Ebrahim\MobileRepairsDb.mdf;Integrated Security=True;Connect Timeout=30";
            Con = new SqlConnection(Connstr);
            Cmd = new SqlCommand();
            Cmd.Connection = Con;
        }


        public DataTable GetData(String Query)
        {
            dt = new DataTable();
            sda = new SqlDataAdapter(Query, Connstr);
            sda.Fill(dt);
            return dt;
        }

        public int SetData(String Query)
        {
            int cnt = 0;
            if (Con.State == ConnectionState.Closed)
            {
                Con.Open();
            }
            Cmd.CommandText = Query;
            cnt = Cmd.ExecuteNonQuery();
            return cnt;
        }
    }
}
