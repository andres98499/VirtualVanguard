using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VirtualVanguard;

namespace VirtualVanguard
{
    public partial class AddPatientForm : Form
    {
        
        private readonly SupabaseService _supabaseService;
        public AddPatientForm(SupabaseService supabaseService)
        {
            InitializeComponent();
            _supabaseService = supabaseService ?? throw new ArgumentNullException(nameof(supabaseService));

        }
        private void AddPatientForm_Load(object sender, EventArgs e)
        {
            ApplyPlaceholder(this);
            InitializeTreatmentGrid();

            // Move focus away from textboxes to prevent auto-focus issue
            this.ActiveControl = emailBox;

            maleCheckBox.CheckedChanged += GenderCheckBox_CheckedChanged;
            femaleCheckBox.CheckedChanged += GenderCheckBox_CheckedChanged;

            sCheckBox.CheckedChanged += MaritalStatusCheckBox_CheckedChanged;
            mCheckBox.CheckedChanged += MaritalStatusCheckBox_CheckedChanged;
            dCheckBox.CheckedChanged += MaritalStatusCheckBox_CheckedChanged;
        }

        private void GenderCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is CheckBox selectedCheckBox && selectedCheckBox.Checked)
            {
                // Unsubscribe events temporarily
                maleCheckBox.CheckedChanged -= GenderCheckBox_CheckedChanged;
                femaleCheckBox.CheckedChanged -= GenderCheckBox_CheckedChanged;

                // Uncheck all gender checkboxes
                maleCheckBox.Checked = false;
                femaleCheckBox.Checked = false;

                // Check only the selected one
                selectedCheckBox.Checked = true;

                // Re-subscribe events
                maleCheckBox.CheckedChanged += GenderCheckBox_CheckedChanged;
                femaleCheckBox.CheckedChanged += GenderCheckBox_CheckedChanged;
            }
        }
        private void MaritalStatusCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is CheckBox selectedCheckBox && selectedCheckBox.Checked)
            {
                // Unsubscribe events temporarily
                sCheckBox.CheckedChanged -= MaritalStatusCheckBox_CheckedChanged;
                mCheckBox.CheckedChanged -= MaritalStatusCheckBox_CheckedChanged;
                dCheckBox.CheckedChanged -= MaritalStatusCheckBox_CheckedChanged;

                // Uncheck all marital status checkboxes
                sCheckBox.Checked = false;
                mCheckBox.Checked = false;
                dCheckBox.Checked = false;

                // Check only the selected one
                selectedCheckBox.Checked = true;

                // Enable/Disable Spouse fields based on selection
                bool isMarried = mCheckBox.Checked;
                spouseNameBox.Enabled = isMarried;
                spousePhoneBox.Enabled = isMarried;

                if (!isMarried)
                {
                    spouseNameBox.Clear();
                    spousePhoneBox.Clear();
                }

                // Re-subscribe events
                sCheckBox.CheckedChanged += MaritalStatusCheckBox_CheckedChanged;
                mCheckBox.CheckedChanged += MaritalStatusCheckBox_CheckedChanged;
                dCheckBox.CheckedChanged += MaritalStatusCheckBox_CheckedChanged;
            }
        }
        private void ApplyPlaceholder(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.Tag = textBox.Text;  // Save the initial placeholder text
                    textBox.ForeColor = Color.Gray;

                    textBox.Enter += HandlePlaceholder;
                    textBox.Leave += HandlePlaceholder;
                }
                else if (control.HasChildren)
                {
                    ApplyPlaceholder(control);  // Recursively check child controls
                }
            }
        }
        private void HandlePlaceholder(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (textBox != null)
            {
                if (textBox.Focused)
                {
                    // Clear placeholder text only if it matches the initial placeholder
                    if (textBox.ForeColor == Color.Gray)
                    {
                        textBox.Text = "";
                        textBox.ForeColor = Color.Black;
                    }
                }
                else
                {
                    // Restore placeholder only if the textbox is empty
                    if (string.IsNullOrWhiteSpace(textBox.Text))
                    {
                        textBox.Text = textBox.Tag.ToString();
                        textBox.ForeColor = Color.Gray;
                    }
                }
            }
        }
        private Patient CollectInputData()
        {
            if (string.IsNullOrWhiteSpace(firstNameBox.Text) || firstNameBox.Text == "First")
                throw new Exception("First Name is required.");
            if (string.IsNullOrWhiteSpace(lastNameBox.Text) || lastNameBox.Text == "Last")
                throw new Exception("Last Name is required.");
           
            if (registrationDatePicker.Value == null)
                throw new Exception("Registration date is required.");

            // Enforce MM/DD/YYYY format explicitly
            if (!DateTime.TryParseExact(dateOfBirthBox.Text, "MM/dd/yyyy",
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out DateTime parsedDate))
            {
                throw new Exception("Invalid Date of Birth format. Please enter in MM/DD/YYYY format.");
            }

            // Prevent future dates
            if (parsedDate > DateTime.Today)
                throw new Exception("Date of Birth cannot be in the future.");
            // Get Marital Status
            string maritalStatus = sCheckBox.Checked ? "S" :
                                    mCheckBox.Checked ? "M" :
                                    dCheckBox.Checked ? "D" : "";

            string spouseName = spouseNameBox.Text.Trim();
            string spousePhone = spousePhoneBox.Text.Trim();

            // ✅ Validate Marital Status and Spouse Information
            if (string.IsNullOrEmpty(maritalStatus))
            {
                throw new Exception("Please select a marital status.");
            }

            if (maritalStatus == "S" && (!string.IsNullOrEmpty(spouseName) || !string.IsNullOrEmpty(spousePhone)))
            {
                throw new Exception("Spouse information is not allowed for Single status.");
            }

            if (maritalStatus == "M" && (string.IsNullOrEmpty(spouseName) || string.IsNullOrEmpty(spousePhone)))
            {
                throw new Exception("Spouse information is required for Married status.");
            }
            // Convert multi-line text to a single string for storage
            string formattedHealthIssues = healthIssuesBox.Text.Replace("\r\n", " | ").Trim();
            string formattedDoctorDiagnosis = diagnosisBox.Text.Replace("\r\n", " | ").Trim();
            string formattedMedications = medicationsBox.Text.Replace("\r\n", " | ").Trim();

            // Collect patient details
            Patient newPatient = new Patient
            {
                id = Guid.NewGuid(),
                patientfirstname = firstNameBox.Text,
                patientlastname = lastNameBox.Text,
                DateOfBirth = parsedDate,
                Gender = maleCheckBox.Checked ? "M" : femaleCheckBox.Checked ? "F" : "",
                MaritalStatus = sCheckBox.Checked ? "S" :
                        mCheckBox.Checked ? "M" :
                        dCheckBox.Checked ? "D" : "",
                spousename = spouseNameBox.Text,
                spousephone = spousePhoneBox.Text,
                HomeAddress = streetBox.Text,
                City = cityBox.Text,
                State = stateBox.Text,
                Zip = zipBox.Text,
                Email = emailBox.Text,
                Phone = phoneBox.Text,
                driverlicenseno = licenseBox.Text,
                occupation = jobBox.Text,
                employedby = employedBox.Text,
                businessaddress = businessAddressBox.Text,
                businesscity = businessCityBox.Text,
                businesszip = businessZipBox.Text,
                PrimaryDoctor = doctorBox.Text,
                primarydoctorphone = doctorPhoneBox.Text,
                Insuranceco = insuranceBox.Text,
                Policyno = policyBox.Text,
                Weight = weightBox.Text,
                Height = heightBox.Text,
                bloodpressure = bloodPressureBox.Text,
                doctordiagnosis = formattedDoctorDiagnosis,
                healthissuedescription = formattedHealthIssues,
                healthissueduration = healthIssuesDurationBox.Text,
                Medications = formattedMedications,
            };

            // Collect selected treatments
            List<string> treatmentNames = new List<string>();
            List<string> treatmentDates = new List<string>();
            List<string> treatmentResults = new List<string>();

            foreach (DataGridViewRow row in dataGridViewTreatments.Rows)
            {
                if (row.IsNewRow || row.Cells[1].Value == null || string.IsNullOrWhiteSpace(row.Cells[1].Value.ToString()))
                {
                    continue;
                }

                if (row.Cells[0].Value is bool isChecked && isChecked)
                {
                    string treatmentName = row.Cells[1].Value.ToString();
                    string dateInput = row.Cells[2].Value?.ToString();
                    string didHelp = row.Cells[3].Value?.ToString();

                    DateTime? treatmentDate = null;

                    if (!string.IsNullOrWhiteSpace(dateInput))
                    {
                        if (!DateTime.TryParseExact(dateInput, "MM/dd/yyyy",
                            System.Globalization.CultureInfo.InvariantCulture,
                            System.Globalization.DateTimeStyles.None, out DateTime parsedTreatmentDate))
                        {
                            MessageBox.Show($"Invalid date format for {treatmentName}. Please enter MM/DD/YYYY.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            continue;
                        }
                        treatmentDate = parsedTreatmentDate;
                    }

                    treatmentNames.Add(treatmentName);
                    treatmentDates.Add(treatmentDate.HasValue ? treatmentDate.Value.ToString("yyyy-MM-dd") : "Unknown");
                    treatmentResults.Add(string.IsNullOrWhiteSpace(didHelp) ? "No answer" : didHelp);
                }
            }

            // ✅ Store multiple treatments in a single column as a comma-separated string
            newPatient.treatment1 = string.Join(", ", treatmentNames);
            newPatient.treatmentdate1 = null; // We only store treatment names as a string
            newPatient.treatmentresult1 = string.Join(", ", treatmentResults);

            return newPatient;
        }
        private async void addPatientBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Collect patient data
                Patient newPatient = CollectInputData(); // This method now validates marital status.

                // Save patient with treatment data inside `patientregistration1`
                await _supabaseService.AddPatientAsync(newPatient);

                MessageBox.Show("Patient saved successfully!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void stateBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;  // Ignore the input if it’s not a letter
            }
        }

        private void zipBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void phoneBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dateOfBirthBox_Leave(object sender, EventArgs e)
        {
            if (DateTime.TryParse(dateOfBirthBox.Text, out DateTime parsedDate))
            {
                // Optional: Prevent future dates
                if (parsedDate > DateTime.Today)
                {
                    MessageBox.Show("Date of Birth cannot be in the future.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dateOfBirthBox.Focus();
                }
            }
            else
            {
                MessageBox.Show("Invalid date format. Please enter a valid date (MM/DD/YYYY).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateOfBirthBox.Focus();
            }
        }

        private void InitializeTreatmentGrid()
        {
            dataGridViewTreatments.Rows.Clear();
            dataGridViewTreatments.Columns.Clear();

            // Column 1: Checkbox for treatment selection
            dataGridViewTreatments.Columns.Add(new DataGridViewCheckBoxColumn() { HeaderText = "✔" });

            // Column 2: Treatment names (Read-only)
            DataGridViewTextBoxColumn treatmentColumn = new DataGridViewTextBoxColumn();
            treatmentColumn.HeaderText = "Treatment";
            treatmentColumn.ReadOnly = true;
            dataGridViewTreatments.Columns.Add(treatmentColumn);

            // Column 3: Date (TextBox, but we'll replace with MaskedTextBox)
            dataGridViewTreatments.Columns.Add("Date", "Date");

            // Column 4: Did This Help? (Text input)
            dataGridViewTreatments.Columns.Add("DidThisHelp", "Did This Help?");

            // Add predefined treatments
            string[] treatments = { "Physical therapy", "Nerve block", "Nerve stimulator",
                            "Heat treatment", "Traction", "Massage", "Chiropractor" };

            foreach (string treatment in treatments)
            {
                dataGridViewTreatments.Rows.Add(false, treatment, "", ""); // Empty date field for manual input
            }

            dataGridViewTreatments.EditingControlShowing += dataGridViewTreatments_EditingControlShowing;
        }


        private void dataGridViewTreatments_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int columnIndex = dataGridViewTreatments.CurrentCell.ColumnIndex;

            if (columnIndex == 2) // Date column: Restrict input to numbers and "/"
            {
                if (e.Control is TextBox textBox)
                {
                    textBox.KeyPress -= TextBox_KeyPress_Restrict;
                    textBox.KeyPress += TextBox_KeyPress_Restrict;
                }
            }
            else if (columnIndex == 3) // "Did This Help?" column: Allow full editing
            {
                if (e.Control is TextBox textBox)
                {
                    textBox.ReadOnly = false; // Ensure it's editable
                    textBox.KeyPress -= TextBox_KeyPress_Restrict; // Remove restrictions
                }
            }
        }

        // Prevent invalid characters in the date field (Only numbers and "/")
        private void TextBox_KeyPress_Restrict(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '/' && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Validate Date Format After User Finishes Editing
        private void dataGridViewTreatments_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2) // Date column
            {
                var cellValue = dataGridViewTreatments.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();

                if (!string.IsNullOrWhiteSpace(cellValue) &&
                    !DateTime.TryParseExact(cellValue, "MM/dd/yyyy",
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None, out _))
                {
                    MessageBox.Show("Invalid date format! Please enter MM/DD/YYYY.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dataGridViewTreatments.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = ""; // Reset invalid entry
                }
            }
        }
    }
}
