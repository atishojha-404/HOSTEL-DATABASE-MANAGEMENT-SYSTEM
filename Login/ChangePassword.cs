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
    public partial class ChangePassword : Form
    {
        EDCode ed = new EDCode();

        string connectionstring = "Data Source=DESKTOP-VE3HJV5\\ATISH;Initial Catalog = IMS_09;Integrated Security = true;";
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void btnConformPassword_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionstring);
                SqlDataAdapter da = new SqlDataAdapter("Select count(*) from Register where EmployeeId='"+cmbEmployeeId+"' and UserName ='" + txtUserName.Text + "' and Password='" +ed.PassED(txtOldPassword.Text) + "' and UserType = '" + cmbUserType.Text + "'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    if (txtNewPassword.Text == txtConformPassword.Text)
                    {
                        SqlDataAdapter dc = new SqlDataAdapter("Update Register set Password='" +ed.PassED(txtNewPassword.Text) + "' Where UserName ='" + txtUserName.Text + "' and Password='" + txtOldPassword.Text + "' and UserType = '" + cmbUserType.Text + "' ", con);
                        DataTable df = new DataTable();
                        dc.Fill(df);
                        MessageBox.Show("Password Changed...!!!", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Unmatch Password...!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please check your Username and Password...!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                cmbEmployeeId.SelectedIndex = -1;
                txtUserName.Text = string.Empty;
                txtOldPassword.Text = string.Empty;
                txtNewPassword.Text = string.Empty;
                txtConformPassword.Text = string.Empty;
                cmbUserType.SelectedIndex = -1;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Something wents wrong...!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    
}
