using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VirtualVanguard
{
    public partial class PatientCard : UserControl
    {

        public Label patientName;
        public Label patientA;
        public Label lblEmail;
        public Label lblPhone;
        public Label lblPrimaryDoctor;
        public event EventHandler<Patient> ViewDetailsClicked; // Event for passing Patient object
        public Patient PatientData { get; set; } // Property to store patient data
        public PatientCard()
        {
            InitializeComponent();
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            viewDetailsBtn.Click += (s, e) => ViewDetailsClicked?.Invoke(this, PatientData);
        }

        private void patientName_Click(object sender, EventArgs e)
        {

        }

        private void PatientCard_Load(object sender, EventArgs e)
        {

        }

        private void viewDetailsBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
