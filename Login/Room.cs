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
    public partial class Room : Form
    {
        string connectionstring = "Data Source=DESKTOP-VE3HJV5\\ATISH;Initial Catalog = HDBMS;Integrated Security = true;";

        public Room()
        {
            InitializeComponent();
        }

        private void ClearForm()
        {
            cmbRoomNum.SelectedIndex = -1;
            cmbCapacity.SelectedIndex = -1;
            checkFurlist.SelectedIndex = -1;
            cmbBHBN.SelectedIndex = -1;

        }
        private bool FormValidation()
        {
            if (cmbRoomNum.Text != string.Empty)
            {
                int outRoomId = 0;
                bool isRoomIdint = int.TryParse(cmbRoomNum.Text, out outRoomId);
                if (isRoomIdint == false)
                {
                    MessageBox.Show("Room Id is required...!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbRoomNum.Text = string.Empty;
                    cmbRoomNum.Focus();
                    return false;
                }
               
            }
            if (cmbCapacity.Text != string.Empty)
            {
                int outCapacity = 0;
                bool isCapacityint = int.TryParse(cmbCapacity.Text, out outCapacity);
                if (isCapacityint == false)
                {
                    MessageBox.Show("Capacity is required...!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbCapacity.Text = string.Empty;
                    cmbCapacity.Focus();
                    return false;
                }
              
            }
            if (checkFurlist.Text == string.Empty)
            {
                MessageBox.Show("Furniture is required...!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                checkFurlist.Focus();
                return false;
            }
            if (cmbBHBN.Text == string.Empty)
            {
                MessageBox.Show("Boys Hostel Building num  is required...!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbBHBN.Focus();
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
                            cmd.CommandText = "INSERT INTO Room (Capacity,Furniture,BoysHostelBuildingNum) VALUES (@Capacity,@Furniture,@BoysHostelBuildingNum) ";
                            cmd.Parameters.AddWithValue("@Capacity", cmbCapacity.Text);
                            cmd.Parameters.AddWithValue("@Furniture", checkFurlist.Text);
                            cmd.Parameters.AddWithValue("@BoysHostelBuildingNum", cmbBHBN.Text);
                            
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
