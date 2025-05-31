using System;
using System.Drawing;
using System.Windows.Forms;

namespace VirtualVanguard
{
    public partial class EditPatientForm : Form
    {
        private Patient currentPatient;
        private readonly SupabaseService _supabaseService;
        private TextBox firstNameBox, lastNameBox, phoneBox, emailBox, addressBox, genderBox;
        private TextBox insuranceBox, policyBox, occupationBox, employedBox, businessAddressBox;
        private TextBox doctorBox, doctorPhoneBox, diagnosisBox, healthIssueBox, durationBox, medicationsBox;
        private TextBox bloodPressureBox, treatmentBox, treatmentResultBox;
        private DateTimePicker dobPicker, treatmentDatePicker;
        private Button saveBtn, cancelBtn;

        public Patient UpdatedPatient { get; private set; }  // Property to store updated patient

        public EditPatientForm(Patient patient, SupabaseService supabaseService)
        {
            this.Text = "Edit Patient Details";
            this.Size = new Size(500, 800);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;

            currentPatient = patient;
            _supabaseService = supabaseService;

            // Labels and controls
            int yOffset = 20;

            this.Controls.Add(CreateLabel("First Name:", 20, yOffset));
            firstNameBox = CreateTextBox(150, yOffset, patient.patientfirstname);
            this.Controls.Add(firstNameBox);
            yOffset += 30;

            this.Controls.Add(CreateLabel("Last Name:", 20, yOffset));
            lastNameBox = CreateTextBox(150, yOffset, patient.patientlastname);
            this.Controls.Add(lastNameBox);
            yOffset += 30;

            this.Controls.Add(CreateLabel("Phone:", 20, yOffset));
            phoneBox = CreateTextBox(150, yOffset, patient.Phone);
            this.Controls.Add(phoneBox);
            yOffset += 30;

            this.Controls.Add(CreateLabel("Email:", 20, yOffset));
            emailBox = CreateTextBox(150, yOffset, patient.Email);
            this.Controls.Add(emailBox);
            yOffset += 30;

            this.Controls.Add(CreateLabel("Address:", 20, yOffset));
            addressBox = CreateTextBox(150, yOffset, $"{patient.HomeAddress}, {patient.City}, {patient.State}, {patient.Zip}");
            this.Controls.Add(addressBox);
            yOffset += 30;

            this.Controls.Add(CreateLabel("Gender:", 20, yOffset));
            genderBox = CreateTextBox(150, yOffset, patient.Gender);
            this.Controls.Add(genderBox);
            yOffset += 30;

            this.Controls.Add(CreateLabel("Date of Birth:", 20, yOffset));
            dobPicker = new DateTimePicker
            {
                Location = new Point(150, yOffset),
                Size = new Size(200, 25),
                Format = DateTimePickerFormat.Short,
                Value = patient.DateOfBirth
            };
            this.Controls.Add(dobPicker);
            yOffset += 30;

            this.Controls.Add(CreateLabel("Insurance Co:", 20, yOffset));
            insuranceBox = CreateTextBox(150, yOffset, patient.Insuranceco);
            this.Controls.Add(insuranceBox);
            yOffset += 30;

            this.Controls.Add(CreateLabel("Policy No:", 20, yOffset));
            policyBox = CreateTextBox(150, yOffset, patient.Policyno);
            this.Controls.Add(policyBox);
            yOffset += 30;

            this.Controls.Add(CreateLabel("Occupation:", 20, yOffset));
            occupationBox = CreateTextBox(150, yOffset, patient.occupation);
            this.Controls.Add(occupationBox);
            yOffset += 30;

            this.Controls.Add(CreateLabel("Employer:", 20, yOffset));
            employedBox = CreateTextBox(150, yOffset, patient.employedby);
            this.Controls.Add(employedBox);
            yOffset += 30;

            this.Controls.Add(CreateLabel("Business Address:", 20, yOffset));
            businessAddressBox = CreateTextBox(150, yOffset, $"{patient.businessaddress}, {patient.businesscity}, {patient.businesszip}");
            this.Controls.Add(businessAddressBox);
            yOffset += 30;

            this.Controls.Add(CreateLabel("Primary Doctor:", 20, yOffset));
            doctorBox = CreateTextBox(150, yOffset, patient.PrimaryDoctor);
            this.Controls.Add(doctorBox);
            yOffset += 30;

            this.Controls.Add(CreateLabel("Doctor Phone:", 20, yOffset));
            doctorPhoneBox = CreateTextBox(150, yOffset, patient.primarydoctorphone);
            this.Controls.Add(doctorPhoneBox);
            yOffset += 30;

            this.Controls.Add(CreateLabel("Diagnosis:", 20, yOffset));
            diagnosisBox = CreateTextBox(150, yOffset, patient.doctordiagnosis);
            this.Controls.Add(diagnosisBox);
            yOffset += 30;

            this.Controls.Add(CreateLabel("Health Issue:", 20, yOffset));
            healthIssueBox = CreateTextBox(150, yOffset, patient.healthissuedescription);
            this.Controls.Add(healthIssueBox);
            yOffset += 30;

            this.Controls.Add(CreateLabel("Duration:", 20, yOffset));
            durationBox = CreateTextBox(150, yOffset, patient.healthissueduration);
            this.Controls.Add(durationBox);
            yOffset += 30;

            this.Controls.Add(CreateLabel("Medications:", 20, yOffset));
            medicationsBox = CreateTextBox(150, yOffset, patient.Medications);
            this.Controls.Add(medicationsBox);
            yOffset += 30;

            this.Controls.Add(CreateLabel("Blood Pressure:", 20, yOffset));
            bloodPressureBox = CreateTextBox(150, yOffset, patient.bloodpressure);
            this.Controls.Add(bloodPressureBox);
            yOffset += 30;

            this.Controls.Add(CreateLabel("Treatment:", 20, yOffset));
            treatmentBox = CreateTextBox(150, yOffset, patient.treatment1);
            this.Controls.Add(treatmentBox);
            yOffset += 30;

            this.Controls.Add(CreateLabel("Treatment Date:", 20, yOffset));
            treatmentDatePicker = new DateTimePicker
            {
                Location = new Point(150, yOffset),
                Size = new Size(200, 25),
                Format = DateTimePickerFormat.Short,
                Value = patient.treatmentdate1 ?? DateTime.Today
            };
            this.Controls.Add(treatmentDatePicker);
            yOffset += 30;

            this.Controls.Add(CreateLabel("Treatment Result:", 20, yOffset));
            treatmentResultBox = CreateTextBox(150, yOffset, patient.treatmentresult1);
            this.Controls.Add(treatmentResultBox);
            yOffset += 40;

            // Save Button
            saveBtn = new Button
            {
                Text = "Save",
                Location = new Point(150, yOffset),
                Size = new Size(100, 30)
            };
            saveBtn.Click += SaveBtn_Click;
            this.Controls.Add(saveBtn);

            // Cancel Button
            cancelBtn = new Button
            {
                Text = "Cancel",
                Location = new Point(270, yOffset),
                Size = new Size(100, 30)
            };
            cancelBtn.Click += (s, e) => this.Close();
            this.Controls.Add(cancelBtn);
        }

        private Label CreateLabel(string text, int x, int y) => new Label { Text = text, Location = new Point(x, y), AutoSize = true };
        private TextBox CreateTextBox(int x, int y, string value, int maxLength = 255)
        {
            return new TextBox
            {
                Location = new Point(x, y),
                Size = new Size(200, 25),
                Text = value,
                MaxLength = maxLength
            };
        }

        private async void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Handling Date of Birth and Treatment Date
                DateTime? newDOB = dobPicker.Value;
                DateTime? newTreatmentDate = treatmentDatePicker.Value;

                // Handling Address Fields (Split into Home Address, City, State, Zip)
                string[] addressParts = addressBox.Text.Split(',');
                string homeAddress = addressParts.Length > 0 ? addressParts[0].Trim() : "";
                string city = addressParts.Length > 1 ? addressParts[1].Trim() : "";
                string state = addressParts.Length > 2 ? addressParts[2].Trim() : "";
                string zip = addressParts.Length > 3 ? addressParts[3].Trim() : "";

                // Ensure each field does not exceed Supabase limits
                homeAddress = homeAddress.Length > 255 ? homeAddress.Substring(0, 255) : homeAddress;
                city = city.Length > 100 ? city.Substring(0, 100) : city;
                state = state.Length > 2 ? state.Substring(0, 2) : state;
                zip = zip.Length > 10 ? zip.Substring(0, 10) : zip;

                // Handling Business Address (Split into Address, City, Zip)
                string[] businessAddressParts = businessAddressBox.Text.Split(',');
                string businessAddress = businessAddressParts.Length > 0 ? businessAddressParts[0].Trim() : "";
                string businessCity = businessAddressParts.Length > 1 ? businessAddressParts[1].Trim() : "";
                string businessZip = businessAddressParts.Length > 2 ? businessAddressParts[2].Trim() : "";

                // Create the updated patient object
                Patient updatedPatient = new Patient
                {
                    id = currentPatient.id,  // Keep the original ID
                    patientfirstname = firstNameBox.Text,
                    patientlastname = lastNameBox.Text,
                    Phone = phoneBox.Text,
                    Email = emailBox.Text,
                    HomeAddress = homeAddress,
                    City = city,
                    State = state,
                    Zip = zip,
                    DateOfBirth = newDOB ?? currentPatient.DateOfBirth, // Ensure valid date
                    Gender = genderBox.Text,
                    Insuranceco = insuranceBox.Text,
                    Policyno = policyBox.Text,
                    occupation = occupationBox.Text,
                    employedby = employedBox.Text,
                    businessaddress = businessAddress,
                    businesscity = businessCity,
                    businesszip = businessZip,
                    PrimaryDoctor = doctorBox.Text,
                    primarydoctorphone = doctorPhoneBox.Text,
                    doctordiagnosis = diagnosisBox.Text,
                    healthissuedescription = healthIssueBox.Text,
                    healthissueduration = durationBox.Text,
                    Medications = medicationsBox.Text,
                    bloodpressure = bloodPressureBox.Text,
                    treatment1 = treatmentBox.Text,
                    treatmentdate1 = newTreatmentDate,
                    treatmentresult1 = treatmentResultBox.Text
                };

                // Send update to Supabase
                await _supabaseService.UpdatePatientAsync(updatedPatient);

                MessageBox.Show("Patient information updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Return updated patient to calling form
                UpdatedPatient = updatedPatient;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating patient: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
