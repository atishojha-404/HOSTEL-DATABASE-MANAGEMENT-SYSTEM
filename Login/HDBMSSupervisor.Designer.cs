namespace Login
{
    partial class HDBMSSupervisor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.studentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hostelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.roomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.feeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.messEmployeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.messToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visitorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visitorReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.employeeReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Red;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.studentToolStripMenuItem,
            this.hostelToolStripMenuItem,
            this.roomToolStripMenuItem,
            this.feeToolStripMenuItem,
            this.messEmployeeToolStripMenuItem,
            this.messToolStripMenuItem,
            this.visitorToolStripMenuItem,
            this.reportToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1045, 43);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // studentToolStripMenuItem
            // 
            this.studentToolStripMenuItem.Name = "studentToolStripMenuItem";
            this.studentToolStripMenuItem.Size = new System.Drawing.Size(119, 39);
            this.studentToolStripMenuItem.Text = "Student";
            this.studentToolStripMenuItem.Click += new System.EventHandler(this.studentToolStripMenuItem_Click);
            // 
            // hostelToolStripMenuItem
            // 
            this.hostelToolStripMenuItem.Name = "hostelToolStripMenuItem";
            this.hostelToolStripMenuItem.Size = new System.Drawing.Size(103, 39);
            this.hostelToolStripMenuItem.Text = "Hostel";
            this.hostelToolStripMenuItem.Click += new System.EventHandler(this.hostelToolStripMenuItem_Click);
            // 
            // roomToolStripMenuItem
            // 
            this.roomToolStripMenuItem.Name = "roomToolStripMenuItem";
            this.roomToolStripMenuItem.Size = new System.Drawing.Size(95, 39);
            this.roomToolStripMenuItem.Text = "Room";
            this.roomToolStripMenuItem.Click += new System.EventHandler(this.roomToolStripMenuItem_Click);
            // 
            // feeToolStripMenuItem
            // 
            this.feeToolStripMenuItem.Name = "feeToolStripMenuItem";
            this.feeToolStripMenuItem.Size = new System.Drawing.Size(68, 39);
            this.feeToolStripMenuItem.Text = "Fee";
            this.feeToolStripMenuItem.Click += new System.EventHandler(this.feeToolStripMenuItem_Click);
            // 
            // messEmployeeToolStripMenuItem
            // 
            this.messEmployeeToolStripMenuItem.Name = "messEmployeeToolStripMenuItem";
            this.messEmployeeToolStripMenuItem.Size = new System.Drawing.Size(202, 39);
            this.messEmployeeToolStripMenuItem.Text = "MessEmployee";
            this.messEmployeeToolStripMenuItem.Click += new System.EventHandler(this.messEmployeeToolStripMenuItem_Click);
            // 
            // messToolStripMenuItem
            // 
            this.messToolStripMenuItem.Name = "messToolStripMenuItem";
            this.messToolStripMenuItem.Size = new System.Drawing.Size(87, 39);
            this.messToolStripMenuItem.Text = "Mess";
            this.messToolStripMenuItem.Click += new System.EventHandler(this.messToolStripMenuItem_Click);
            // 
            // visitorToolStripMenuItem
            // 
            this.visitorToolStripMenuItem.Name = "visitorToolStripMenuItem";
            this.visitorToolStripMenuItem.Size = new System.Drawing.Size(104, 39);
            this.visitorToolStripMenuItem.Text = "Visitor";
            this.visitorToolStripMenuItem.Click += new System.EventHandler(this.visitorToolStripMenuItem_Click);
            // 
            // reportToolStripMenuItem
            // 
            this.reportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.visitorReportToolStripMenuItem,
            this.employeeReportToolStripMenuItem});
            this.reportToolStripMenuItem.Name = "reportToolStripMenuItem";
            this.reportToolStripMenuItem.Size = new System.Drawing.Size(108, 39);
            this.reportToolStripMenuItem.Text = "Report";
            this.reportToolStripMenuItem.Click += new System.EventHandler(this.reportToolStripMenuItem_Click);
            // 
            // visitorReportToolStripMenuItem
            // 
            this.visitorReportToolStripMenuItem.Name = "visitorReportToolStripMenuItem";
            this.visitorReportToolStripMenuItem.Size = new System.Drawing.Size(292, 40);
            this.visitorReportToolStripMenuItem.Text = "Visitor Report";
            this.visitorReportToolStripMenuItem.Click += new System.EventHandler(this.visitorReportToolStripMenuItem_Click);
            // 
            // employeeReportToolStripMenuItem
            // 
            this.employeeReportToolStripMenuItem.Name = "employeeReportToolStripMenuItem";
            this.employeeReportToolStripMenuItem.Size = new System.Drawing.Size(292, 40);
            this.employeeReportToolStripMenuItem.Text = "EmployeeReport";
            this.employeeReportToolStripMenuItem.Click += new System.EventHandler(this.employeeReportToolStripMenuItem_Click);
            // 
            // HDBMSSupervisor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Login.Properties.Resources.wp1812466_shinchan_wallpapers;
            this.ClientSize = new System.Drawing.Size(1045, 450);
            this.Controls.Add(this.menuStrip1);
            this.Name = "HDBMSSupervisor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HDBMSSupervisor";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem studentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hostelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem roomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem feeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem messEmployeeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem messToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visitorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visitorReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem employeeReportToolStripMenuItem;
    }
}