using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class HDBMSSupervisor : Form
    {
        public HDBMSSupervisor()
        {
            InitializeComponent();
        }

        private void studentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Student stu = new Student();
            stu.Show();
        }

        private void hostelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hostel hos = new Hostel();
            hos.Show();
        }

        private void roomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Room ro = new Room();
            ro.Show();
        }

        private void feeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Fee fe = new Fee();
            fe.Show();
        }

        private void messEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessEmployee mee = new MessEmployee();
            mee.Show();
        }

        private void messToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mess mes = new Mess();
            mes.Show();
        }

        private void visitorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Visitor vit = new Visitor();
            vit.Show();
        }

        private void reportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void visitorReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VisitorReport VR = new VisitorReport();
            VR.Show();
        }

        private void employeeReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeReport ER = new EmployeeReport();
            ER.Show();
        }
    }
}
