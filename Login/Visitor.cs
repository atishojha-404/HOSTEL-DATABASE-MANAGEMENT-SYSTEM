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
    public partial class Visitor : Form
    {
        string connectionstring = "Data Source=DESKTOP-VE3HJV5\\ATISH;Initial Catalog = HDBMS;Integrated Security = true;";

        public Visitor()
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
                cmd.CommandText = "SELECT* FROM Visitor";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvVisitor.DataSource = dt;
            }

        }


        private void ClearForm()
        {
            txtVisitorName.Text = string.Empty;
            dateTimeIn.Text = string.Empty;
            DateTimeOut.Text = string.Empty;
            txtDateVisitor.Text = string.Empty;
            cmbStudentId.SelectedIndex = -1;
            txtVisitorId.Text = string.Empty;
        }


        private bool FormValidation()
        {

            if (txtVisitorName.Text == string.Empty)
            {
                MessageBox.Show("Visitor Name  is required...!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtVisitorName.Focus();
                return false;
            }
            if (dateTimeIn.Text == string.Empty)
            {
                MessageBox.Show(" Time In  is required...!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dateTimeIn.Focus();
                return false;
            }

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
                            cmd.CommandText = "INSERT INTO Visitor (VisitorName,TimeIn,TimeOut,Date,StudentId) VALUES (@VisitorName,@TimeIn,@TimeOut,@Date,@StudentId) ";
                            cmd.Parameters.AddWithValue("@VisitorName", txtVisitorName.Text);
                            cmd.Parameters.AddWithValue("@TimeIn", dateTimeIn.Text);
                            cmd.Parameters.AddWithValue("@TimeOut", DateTimeOut.Text);
                            cmd.Parameters.AddWithValue("@Date", txtDateVisitor.Text);
                            cmd.Parameters.AddWithValue("@StudentId", cmbStudentId.Text);

                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Record saved sucessfully...!!!", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void gvVisitor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadGrid();
        }

        private void Visitor_Load(object sender, EventArgs e)
        {
            LoadGrid();
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
                            cmd.CommandText = "Update Visitor set VisitorName=@VisitorName,TimeIn=@TimeIn,TimeOut=@TimeOut,Date=@Date,StudentId=@StudentId  where VisitorId = @VisitorId";
                            cmd.Parameters.AddWithValue("@VisitorName", txtVisitorName.Text);
                            cmd.Parameters.AddWithValue("@TimeIn", dateTimeIn.Text);
                            cmd.Parameters.AddWithValue("@TimeOut", DateTimeOut.Text);
                            cmd.Parameters.AddWithValue("@Date", txtDateVisitor.Text);
                            cmd.Parameters.AddWithValue("@StudentId", cmbStudentId.Text);
                            cmd.Parameters.AddWithValue("@VisitorId", txtVisitorId.Text);


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

        private void gvVisitor_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtVisitorId.Text = (gvVisitor.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtVisitorName.Text = (gvVisitor.Rows[e.RowIndex].Cells[1].Value.ToString());
            dateTimeIn.Text = (gvVisitor.Rows[e.RowIndex].Cells[2].Value.ToString());
            DateTimeOut.Text = (gvVisitor.Rows[e.RowIndex].Cells[3].Value.ToString());
            txtDateVisitor.Text = (gvVisitor.Rows[e.RowIndex].Cells[4].Value.ToString());
            cmbStudentId.Text = (gvVisitor.Rows[e.RowIndex].Cells[5].Value.ToString());

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearForm();

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    con.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT VisitorId, VisitorName,TimeIn,TimeOut,Date,StudentId FROM Visitor where  VisitorId Like @Search OR VisitorName Like @Search OR TimeIn Like @Search OR TimeOut  Like @Search OR Date  Like @Search OR StudentId Like @Search ";
                    cmd.Parameters.AddWithValue("@search", "%" + txtSearch.Text + "%");
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    gvVisitor.DataSource = dt;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Something wents wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtTimeOut_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
