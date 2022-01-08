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

namespace Login
{
    public partial class VisitorReport : Form
    {
        public VisitorReport()
        {
            InitializeComponent();
        }

        string connectionstring = "Data Source=DESKTOP-VE3HJV5\\ATISH;Initial Catalog = HDBMS;Integrated Security = true;";

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionstring))
                {

                    string fromDate = txtFromDate.Text;
                    string toDate = txtToDate.Text;
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    con.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"Select Date,VisitorName,Timein,Timeout,StudentId From Visitor  WHERE Date BETWEEN '" + fromDate + "' and  '" + toDate + "' ";
                                     
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    gvVisitorReport.DataSource = dt;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Something wents wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionstring))

                {

                    string fromDate = txtFromDate.Text;
                    string toDate = txtToDate.Text;
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    con.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"Select s.StudentName,v.Date,v.VisitorName,v.Timein,v.Timeout From Visitor v
                                       INNER JOIN Student s on s.StudentId = v.StudentId
                                      WHERE Date BETWEEN '" + fromDate + "' and  '" + toDate + "' ";

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    gvVisitorReport.DataSource = dt;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Something wents wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
