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
    public partial class EmployeeReport : Form
    {
        public EmployeeReport()
        {
            InitializeComponent();
        }
        string connectionstring = "Data Source=DESKTOP-VE3HJV5\\ATISH;Initial Catalog = HDBMS;Integrated Security = true;";


        private void button1_Click(object sender, EventArgs e)
        {

        }



        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                {
                    SqlConnection con = new SqlConnection(connectionstring);
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    cmd.CommandText = @"SELECT EmployeeId,EmployeeName,Address,EmployeeSalary, Contact,HostelBuildingNum,MessIncharge FROM tblMessEmployee
                                     where EmployeeId Like @Search OR EmployeeName Like @Search OR Address Like @Search OR EmployeeSalary Like @Search OR Contact Like @Search OR HostelBuildingNum Like @Search OR MessIncharge Like @Search";
                    cmd.Parameters.AddWithValue("@Search", "%" + txtSearch.Text + "%");
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    gvEmployeeReport.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong", "Error-!", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }

        }

        private void gvEmployeeReport_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
