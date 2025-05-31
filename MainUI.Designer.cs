namespace VirtualVanguard
{
    partial class MainUI
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
            this.components = new System.ComponentModel.Container();
            this.backgroundPanel = new System.Windows.Forms.Panel();
            this.dashLbl = new System.Windows.Forms.Label();
            this.addBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pageLabel = new System.Windows.Forms.Label();
            this.previousBtn = new System.Windows.Forms.Button();
            this.nextBtn = new System.Windows.Forms.Button();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.panel = new System.Windows.Forms.Panel();
            this.doctorBtn = new System.Windows.Forms.Button();
            this.contactBtn = new System.Windows.Forms.Button();
            this.nameBtn = new System.Windows.Forms.Button();
            this.flowPatientCard = new System.Windows.Forms.FlowLayoutPanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Dashboard = new System.Windows.Forms.TabPage();
            this.Calendar = new System.Windows.Forms.TabPage();
            this.addAppointmentBtn = new System.Windows.Forms.Button();
            this.appointmentsGrid = new System.Windows.Forms.DataGridView();
            this.About = new System.Windows.Forms.TabPage();
            this.clinicLbl = new System.Windows.Forms.Label();
            this.accountMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.emailMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.appointmentsContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editAppointmentMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteAppointmentMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.appointmentLbl = new System.Windows.Forms.Label();
            this.todayLabel = new System.Windows.Forms.Label();
            this.dayFilterBtn = new System.Windows.Forms.Button();
            this.weekFilterBtn = new System.Windows.Forms.Button();
            this.monthFilterBtn = new System.Windows.Forms.Button();
            this.appointmentCountLabel = new System.Windows.Forms.Label();
            this.accountButton = new System.Windows.Forms.Button();
            this.backgroundPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.Dashboard.SuspendLayout();
            this.Calendar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentsGrid)).BeginInit();
            this.accountMenuStrip.SuspendLayout();
            this.appointmentsContextMenuStrip.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // backgroundPanel
            // 
            this.backgroundPanel.BackColor = System.Drawing.Color.AliceBlue;
            this.backgroundPanel.Controls.Add(this.dashLbl);
            this.backgroundPanel.Controls.Add(this.addBtn);
            this.backgroundPanel.Controls.Add(this.panel1);
            this.backgroundPanel.Controls.Add(this.searchBox);
            this.backgroundPanel.Controls.Add(this.panel);
            this.backgroundPanel.Controls.Add(this.flowPatientCard);
            this.backgroundPanel.Location = new System.Drawing.Point(0, -4);
            this.backgroundPanel.Name = "backgroundPanel";
            this.backgroundPanel.Size = new System.Drawing.Size(1094, 690);
            this.backgroundPanel.TabIndex = 1;
            // 
            // dashLbl
            // 
            this.dashLbl.AutoSize = true;
            this.dashLbl.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashLbl.ForeColor = System.Drawing.Color.SteelBlue;
            this.dashLbl.Location = new System.Drawing.Point(8, 24);
            this.dashLbl.Name = "dashLbl";
            this.dashLbl.Size = new System.Drawing.Size(225, 29);
            this.dashLbl.TabIndex = 6;
            this.dashLbl.Text = "Patient Dashboard";
            // 
            // addBtn
            // 
            this.addBtn.AutoSize = true;
            this.addBtn.BackColor = System.Drawing.Color.SteelBlue;
            this.addBtn.FlatAppearance.BorderSize = 0;
            this.addBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addBtn.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addBtn.ForeColor = System.Drawing.Color.White;
            this.addBtn.Location = new System.Drawing.Point(965, 20);
            this.addBtn.Margin = new System.Windows.Forms.Padding(2);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(119, 33);
            this.addBtn.TabIndex = 5;
            this.addBtn.Text = "+ New Patient";
            this.addBtn.UseVisualStyleBackColor = false;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.pageLabel);
            this.panel1.Controls.Add(this.previousBtn);
            this.panel1.Controls.Add(this.nextBtn);
            this.panel1.Location = new System.Drawing.Point(13, 618);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1071, 55);
            this.panel1.TabIndex = 4;
            // 
            // pageLabel
            // 
            this.pageLabel.AutoSize = true;
            this.pageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pageLabel.Location = new System.Drawing.Point(891, 19);
            this.pageLabel.Name = "pageLabel";
            this.pageLabel.Size = new System.Drawing.Size(96, 18);
            this.pageLabel.TabIndex = 5;
            this.pageLabel.Text = "Page 1 of X";
            // 
            // previousBtn
            // 
            this.previousBtn.BackColor = System.Drawing.Color.LightGray;
            this.previousBtn.FlatAppearance.BorderSize = 0;
            this.previousBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.previousBtn.Location = new System.Drawing.Point(836, 13);
            this.previousBtn.Name = "previousBtn";
            this.previousBtn.Size = new System.Drawing.Size(40, 30);
            this.previousBtn.TabIndex = 4;
            this.previousBtn.Text = "<<";
            this.previousBtn.UseVisualStyleBackColor = false;
            this.previousBtn.Click += new System.EventHandler(this.previousBtn_Click);
            // 
            // nextBtn
            // 
            this.nextBtn.BackColor = System.Drawing.Color.LightGray;
            this.nextBtn.FlatAppearance.BorderSize = 0;
            this.nextBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nextBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nextBtn.Location = new System.Drawing.Point(1004, 13);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Size = new System.Drawing.Size(40, 30);
            this.nextBtn.TabIndex = 3;
            this.nextBtn.Text = ">>";
            this.nextBtn.UseVisualStyleBackColor = false;
            this.nextBtn.Click += new System.EventHandler(this.nextBtn_Click);
            // 
            // searchBox
            // 
            this.searchBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchBox.Location = new System.Drawing.Point(671, 62);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(413, 26);
            this.searchBox.TabIndex = 2;
            this.searchBox.TextChanged += new System.EventHandler(this.searchBox_TextChanged);
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel.Controls.Add(this.doctorBtn);
            this.panel.Controls.Add(this.contactBtn);
            this.panel.Controls.Add(this.nameBtn);
            this.panel.Location = new System.Drawing.Point(13, 96);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(1071, 45);
            this.panel.TabIndex = 1;
            // 
            // doctorBtn
            // 
            this.doctorBtn.FlatAppearance.BorderSize = 0;
            this.doctorBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.doctorBtn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.doctorBtn.Location = new System.Drawing.Point(739, 8);
            this.doctorBtn.Name = "doctorBtn";
            this.doctorBtn.Size = new System.Drawing.Size(182, 30);
            this.doctorBtn.TabIndex = 4;
            this.doctorBtn.Text = "Primary Doctor ▲▼";
            this.doctorBtn.UseVisualStyleBackColor = true;
            this.doctorBtn.Click += new System.EventHandler(this.doctorBtn_Click);
            // 
            // contactBtn
            // 
            this.contactBtn.FlatAppearance.BorderSize = 0;
            this.contactBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.contactBtn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contactBtn.Location = new System.Drawing.Point(308, 8);
            this.contactBtn.Name = "contactBtn";
            this.contactBtn.Size = new System.Drawing.Size(161, 30);
            this.contactBtn.TabIndex = 3;
            this.contactBtn.Text = "Contact Info ▲▼";
            this.contactBtn.UseVisualStyleBackColor = true;
            this.contactBtn.Click += new System.EventHandler(this.contactBtn_Click);
            // 
            // nameBtn
            // 
            this.nameBtn.FlatAppearance.BorderSize = 0;
            this.nameBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nameBtn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameBtn.Location = new System.Drawing.Point(55, 8);
            this.nameBtn.Name = "nameBtn";
            this.nameBtn.Size = new System.Drawing.Size(161, 30);
            this.nameBtn.TabIndex = 0;
            this.nameBtn.Text = "Patient Name ▲▼";
            this.nameBtn.UseVisualStyleBackColor = true;
            this.nameBtn.Click += new System.EventHandler(this.nameBtn_Click);
            // 
            // flowPatientCard
            // 
            this.flowPatientCard.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.flowPatientCard.AutoScroll = true;
            this.flowPatientCard.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flowPatientCard.Location = new System.Drawing.Point(13, 141);
            this.flowPatientCard.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.flowPatientCard.Name = "flowPatientCard";
            this.flowPatientCard.Size = new System.Drawing.Size(1071, 479);
            this.flowPatientCard.TabIndex = 0;
            this.flowPatientCard.Paint += new System.Windows.Forms.PaintEventHandler(this.flowPatientCard_Paint);
            this.flowPatientCard.Layout += new System.Windows.Forms.LayoutEventHandler(this.flowPatientCard_Layout);
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl1.Controls.Add(this.Dashboard);
            this.tabControl1.Controls.Add(this.Calendar);
            this.tabControl1.Controls.Add(this.About);
            this.tabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl1.ItemSize = new System.Drawing.Size(229, 70);
            this.tabControl1.Location = new System.Drawing.Point(6, 69);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1170, 693);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 3;
            this.tabControl1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem);
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // Dashboard
            // 
            this.Dashboard.BackColor = System.Drawing.Color.Transparent;
            this.Dashboard.Controls.Add(this.backgroundPanel);
            this.Dashboard.Location = new System.Drawing.Point(74, 4);
            this.Dashboard.Name = "Dashboard";
            this.Dashboard.Padding = new System.Windows.Forms.Padding(3);
            this.Dashboard.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Dashboard.Size = new System.Drawing.Size(1092, 685);
            this.Dashboard.TabIndex = 0;
            this.Dashboard.Text = "Dashboard";
            // 
            // Calendar
            // 
            this.Calendar.Controls.Add(this.appointmentsGrid);
            this.Calendar.Controls.Add(this.panel2);
            this.Calendar.Location = new System.Drawing.Point(74, 4);
            this.Calendar.Name = "Calendar";
            this.Calendar.Padding = new System.Windows.Forms.Padding(3);
            this.Calendar.Size = new System.Drawing.Size(1092, 685);
            this.Calendar.TabIndex = 1;
            this.Calendar.Text = "Calendar";
            this.Calendar.UseVisualStyleBackColor = true;
            // 
            // addAppointmentBtn
            // 
            this.addAppointmentBtn.BackColor = System.Drawing.Color.SteelBlue;
            this.addAppointmentBtn.FlatAppearance.BorderSize = 0;
            this.addAppointmentBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addAppointmentBtn.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addAppointmentBtn.ForeColor = System.Drawing.Color.White;
            this.addAppointmentBtn.Location = new System.Drawing.Point(925, 72);
            this.addAppointmentBtn.Name = "addAppointmentBtn";
            this.addAppointmentBtn.Size = new System.Drawing.Size(157, 31);
            this.addAppointmentBtn.TabIndex = 1;
            this.addAppointmentBtn.Text = "Create Appointment";
            this.addAppointmentBtn.UseVisualStyleBackColor = false;
            this.addAppointmentBtn.Click += new System.EventHandler(this.addAppointmentBtn_Click);
            // 
            // appointmentsGrid
            // 
            this.appointmentsGrid.AllowUserToAddRows = false;
            this.appointmentsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.appointmentsGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.appointmentsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.appointmentsGrid.Location = new System.Drawing.Point(14, 121);
            this.appointmentsGrid.Name = "appointmentsGrid";
            this.appointmentsGrid.ReadOnly = true;
            this.appointmentsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.appointmentsGrid.Size = new System.Drawing.Size(1068, 558);
            this.appointmentsGrid.TabIndex = 0;
            // 
            // About
            // 
            this.About.Location = new System.Drawing.Point(74, 4);
            this.About.Name = "About";
            this.About.Size = new System.Drawing.Size(1092, 685);
            this.About.TabIndex = 2;
            this.About.Text = "About";
            this.About.UseVisualStyleBackColor = true;
            // 
            // clinicLbl
            // 
            this.clinicLbl.BackColor = System.Drawing.Color.CornflowerBlue;
            this.clinicLbl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clinicLbl.Font = new System.Drawing.Font("Arial Narrow", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clinicLbl.ForeColor = System.Drawing.Color.White;
            this.clinicLbl.Location = new System.Drawing.Point(0, 0);
            this.clinicLbl.Name = "clinicLbl";
            this.clinicLbl.Size = new System.Drawing.Size(496, 70);
            this.clinicLbl.TabIndex = 5;
            this.clinicLbl.Text = "Cha\'s TCM Acupuncture and Herbs";
            this.clinicLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // accountMenuStrip
            // 
            this.accountMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.emailMenuItem,
            this.logoutToolStripMenuItem});
            this.accountMenuStrip.Name = "accountMenuStrip";
            this.accountMenuStrip.Size = new System.Drawing.Size(113, 48);
            // 
            // emailMenuItem
            // 
            this.emailMenuItem.Name = "emailMenuItem";
            this.emailMenuItem.Size = new System.Drawing.Size(112, 22);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // appointmentsContextMenuStrip
            // 
            this.appointmentsContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editAppointmentMenuItem,
            this.deleteAppointmentMenuItem});
            this.appointmentsContextMenuStrip.Name = "appointmentsContextMenuStrip";
            this.appointmentsContextMenuStrip.Size = new System.Drawing.Size(182, 48);
            // 
            // editAppointmentMenuItem
            // 
            this.editAppointmentMenuItem.Name = "editAppointmentMenuItem";
            this.editAppointmentMenuItem.Size = new System.Drawing.Size(181, 22);
            this.editAppointmentMenuItem.Text = "Edit Appointment";
            this.editAppointmentMenuItem.Click += new System.EventHandler(this.editAppointmentMenuItem_Click);
            // 
            // deleteAppointmentMenuItem
            // 
            this.deleteAppointmentMenuItem.Name = "deleteAppointmentMenuItem";
            this.deleteAppointmentMenuItem.Size = new System.Drawing.Size(181, 22);
            this.deleteAppointmentMenuItem.Text = "Delete Appointment";
            this.deleteAppointmentMenuItem.Click += new System.EventHandler(this.deleteAppointmentMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.AliceBlue;
            this.panel2.Controls.Add(this.appointmentCountLabel);
            this.panel2.Controls.Add(this.monthFilterBtn);
            this.panel2.Controls.Add(this.weekFilterBtn);
            this.panel2.Controls.Add(this.dayFilterBtn);
            this.panel2.Controls.Add(this.addAppointmentBtn);
            this.panel2.Controls.Add(this.todayLabel);
            this.panel2.Controls.Add(this.appointmentLbl);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1113, 689);
            this.panel2.TabIndex = 2;
            // 
            // appointmentLbl
            // 
            this.appointmentLbl.AutoSize = true;
            this.appointmentLbl.BackColor = System.Drawing.Color.Transparent;
            this.appointmentLbl.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appointmentLbl.ForeColor = System.Drawing.Color.SteelBlue;
            this.appointmentLbl.Location = new System.Drawing.Point(9, 25);
            this.appointmentLbl.Name = "appointmentLbl";
            this.appointmentLbl.Size = new System.Drawing.Size(223, 29);
            this.appointmentLbl.TabIndex = 7;
            this.appointmentLbl.Text = "Doctor\'s Schedule";
            // 
            // todayLabel
            // 
            this.todayLabel.AutoSize = true;
            this.todayLabel.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.todayLabel.Location = new System.Drawing.Point(12, 72);
            this.todayLabel.Name = "todayLabel";
            this.todayLabel.Size = new System.Drawing.Size(152, 29);
            this.todayLabel.TabIndex = 8;
            this.todayLabel.Text = "today\'s date";
            // 
            // dayFilterBtn
            // 
            this.dayFilterBtn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.dayFilterBtn.FlatAppearance.BorderSize = 0;
            this.dayFilterBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dayFilterBtn.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dayFilterBtn.Location = new System.Drawing.Point(677, 72);
            this.dayFilterBtn.Name = "dayFilterBtn";
            this.dayFilterBtn.Size = new System.Drawing.Size(75, 31);
            this.dayFilterBtn.TabIndex = 9;
            this.dayFilterBtn.Text = "Day";
            this.dayFilterBtn.UseVisualStyleBackColor = false;
            this.dayFilterBtn.Click += new System.EventHandler(this.dayFilterBtn_Click);
            // 
            // weekFilterBtn
            // 
            this.weekFilterBtn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.weekFilterBtn.FlatAppearance.BorderSize = 0;
            this.weekFilterBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.weekFilterBtn.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.weekFilterBtn.Location = new System.Drawing.Point(752, 72);
            this.weekFilterBtn.Name = "weekFilterBtn";
            this.weekFilterBtn.Size = new System.Drawing.Size(75, 31);
            this.weekFilterBtn.TabIndex = 10;
            this.weekFilterBtn.Text = "Week";
            this.weekFilterBtn.UseVisualStyleBackColor = false;
            this.weekFilterBtn.Click += new System.EventHandler(this.weekFilterBtn_Click);
            // 
            // monthFilterBtn
            // 
            this.monthFilterBtn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.monthFilterBtn.FlatAppearance.BorderSize = 0;
            this.monthFilterBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.monthFilterBtn.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monthFilterBtn.Location = new System.Drawing.Point(827, 72);
            this.monthFilterBtn.Name = "monthFilterBtn";
            this.monthFilterBtn.Size = new System.Drawing.Size(75, 31);
            this.monthFilterBtn.TabIndex = 11;
            this.monthFilterBtn.Text = "Month";
            this.monthFilterBtn.UseVisualStyleBackColor = false;
            this.monthFilterBtn.Click += new System.EventHandler(this.monthFilterBtn_Click);
            // 
            // appointmentCountLabel
            // 
            this.appointmentCountLabel.AutoSize = true;
            this.appointmentCountLabel.BackColor = System.Drawing.Color.SteelBlue;
            this.appointmentCountLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.appointmentCountLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appointmentCountLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.appointmentCountLabel.Location = new System.Drawing.Point(250, 84);
            this.appointmentCountLabel.Name = "appointmentCountLabel";
            this.appointmentCountLabel.Size = new System.Drawing.Size(166, 19);
            this.appointmentCountLabel.TabIndex = 12;
            this.appointmentCountLabel.Text = "Total Appointments: ";
            // 
            // accountButton
            // 
            this.accountButton.FlatAppearance.BorderSize = 0;
            this.accountButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.accountButton.Location = new System.Drawing.Point(1102, 6);
            this.accountButton.Name = "accountButton";
            this.accountButton.Size = new System.Drawing.Size(60, 60);
            this.accountButton.TabIndex = 7;
            this.accountButton.UseVisualStyleBackColor = true;
            // 
            // MainUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1188, 762);
            this.Controls.Add(this.accountButton);
            this.Controls.Add(this.clinicLbl);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(1204, 801);
            this.MinimumSize = new System.Drawing.Size(1204, 801);
            this.Name = "MainUI";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.MainUI_Load);
            this.backgroundPanel.ResumeLayout(false);
            this.backgroundPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.Dashboard.ResumeLayout(false);
            this.Calendar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.appointmentsGrid)).EndInit();
            this.accountMenuStrip.ResumeLayout(false);
            this.appointmentsContextMenuStrip.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel backgroundPanel;
        private System.Windows.Forms.FlowLayoutPanel flowPatientCard;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Button nameBtn;
        private System.Windows.Forms.Button contactBtn;
        private System.Windows.Forms.Button doctorBtn;
        private System.Windows.Forms.Button nextBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label pageLabel;
        private System.Windows.Forms.Button previousBtn;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Dashboard;
        private System.Windows.Forms.TabPage Calendar;
        private System.Windows.Forms.TabPage About;
        private System.Windows.Forms.Label dashLbl;
        private System.Windows.Forms.Label clinicLbl;
        private System.Windows.Forms.ContextMenuStrip accountMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem emailMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.DataGridView appointmentsGrid;
        private System.Windows.Forms.Button addAppointmentBtn;
        private System.Windows.Forms.ContextMenuStrip appointmentsContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem editAppointmentMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteAppointmentMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label appointmentLbl;
        private System.Windows.Forms.Label todayLabel;
        private System.Windows.Forms.Button monthFilterBtn;
        private System.Windows.Forms.Button weekFilterBtn;
        private System.Windows.Forms.Button dayFilterBtn;
        private System.Windows.Forms.Label appointmentCountLabel;
        private System.Windows.Forms.Button accountButton;
    }
}

