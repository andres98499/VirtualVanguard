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
    public partial class AddAppointmentForm : Form
    {
        private readonly SupabaseService _supabaseService;
        private Appointment _currentAppointment = null;
        public AddAppointmentForm(SupabaseService supabaseService, Appointment existingAppointment = null)
        {
            InitializeComponent();
            _supabaseService = supabaseService;
            _currentAppointment = existingAppointment;

            LoadPatients();
            LoadTimeOptions();

            if (_currentAppointment != null)
            {
                // Populate fields for editing
                patientComboBox.SelectedValue = _currentAppointment.patient_id;
                doctorTextBox.Text = _currentAppointment.doctor_name;
                datePicker.Value = _currentAppointment.appointment_date;
                timeComboBox.SelectedItem = _currentAppointment.time;
                notesBox.Text = _currentAppointment.notes;
                saveBtn.Text = "Update Appointment"; // Change button text
            }
        }

        private void notesBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddAppointmentForm_Load(object sender, EventArgs e)
        {

        }

        private async void LoadPatients()
        {
            var patients = await _supabaseService.GetPatientsAsync();
            patientComboBox.DataSource = patients;
            patientComboBox.DisplayMember = "patientlastname";  // Display last name
            patientComboBox.ValueMember = "id";  // Store patient ID

            // Enable AutoComplete
            patientComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            patientComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void LoadTimeOptions()
        {
            timeComboBox.Items.AddRange(new string[]
            {
                "08:00 AM", "09:00 AM", "10:00 AM", "11:00 AM",
                "01:00 PM", "02:00 PM", "03:00 PM", "04:00 PM"
            });
            timeComboBox.SelectedIndex = 0; // Default
        }

        private async void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (_currentAppointment == null)
                {
                    // Add new appointment
                    var newAppointment = new Appointment
                    {
                        id = Guid.NewGuid(),
                        patient_id = (Guid)patientComboBox.SelectedValue,
                        doctor_name = doctorTextBox.Text,
                        appointment_date = datePicker.Value,
                        time = timeComboBox.SelectedItem.ToString(),
                        notes = notesBox.Text
                    };

                    await _supabaseService.AddAppointmentAsync(newAppointment);
                    MessageBox.Show("Appointment added successfully!");
                }
                else
                {
                    // Update existing appointment
                    _currentAppointment.patient_id = (Guid)patientComboBox.SelectedValue;
                    _currentAppointment.doctor_name = doctorTextBox.Text;
                    _currentAppointment.appointment_date = datePicker.Value;
                    _currentAppointment.time = timeComboBox.SelectedItem.ToString();
                    _currentAppointment.notes = notesBox.Text;

                    await _supabaseService.UpdateAppointmentAsync(_currentAppointment);
                    MessageBox.Show("Appointment updated successfully!");
                }

                this.Close(); // Close form after saving
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

    }
}
