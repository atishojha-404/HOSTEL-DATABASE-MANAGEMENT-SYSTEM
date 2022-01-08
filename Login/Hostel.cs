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
    public partial class Hostel : Form
    {
        string connectionstring = "Data Source=DESKTOP-VE3HJV5\\ATISH;Initial Catalog = HDBMS;Integrated Security = true;";

        public Hostel()
        {
            InitializeComponent();
        }

        private void txtLocation_TextChanged(object sender, EventArgs e)
        {


        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ClearForm()
        {
            cmbBuildingNum.SelectedIndex = -1;
            cmbNumOfRoom.SelectedIndex = -1;
            cmbNumOfStundent.SelectedIndex = -1;
            txtLocation.Text = string.Empty;
           
        }


        private bool FormValidation()
        {
            if (cmbBuildingNum.Text == string.Empty)
            {
                MessageBox.Show("Building num  is required...!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbBuildingNum.Focus();
                return false;
            }
            if (cmbNumOfRoom.Text == string.Empty)
            {
                int OutRoNum = 0;
                bool isRoNumint = int.TryParse(cmbNumOfRoom.Text, out OutRoNum);
                if (isRoNumint == false)
                {
                    MessageBox.Show("Num Of Room  should be in Number...!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbNumOfRoom.Text = string.Empty;
                    cmbNumOfRoom.Focus();
                    return false;
                }
              
            }
            if (cmbNumOfStundent.Text == string.Empty)
            {

                int OutStNum = 0;
                bool isStNumint = int.TryParse(cmbNumOfStundent.Text, out OutStNum);
                if (isStNumint == false)
                {
                    MessageBox.Show("Num Of Student should be in Number...!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbNumOfStundent.Text = string.Empty;
                    cmbNumOfStundent.Focus();
                    return false;
                }
                
            }
            if (txtLocation.Text == string.Empty)
            {
                MessageBox.Show("Location is required...!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLocation.Focus();
                return false;
            }


            return true;
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
                            cmd.CommandText = "INSERT INTO Hostel (BuildingNum,NumOfRoom,NumOfStudent,Location) VALUES (@BuildingNum,@NumOfRoom,@NumOfStudent,@Location) ";
                            cmd.Parameters.AddWithValue("@BuildingNum", cmbBuildingNum.Text);
                            cmd.Parameters.AddWithValue("@NumOfRoom", cmbNumOfRoom.Text);
                            cmd.Parameters.AddWithValue("@NumOfStudent", cmbNumOfStundent.Text);
                            cmd.Parameters.AddWithValue("@Location", txtLocation.Text);
                            
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
    }
}
