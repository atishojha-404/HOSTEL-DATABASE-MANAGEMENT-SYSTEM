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
    public partial class Mess : Form
    {
        string connectionstring = "Data Source=DESKTOP-VE3HJV5\\ATISH;Initial Catalog = HDBMS;Integrated Security = true;";

        public Mess()
        {
            InitializeComponent();
        }

        private void Mess_Load(object sender, EventArgs e)
        {

        }

        private bool FormValidation()
        {
            if (txtMessInCharge.Text == string.Empty)
            {
                MessageBox.Show("Mess InCharge is required...!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMessInCharge.Focus();
                return false;
            }
            if (txtMonthlyExpense.Text != string.Empty)
            {
                decimal outMonthlyExpense = 0;
                bool isMonthlyExpensedecimal = decimal.TryParse(txtMonthlyExpense.Text, out outMonthlyExpense);
                if (isMonthlyExpensedecimal == false)
                {
                    MessageBox.Show("Monthly Expense is required...!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMessTiming.Text = string.Empty;
                    txtMonthlyExpense.Focus();
                    return false;
                }
            }
            if (txtMessTiming.Text == string.Empty)
            {
                MessageBox.Show("Mess Timing is required...!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMessTiming.Focus();
                return false;
            }
            return true;
        }

        private void ClearForm()
        {
            txtMessInCharge.Text = string.Empty;
            txtMonthlyExpense.Text = string.Empty;
            txtMessTiming.Text = string.Empty;
           


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
                            cmd.CommandText = "INSERT INTO Mess (MessIncharge,MonthlyExpense,MessTiming) VALUES (@MessIncharge,@MonthlyExpense,@MessTiming) ";
                            cmd.Parameters.AddWithValue("@MessIncharge", txtMessInCharge.Text);
                            cmd.Parameters.AddWithValue("@MonthlyExpense", txtMonthlyExpense.Text);
                            cmd.Parameters.AddWithValue("@MessTiming", txtMessTiming.Text);
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
