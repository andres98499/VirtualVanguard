namespace VirtualVanguard
{
    partial class AddAppointmentForm
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
            this.appointLbl = new System.Windows.Forms.Label();
            this.patientLbl = new System.Windows.Forms.Label();
            this.patientComboBox = new System.Windows.Forms.ComboBox();
            this.docNameLbl = new System.Windows.Forms.Label();
            this.doctorTextBox = new System.Windows.Forms.TextBox();
            this.dateLbl = new System.Windows.Forms.Label();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.timeLbl = new System.Windows.Forms.Label();
            this.timeComboBox = new System.Windows.Forms.ComboBox();
            this.notesLbl = new System.Windows.Forms.Label();
            this.notesBox = new System.Windows.Forms.TextBox();
            this.saveBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // appointLbl
            // 
            this.appointLbl.AutoSize = true;
            this.appointLbl.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appointLbl.Location = new System.Drawing.Point(25, 27);
            this.appointLbl.Name = "appointLbl";
            this.appointLbl.Size = new System.Drawing.Size(229, 29);
            this.appointLbl.TabIndex = 0;
            this.appointLbl.Text = "Appointment Form";
            // 
            // patientLbl
            // 
            this.patientLbl.AutoSize = true;
            this.patientLbl.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.patientLbl.ForeColor = System.Drawing.Color.Black;
            this.patientLbl.Location = new System.Drawing.Point(26, 88);
            this.patientLbl.Name = "patientLbl";
            this.patientLbl.Size = new System.Drawing.Size(96, 16);
            this.patientLbl.TabIndex = 1;
            this.patientLbl.Text = "Select Patient";
            // 
            // patientComboBox
            // 
            this.patientComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.patientComboBox.FormattingEnabled = true;
            this.patientComboBox.Location = new System.Drawing.Point(29, 107);
            this.patientComboBox.Name = "patientComboBox";
            this.patientComboBox.Size = new System.Drawing.Size(186, 24);
            this.patientComboBox.TabIndex = 2;
            // 
            // docNameLbl
            // 
            this.docNameLbl.AutoSize = true;
            this.docNameLbl.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.docNameLbl.ForeColor = System.Drawing.Color.Black;
            this.docNameLbl.Location = new System.Drawing.Point(225, 88);
            this.docNameLbl.Name = "docNameLbl";
            this.docNameLbl.Size = new System.Drawing.Size(98, 16);
            this.docNameLbl.TabIndex = 3;
            this.docNameLbl.Text = "Doctor\'s Name";
            // 
            // doctorTextBox
            // 
            this.doctorTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.doctorTextBox.Location = new System.Drawing.Point(228, 109);
            this.doctorTextBox.Name = "doctorTextBox";
            this.doctorTextBox.Size = new System.Drawing.Size(185, 22);
            this.doctorTextBox.TabIndex = 4;
            // 
            // dateLbl
            // 
            this.dateLbl.AutoSize = true;
            this.dateLbl.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateLbl.ForeColor = System.Drawing.Color.Black;
            this.dateLbl.Location = new System.Drawing.Point(27, 141);
            this.dateLbl.Name = "dateLbl";
            this.dateLbl.Size = new System.Drawing.Size(67, 16);
            this.dateLbl.TabIndex = 5;
            this.dateLbl.Text = "Pick Date";
            // 
            // datePicker
            // 
            this.datePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datePicker.Location = new System.Drawing.Point(29, 160);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(185, 22);
            this.datePicker.TabIndex = 6;
            // 
            // timeLbl
            // 
            this.timeLbl.AutoSize = true;
            this.timeLbl.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeLbl.ForeColor = System.Drawing.Color.Black;
            this.timeLbl.Location = new System.Drawing.Point(225, 141);
            this.timeLbl.Name = "timeLbl";
            this.timeLbl.Size = new System.Drawing.Size(83, 16);
            this.timeLbl.TabIndex = 7;
            this.timeLbl.Text = "Select Time";
            // 
            // timeComboBox
            // 
            this.timeComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeComboBox.FormattingEnabled = true;
            this.timeComboBox.Location = new System.Drawing.Point(228, 161);
            this.timeComboBox.Name = "timeComboBox";
            this.timeComboBox.Size = new System.Drawing.Size(186, 24);
            this.timeComboBox.TabIndex = 8;
            // 
            // notesLbl
            // 
            this.notesLbl.AutoSize = true;
            this.notesLbl.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notesLbl.ForeColor = System.Drawing.Color.Black;
            this.notesLbl.Location = new System.Drawing.Point(26, 192);
            this.notesLbl.Name = "notesLbl";
            this.notesLbl.Size = new System.Drawing.Size(111, 16);
            this.notesLbl.TabIndex = 9;
            this.notesLbl.Text = "Additional Notes";
            // 
            // notesBox
            // 
            this.notesBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.notesBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notesBox.Location = new System.Drawing.Point(29, 211);
            this.notesBox.Multiline = true;
            this.notesBox.Name = "notesBox";
            this.notesBox.Size = new System.Drawing.Size(384, 137);
            this.notesBox.TabIndex = 10;
            this.notesBox.TextChanged += new System.EventHandler(this.notesBox_TextChanged);
            // 
            // saveBtn
            // 
            this.saveBtn.BackColor = System.Drawing.Color.SteelBlue;
            this.saveBtn.FlatAppearance.BorderSize = 0;
            this.saveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveBtn.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveBtn.ForeColor = System.Drawing.Color.White;
            this.saveBtn.Location = new System.Drawing.Point(179, 367);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 11;
            this.saveBtn.Text = "Confirm";
            this.saveBtn.UseVisualStyleBackColor = false;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // AddAppointmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(443, 410);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.notesBox);
            this.Controls.Add(this.notesLbl);
            this.Controls.Add(this.timeComboBox);
            this.Controls.Add(this.timeLbl);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.dateLbl);
            this.Controls.Add(this.doctorTextBox);
            this.Controls.Add(this.docNameLbl);
            this.Controls.Add(this.patientComboBox);
            this.Controls.Add(this.patientLbl);
            this.Controls.Add(this.appointLbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddAppointmentForm";
            this.Text = "AddAppointmentForm";
            this.Load += new System.EventHandler(this.AddAppointmentForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label appointLbl;
        private System.Windows.Forms.Label patientLbl;
        private System.Windows.Forms.ComboBox patientComboBox;
        private System.Windows.Forms.Label docNameLbl;
        private System.Windows.Forms.TextBox doctorTextBox;
        private System.Windows.Forms.Label dateLbl;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.Label timeLbl;
        private System.Windows.Forms.ComboBox timeComboBox;
        private System.Windows.Forms.Label notesLbl;
        private System.Windows.Forms.TextBox notesBox;
        private System.Windows.Forms.Button saveBtn;
    }
}