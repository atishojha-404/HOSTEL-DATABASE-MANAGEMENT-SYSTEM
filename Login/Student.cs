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
    public partial class Student : Form
    {
      

        string connectionstring = "Data Source=DESKTOP-VE3HJV5\\ATISH;Initial Catalog = HDBMS;Integrated Security = true;";
        public Student()
        {
            InitializeComponent();
        }

        private void Student_Load(object sender, EventArgs e)
        {

        }

        private bool FormValidation()
        {
            if (txtName.Text == string.Empty)
            {
                MessageBox.Show("Name is required...!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }
            if (txtFatherName.Text == string.Empty)
            {
                MessageBox.Show("Father is required...!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFatherName.Focus();
                return false;
            }
            if (txtDepartment.Text == string.Empty)
            {
                MessageBox.Show("Department is required...!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDepartment.Focus();
                return false;
            }
            if (txtContact.Text == string.Empty)
            {
                MessageBox.Show("Contact is required...!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContact.Focus();
                return false;
            }
            if (txtAge.Text != string.Empty)
            {
                int outAge = 0;
                bool isAgeint = int.TryParse(txtAge.Text, out outAge);
                if (isAgeint == false)
                {
                    MessageBox.Show("Age should be in Number...!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAge.Text = string.Empty;
                    txtAge.Focus();
                    return false;
                }
            }

            if (radioButton1.Checked == false & radioButton2.Checked == false & radioButton1.Checked == false)
            {
                MessageBox.Show("Specify Your Gender!!", "Warning!!", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return false;
            }

            if (cmbRoomNum.Text == string.Empty)
            {
                int outRoomId = 0;
                bool isRoomIdint = int.TryParse(txtAge.Text, out outRoomId);
                if (isRoomIdint == false)
                {
                    MessageBox.Show("Room Num is required should be in number...!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbRoomNum.Text = string.Empty;
                    cmbRoomNum.Focus();
                    return false;
                }
               
            }

           

            return true;
        }

        private void ClearForm()
        {
            txtName.Text = string.Empty;
            txtFatherName.Text = string.Empty;
            txtDepartment.Text = string.Empty;
            txtContact.Text = string.Empty;
            txtAge.Text = string.Empty;
            Gender = string.Empty;
            cmbRoomNum.SelectedIndex = -1;




        }
        string Gender;
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                var confirm = MessageBox.Show("Do you want to Submit?", "confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (confirm.ToString().ToUpper() == "OK")
                {
                    {
                        if (radioButton1.Checked)
                        {
                            Gender = "Male";
                        }
                        if (radioButton2.Checked)
                        {
                            Gender = "Female";
                        }
                        if (radioButton3.Checked)
                        {
                            Gender = "Others";
                        }
                    }

                    using (SqlConnection con = new SqlConnection(connectionstring))
                    {
                        bool isValiationSucess = FormValidation();
                        if (isValiationSucess == true)
                        {
                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = con;
                            cmd.CommandType = CommandType.Text;
                            con.Open();
                            cmd.CommandText = @"INSERT INTO Student (StudentName,FatherName,Department,Contact,Age,Gender,RoomId) 
                                               VALUES (@StudentName,@FatherName,@Department,@Contact,@Age,@Gender,@RoomId) ";
                            cmd.Parameters.AddWithValue("@StudentName", txtName.Text);
                            cmd.Parameters.AddWithValue("@FatherName", txtFatherName.Text);
                            cmd.Parameters.AddWithValue("@Department", txtDepartment.Text);
                            cmd.Parameters.AddWithValue("@Contact", txtContact.Text);
                            cmd.Parameters.AddWithValue("@Age", txtAge.Text);
                            cmd.Parameters.AddWithValue("@gender", Gender);
                            cmd.Parameters.AddWithValue("@RoomId", cmbRoomNum.Text);
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
