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
    public partial class Fee : Form
    {
        string connectionstring = "Data Source=DESKTOP-VE3HJV5\\ATISH;Initial Catalog = HDBMS;Integrated Security = true;";

        public Fee()
        {
            InitializeComponent();
        }
        private void LoadGrid()
        {
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = "SELECT * FROM Fee where FeeStatus = 'Not Paid' ";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvFee.DataSource = dt;
            }

        }

        private void ClearForm()
        {
            cmbStudentId.SelectedIndex = -1;
            cmbFeeMonth.SelectedIndex = -1;
            cmbFeeStatus.SelectedIndex = -1;

        }


        private bool FormValidation()
        {
            if (cmbStudentId.Text != string.Empty)
            {
                int outStudentId = 0;
                bool isStudentIdint = int.TryParse(cmbStudentId.Text, out outStudentId);
                if (isStudentIdint == false)
                {
                    MessageBox.Show("Student Id is required...!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbStudentId.Text = string.Empty;
                    cmbStudentId.Focus();
                    return false;
                }
                if (cmbFeeMonth.Text == string.Empty)
                {
                MessageBox.Show("Fee Month is required...!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbFeeMonth.Focus();
                return false;
                }
                if (cmbFeeStatus.Text == string.Empty)
                {
                MessageBox.Show("Fee status is required...!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbFeeStatus.Focus();
                return false;
                }
           
            }

            return true;
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                var confirm = MessageBox.Show("Do you want to Update?", "confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
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
                            cmd.CommandText = "Update Fee set FeeMonth=@FeeMonth,FeeStatus=@FeeStatus where StudentId = @StudentId";
                            cmd.Parameters.AddWithValue("@StudentId", cmbStudentId.Text);
                            cmd.Parameters.AddWithValue("@FeeMonth", cmbFeeMonth.Text);
                            cmd.Parameters.AddWithValue("@FeeStatus", cmbFeeStatus.Text);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Record updated sucessfully...!!!", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearForm();
                            LoadGrid();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something wents wrong...!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void gvFee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadGrid();
        }

        private void Fee_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void gvFee_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            {
                cmbStudentId.Text = (gvFee.Rows[e.RowIndex].Cells[0].Value.ToString());
                cmbFeeMonth.Text = (gvFee.Rows[e.RowIndex].Cells[1].Value.ToString());
                cmbFeeStatus.Text = (gvFee.Rows[e.RowIndex].Cells[2].Value.ToString());
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
    }
}
