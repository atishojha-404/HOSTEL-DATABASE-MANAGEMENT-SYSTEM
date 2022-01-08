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
    public partial class MessEmployee : Form
    {
        string connectionstring = "Data Source=DESKTOP-VE3HJV5\\ATISH;Initial Catalog = HDBMS;Integrated Security = true;";

        public MessEmployee()
        {
            InitializeComponent();
        }
        private bool FormValidation()
        {
            if (txtEmployeeName.Text == string.Empty)
            {
                MessageBox.Show("Employee Name is required...!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmployeeName.Focus();
                return false;
            }
            if (txtAddress.Text == string.Empty)
            {
                MessageBox.Show("Address is required...!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddress.Focus();
                return false;
            }
           
            if (txtEmployeeSalary.Text != string.Empty)
            {
                Decimal outSalary = 0;
                bool isSalaryDecimal = decimal.TryParse(txtEmployeeSalary.Text, out outSalary);
                if (isSalaryDecimal == false)
                {
                    MessageBox.Show("Employee Salary should be in Decimal...!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmployeeSalary.Text = string.Empty;
                    txtEmployeeSalary.Focus();
                    return false;
                }
            }
            if (txtContact.Text == string.Empty)
            {
                MessageBox.Show("Contact is required...!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContact.Focus();
                return false;
            }
            if (cmbHBN.Text == string.Empty)
            {
                MessageBox.Show("Hostel Building num  is required...!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbHBN.Focus();
                return false;
            }
            if (txtHoselIncharge.Text == string.Empty)
            {
                MessageBox.Show("Hostel Incharge is required...!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoselIncharge.Focus();
                return false;
            }


            return true;
        }

        private void ClearForm()
        {
            txtEmployeeName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtEmployeeSalary.Text = string.Empty;
            txtContact.Text = string.Empty;
            cmbHBN.SelectedIndex = -1;
            txtHoselIncharge.Text = string.Empty;

        }


        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                var confirm = MessageBox.Show("Do you want to Submit?", "confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (confirm.ToString().ToUpper() == "OK")
                {

                    using (SqlConnection con = new SqlConnection(connectionstring))
                    {
                        bool isValiationSucess = FormValidation();
                        if (isValiationSucess == true)
                        {
                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = con;
                            cmd.CommandType = CommandType.Text;
                            con.Open();
                            cmd.CommandText = @"INSERT INTO tblMessEmployee (EmployeeName,Address,EmployeeSalary,Contact,HostelBuildingNum,MessIncharge) 
                                               VALUES (@EmployeeName,@Address,@EmployeeSalary,@Contact,@HostelBuildingNum,@MessIncharge) ";
                            cmd.Parameters.AddWithValue("@EmployeeName", txtEmployeeName.Text);
                            cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                            cmd.Parameters.AddWithValue("@EmployeeSalary", txtEmployeeSalary.Text);
                            cmd.Parameters.AddWithValue("@Contact", txtContact.Text);
                            cmd.Parameters.AddWithValue("@HostelBuildingNum", cmbHBN.Text);
                            cmd.Parameters.AddWithValue("@MessIncharge", txtHoselIncharge.Text);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Record saved sucessfully...!!!", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearForm();
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something wents wrong...!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearForm();

        }



        private void cmbHostelIncharge_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
