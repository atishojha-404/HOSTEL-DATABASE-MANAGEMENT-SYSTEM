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
    public partial class Login : Form
    {
        EDCode ed = new EDCode();
        string connectionstring = "Data Source=DESKTOP-VE3HJV5\\ATISH;Initial Catalog = HDBMS;Integrated Security = true;";


        public Login()
        {
            InitializeComponent();
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {


            try
            {

                {
                    SqlConnection con = new SqlConnection(connectionstring);
                    SqlCommand cmd = new SqlCommand("Select * from Register where UserName ='" + txtUserName.Text + "' AND Password='" + ed.PassED(txtPassword.Text) + "'", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    string cmbItemValue = cmbUserType.SelectedItem.ToString();
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (dt.Rows[i]["UserType"].ToString() == cmbItemValue)
                            {
                                MessageBox.Show("You are LogIn as " + dt.Rows[i][5]);
                                if (cmbUserType.SelectedIndex == 0)
                                {
                                    this.Hide();
                                    HDBMS hd = new HDBMS();
                                    hd.Show();
                                }
                                else if (cmbUserType.SelectedIndex == 1)
                                {
                                    this.Hide();
                                    HDBMSUser hdu = new HDBMSUser();
                                    hdu.Show();
                                }
                                else if (cmbUserType.SelectedIndex == 2)
                                {
                                    this.Hide();
                                    HDBMSSupervisor hds = new HDBMSSupervisor();
                                    hds.Show();
                                }

                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please check your Username and Password...!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Something wents wrong...!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void cmbUserType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}





