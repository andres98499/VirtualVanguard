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
    public partial class PatientDetails : Form
    {
        private Patient currentPatient;
        private readonly SupabaseService _supabaseService;


        public PatientDetails(Patient patient, SupabaseService supabaseService)
        {
            InitializeComponent();

            currentPatient = patient;
            _supabaseService = supabaseService;

            // Basic Info
            patientNameLbl.Text = patient.patientfirstname.HandleNull() + " " + patient.patientlastname.HandleNull();
            phoneLbl.Text = patient.Phone.HandleNull();
            emailLbl.Text = patient.Email.HandleNull();
            addressLbl.Text = $"{patient.HomeAddress.HandleNull()}, {patient.City.HandleNull()}, {patient.State.HandleNull()}, {patient.Zip.HandleNull()}";
            genderLbl.Text = patient.Gender.HandleNull();
            ageLbl.Text = patient.DateOfBirth == default(DateTime) ? "N/A" : CalculateAge(patient.DateOfBirth).ToString();
            dobLbl.Text = patient.DateOfBirth == default(DateTime) ? "N/A" : patient.DateOfBirth.ToString("yyyy-MM-dd");
            insuranceLbl.Text = patient.Insuranceco.HandleNull();
            policyLbl.Text = patient.Policyno.HandleNull();

            // Spouse Info
            spouseNameLbl.Text = patient.spousename.HandleNull();
            spousePhoneLbl.Text = patient.spousephone.HandleNull();

            // Occupation Details
            occupationLbl.Text = patient.occupation.HandleNull();
            employedLbl.Text = patient.employedby.HandleNull();
            businessAddressLbl.Text = $"{patient.businessaddress.HandleNull()}, {patient.businesscity.HandleNull()}, {patient.businesszip.HandleNull()}";


            // Medical Information
            heightLbl.Text = patient.Height.HandleNull();
            weightLbl.Text = patient.Weight.HandleNull();
            bPressureLbl.Text = !string.IsNullOrWhiteSpace(patient.bloodpressure) ? $"{patient.bloodpressure} mmHg" : "N/A";
            diagLbl.Text = patient.doctordiagnosis.HandleNull();
            medicationsLbl.Text = patient.Medications.HandleNull();

            // Health Issue
            healthLbl.Text = patient.healthissuedescription.HandleNull();
            durationLbl.Text = patient.healthissueduration.HandleNull();

            // Primary Doctor
            doctorLbl.Text = patient.PrimaryDoctor.HandleNull();
            doctorPhoneLbl.Text = patient.primarydoctorphone.HandleNull();

            // Treatment Information
            treatmentLbl.Text = patient.treatment1.HandleNull();
            treatmentDateLbl.Text = patient.treatmentdate1.HasValue ? patient.treatmentdate1.Value.ToString("yyyy-MM-dd") : "N/A";
            resultLbl.Text = patient.treatmentresult1.HandleNull();
        }
        private int CalculateAge(DateTime birthDate)
        {
            var today = DateTime.Today;
            int age = today.Year - birthDate.Year;
            if (birthDate.Date > today.AddYears(-age)) age--;
            return age;
        }

        private void PatientDetails_Load(object sender, EventArgs e)
        {

        }
        private IEnumerable<Control> GetAllControls(Control container)
        {
            foreach (Control control in container.Controls)
            {
                yield return control;

                // If the control is a Panel, GroupBox, or other container, search inside it
                if (control.HasChildren)
                {
                    foreach (var child in GetAllControls(control))
                    {
                        yield return child;
                    }
                }
            }
        }
        private string GetTextBoxValue(string textBoxName)
        {
            return GetAllControls(this).OfType<TextBox>().FirstOrDefault(tb => tb.Name == textBoxName)?.Text;
        }
        private void editData_Click(object sender, EventArgs e)
        {
            using (EditPatientForm editForm = new EditPatientForm(currentPatient, _supabaseService))
            {
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    // Retrieve updated patient details
                    currentPatient = editForm.UpdatedPatient;

                    // Refresh labels with updated data
                    patientNameLbl.Text = $"{currentPatient.patientfirstname} {currentPatient.patientlastname}";
                    phoneLbl.Text = currentPatient.Phone;
                    emailLbl.Text = currentPatient.Email;
                    addressLbl.Text = $"{currentPatient.HomeAddress}, {currentPatient.City}, {currentPatient.State}, {currentPatient.Zip}";
                    genderLbl.Text = currentPatient.Gender;
                    dobLbl.Text = currentPatient.DateOfBirth.ToString("yyyy-MM-dd");
                    ageLbl.Text = CalculateAge(currentPatient.DateOfBirth).ToString();
                    insuranceLbl.Text = currentPatient.Insuranceco;
                    policyLbl.Text = currentPatient.Policyno;
                    occupationLbl.Text = currentPatient.occupation;
                    employedLbl.Text = currentPatient.employedby;
                    businessAddressLbl.Text = $"{currentPatient.businessaddress}, {currentPatient.businesscity}, {currentPatient.businesszip}";
                    doctorLbl.Text = currentPatient.PrimaryDoctor;
                    doctorPhoneLbl.Text = currentPatient.primarydoctorphone;
                    diagLbl.Text = currentPatient.doctordiagnosis;
                    healthLbl.Text = currentPatient.healthissuedescription;
                    durationLbl.Text = currentPatient.healthissueduration;
                    medicationsLbl.Text = currentPatient.Medications;
                    bPressureLbl.Text = $"{currentPatient.bloodpressure} mmHg";
                    treatmentLbl.Text = currentPatient.treatment1;
                    treatmentDateLbl.Text = currentPatient.treatmentdate1?.ToString("yyyy-MM-dd") ?? "N/A";
                    resultLbl.Text = currentPatient.treatmentresult1;

                }
            }
        }
    }
}