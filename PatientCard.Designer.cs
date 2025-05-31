namespace VirtualVanguard
{
    partial class PatientCard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.patientNameLbl = new System.Windows.Forms.Label();
            this.patientAGLbl = new System.Windows.Forms.Label();
            this.patientEmailLbl = new System.Windows.Forms.Label();
            this.patientPhoneLbl = new System.Windows.Forms.Label();
            this.patientPrimaryDoctorLbl = new System.Windows.Forms.Label();
            this.viewDetailsBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // patientNameLbl
            // 
            this.patientNameLbl.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.patientNameLbl.Location = new System.Drawing.Point(80, 17);
            this.patientNameLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.patientNameLbl.Name = "patientNameLbl";
            this.patientNameLbl.Size = new System.Drawing.Size(304, 27);
            this.patientNameLbl.TabIndex = 0;
            this.patientNameLbl.Text = "Name";
            this.patientNameLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.patientNameLbl.Click += new System.EventHandler(this.patientName_Click);
            // 
            // patientAGLbl
            // 
            this.patientAGLbl.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.patientAGLbl.Location = new System.Drawing.Point(80, 44);
            this.patientAGLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.patientAGLbl.Name = "patientAGLbl";
            this.patientAGLbl.Size = new System.Drawing.Size(236, 27);
            this.patientAGLbl.TabIndex = 1;
            this.patientAGLbl.Text = "Age and Gender";
            // 
            // patientEmailLbl
            // 
            this.patientEmailLbl.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.patientEmailLbl.Location = new System.Drawing.Point(425, 17);
            this.patientEmailLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.patientEmailLbl.Name = "patientEmailLbl";
            this.patientEmailLbl.Size = new System.Drawing.Size(385, 27);
            this.patientEmailLbl.TabIndex = 2;
            this.patientEmailLbl.Text = "Email";
            this.patientEmailLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // patientPhoneLbl
            // 
            this.patientPhoneLbl.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.patientPhoneLbl.Location = new System.Drawing.Point(425, 44);
            this.patientPhoneLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.patientPhoneLbl.Name = "patientPhoneLbl";
            this.patientPhoneLbl.Size = new System.Drawing.Size(307, 27);
            this.patientPhoneLbl.TabIndex = 3;
            this.patientPhoneLbl.Text = "phone";
            // 
            // patientPrimaryDoctorLbl
            // 
            this.patientPrimaryDoctorLbl.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.patientPrimaryDoctorLbl.Location = new System.Drawing.Point(993, 16);
            this.patientPrimaryDoctorLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.patientPrimaryDoctorLbl.Name = "patientPrimaryDoctorLbl";
            this.patientPrimaryDoctorLbl.Size = new System.Drawing.Size(179, 27);
            this.patientPrimaryDoctorLbl.TabIndex = 4;
            this.patientPrimaryDoctorLbl.Text = "primarydoctor";
            this.patientPrimaryDoctorLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // viewDetailsBtn
            // 
            this.viewDetailsBtn.BackColor = System.Drawing.Color.SteelBlue;
            this.viewDetailsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.viewDetailsBtn.ForeColor = System.Drawing.Color.White;
            this.viewDetailsBtn.Location = new System.Drawing.Point(1216, 15);
            this.viewDetailsBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.viewDetailsBtn.Name = "viewDetailsBtn";
            this.viewDetailsBtn.Size = new System.Drawing.Size(112, 36);
            this.viewDetailsBtn.TabIndex = 5;
            this.viewDetailsBtn.Text = "View Details";
            this.viewDetailsBtn.UseVisualStyleBackColor = false;
            this.viewDetailsBtn.Click += new System.EventHandler(this.viewDetailsBtn_Click);
            // 
            // PatientCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.viewDetailsBtn);
            this.Controls.Add(this.patientPrimaryDoctorLbl);
            this.Controls.Add(this.patientPhoneLbl);
            this.Controls.Add(this.patientEmailLbl);
            this.Controls.Add(this.patientAGLbl);
            this.Controls.Add(this.patientNameLbl);
            this.Margin = new System.Windows.Forms.Padding(4, 0, 4, 2);
            this.Name = "PatientCard";
            this.Size = new System.Drawing.Size(1349, 91);
            this.Load += new System.EventHandler(this.PatientCard_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label patientNameLbl;
        public System.Windows.Forms.Label patientAGLbl;
        public System.Windows.Forms.Label patientEmailLbl;
        public System.Windows.Forms.Label patientPhoneLbl;
        public System.Windows.Forms.Label patientPrimaryDoctorLbl;
        private System.Windows.Forms.Button viewDetailsBtn;
    }
}
