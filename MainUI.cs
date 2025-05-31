using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VirtualVanguard
{
    public partial class MainUI : Form
    {
        private readonly SupabaseService _supabaseService;
        private bool isNameAscending = true;
        private bool isContactAscending = true;
        private bool isDoctorAscending = true;

        private int currentPage = 1;
        private int pageSize = 10;  // Number of patient cards per page, more can be lag, need to work on solution
        private int totalPages = 1;

        private List<Appointment> allAppointments = new List<Appointment>();  // Store all appointments

        private List<Patient> allPatients = new List<Patient>();  // Store the sorted patient list globally
        public MainUI(SupabaseService supabaseService)
        {
            InitializeComponent();
            _supabaseService = supabaseService;
            LoadPatients();
            flowPatientCard.VerticalScroll.Visible = false;  // Hide the vertical scrollbar
            flowPatientCard.HorizontalScroll.Visible = false;  // Hide the horizontal scrollbar

            // Attach context menu to DataGridView
            appointmentsGrid.ContextMenuStrip = appointmentsContextMenuStrip;
        }

        private async void MainUI_Load(object sender, EventArgs e)
        {
            try
            {
                // Fetch data from Supabase
                var patients = await _supabaseService.GetPatientsAsync();
                LoadAppointments();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Fetch the logged-in user's email from Supabase
            string loggedInEmail = SupabaseService.GetCurrentUserEmail();  // Replace with actual method

            // Set the email in the menu item
            emailMenuItem.Text = loggedInEmail;

            // Ensure the email is non-clickable
            emailMenuItem.Enabled = false;

            // Load the original image
            Image originalImage = Image.FromFile(Path.Combine(Application.StartupPath, "Resources", "user_icon.png"));
            Image resizedImage = new Bitmap(originalImage, new Size(60, 60)); // Adjust size as needed
            accountButton.Image = resizedImage;

            // Open the menu on PictureBox click
            accountButton.Click += (s, ev) => accountMenuStrip.Show(accountButton, new Point(0, accountButton.Height));

            // Set today’s date in the label
            todayLabel.Text = DateTime.Today.ToString("MMMM dd, yyyy");

            // Filter and display today's appointments count
            FilterAppointmentsByDate("day");
            UpdateFilterButtonStyles(dayFilterBtn); // Default: "Day" is selected

            // Add About UserControl to the "About" TabPage
            AboutUserControl aboutPage = new AboutUserControl();
            tabControl1.TabPages["About"].Controls.Add(aboutPage);
        }
        private async void LoadPatients()
        {
            try
            {
                // Fetch from Supabase ONLY if `allPatients` is empty
                if (allPatients == null || allPatients.Count == 0)
                {
                    allPatients = await _supabaseService.GetPatientsAsync();
                }

                totalPages = (int)Math.Ceiling((double)allPatients.Count / pageSize);
                UpdatePageLabel();
                LoadPage(allPatients);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading patients: {ex.Message}");
            }
        }
        private void LoadPage(List<Patient> patients)
        {
            flowPatientCard.Controls.Clear();  // Clear previous cards

            // Get the patients for the current page
            var pagePatients = patients.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

            // Add patient cards for the current page
            AddPatientCardsToPanel(pagePatients);

            // Enable/disable navigation buttons
            previousBtn.Enabled = currentPage > 1;
            nextBtn.Enabled = currentPage < totalPages;
        }
        private void UpdatePageLabel()
        {
            pageLabel.Text = $"Page {currentPage} of {totalPages}";
        }
        private void AddPatientCardsToPanel(List<Patient> patients)
        {
            // Clear the FlowLayoutPanel before adding new patient cards

            flowPatientCard.Controls.Clear();


            foreach (var patient in patients)
            {
                Console.WriteLine($"Adding Patient: {patient.patientfirstname} {patient.patientlastname} | ID: {patient.id}");

                PatientCard patientCard = new PatientCard
                {
                    PatientData = patient
                };

                patientCard.patientNameLbl.Text = $"{patient.patientfirstname + " " + patient.patientlastname}";
                patientCard.patientAGLbl.Text = $"{CalculateAge(patient.DateOfBirth)}, {patient.Gender}";
                patientCard.patientEmailLbl.Text = patient.Email;
                patientCard.patientPhoneLbl.Text = patient.Phone;
                patientCard.patientPrimaryDoctorLbl.Text = patient.PrimaryDoctor ?? "Unknown";

                patientCard.ViewDetailsClicked += (s, p) => OpenPatientDetailsForm(p);

                flowPatientCard.Controls.Add(patientCard);  // Add the patient card
            }
            

        }
        private void OpenPatientDetailsForm(Patient patient)
        {
            var detailsForm = new PatientDetails(patient, _supabaseService); // Pass _supabaseService
            detailsForm.ShowDialog();
        }
        private int CalculateAge(DateTime birthDate)
        {
            var today = DateTime.Today;
            int age = today.Year - birthDate.Year;
            if (birthDate.Date > today.AddYears(-age)) age--;
            return age;
        }
        private void SortPatients(string sortBy, bool ascending)
        {
            try
            {
                if (allPatients == null || allPatients.Count == 0) return;  // No need to sort empty data

                switch (sortBy.ToLower())
                {
                    case "name":
                        allPatients = ascending
                            ? allPatients.OrderBy(p => p.patientfirstname).ToList()
                            : allPatients.OrderByDescending(p => p.patientfirstname).ToList();
                        break;

                    case "contact":
                        allPatients = ascending
                            ? allPatients.OrderBy(p => p.Email).ToList()
                            : allPatients.OrderByDescending(p => p.Email).ToList();
                        break;

                    case "doctor":
                        allPatients = ascending
                            ? allPatients.OrderBy(p => p.PrimaryDoctor).ToList()
                            : allPatients.OrderByDescending(p => p.PrimaryDoctor).ToList();
                        break;
                }

                // Reset to page 1 after sorting
                currentPage = 1;
                totalPages = (int)Math.Ceiling((double)allPatients.Count / pageSize);
                UpdatePageLabel();
                LoadPage(allPatients);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sorting patients: {ex.Message}");
            }
        }

        // search for client
        private List<Patient> ClientSideSearch(List<Patient> patients, string searchTerm)
        {
            searchTerm = searchTerm.ToLower();  // Normalize the search term for case-insensitive matching

            // Check null before everything search
            return patients.Where(p =>
                (p.patientlastname != null && p.patientlastname.ToLower().Contains(searchTerm)) ||
                (p.patientfirstname != null && p.patientfirstname.ToLower().Contains(searchTerm)) ||
                (p.Email != null && p.Email.ToLower().Contains(searchTerm)) ||
                (p.Phone != null && p.Phone.ToLower().Contains(searchTerm)) ||
                (p.PrimaryDoctor != null && p.PrimaryDoctor.ToLower().Contains(searchTerm)) ||
                (p.DateOfBirth != null && CalculateAge(p.DateOfBirth).ToString() == searchTerm)  
            ).ToList();
        }

        private void flowPatientCard_Paint(object sender, PaintEventArgs e)
        {
            
        }


        // unable to hide the scroll bar
        private void flowPatientCard_Layout(object sender, LayoutEventArgs e)
        {
            flowPatientCard.VerticalScroll.Visible = false;
            flowPatientCard.HorizontalScroll.Visible = false;
        }

        private void nameBtn_Click(object sender, EventArgs e)
        {
            SortPatients("name", isNameAscending);
            isNameAscending = !isNameAscending;  // Toggle sort order
        }

        private void contactBtn_Click(object sender, EventArgs e)
        {
            SortPatients("contact", isContactAscending);
            isContactAscending = !isContactAscending;
        }

        private void doctorBtn_Click(object sender, EventArgs e)
        {
            SortPatients("doctor", isDoctorAscending);
            isDoctorAscending = !isDoctorAscending;
        }

        private void previousBtn_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadPatients();  // Reload with the updated page number
            }
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                LoadPatients();
            }
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {

            string searchTerm = searchBox.Text.Trim();

            if (string.IsNullOrEmpty(searchTerm))
            {
                currentPage = 1;  // Reset page when search is cleared
                LoadPatients();  // Reload all patients if search is cleared
            }
            else
            {
                var filteredPatients = ClientSideSearch(allPatients, searchTerm);  // Filter the full list
                currentPage = 1;
                totalPages = (int)Math.Ceiling((double)filteredPatients.Count / pageSize);
                UpdatePageLabel();
                LoadPage(filteredPatients);
            }
        }

        private async void addBtn_Click(object sender, EventArgs e)
        {
            AddPatientForm addPatientForm = new AddPatientForm(_supabaseService);
            addPatientForm.ShowDialog(); // Open form and wait until it closes

            // ✅ Force re-fetch the entire patient list
            allPatients = await _supabaseService.GetPatientsAsync();

            if (allPatients == null || allPatients.Count == 0)
            {
                MessageBox.Show("No patients found after adding!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ✅ Find the latest patient
            var latestPatient = allPatients.OrderByDescending(p => p.registrationdate).FirstOrDefault();

            if (latestPatient != null)
            {
                Console.WriteLine($"DEBUG: Latest Patient Added - {latestPatient.patientfirstname} {latestPatient.patientlastname} | ID: {latestPatient.id}");

                // ✅ Append only if it's a truly new patient
                bool patientExists = allPatients.Any(p => p.id == latestPatient.id);
                if (!patientExists)
                {
                    allPatients.Add(latestPatient);
                }
            }

            // ✅ Force UI update
            totalPages = (int)Math.Ceiling((double)allPatients.Count / pageSize);
            UpdatePageLabel();
            LoadPage(allPatients);
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            TabPage tabPage = tabControl1.TabPages[e.Index];

            // Set background color for selected and non-selected tabs
            Color tabColor = (e.State == DrawItemState.Selected) ? Color.AliceBlue : Color.White;

            // Fill the tab background
            using (Brush brush = new SolidBrush(tabColor))
            {
                g.FillRectangle(brush, e.Bounds);
            }

            // Load images dynamically from the "Resources" folder
            string imagePath = "";
            switch (tabPage.Text)
            {
                case "Dashboard":
                    imagePath = Path.Combine(Application.StartupPath, "Resources", "Dashboard_img.png");
                    break;
                case "Calendar":
                    imagePath = Path.Combine(Application.StartupPath, "Resources", "Calendar_img.png");
                    break;
                case "About":
                    imagePath = Path.Combine(Application.StartupPath, "Resources", "About_img.png");
                    break;
            }

            if (File.Exists(imagePath))
            {
                using (Image tabImage = Image.FromFile(imagePath))
                {
                    int imgX = e.Bounds.X + 20;  // Adjust position
                    int imgY = e.Bounds.Y + (e.Bounds.Height - tabImage.Height) / 2;  // Center image
                    g.DrawImage(tabImage, imgX, imgY, 32, 32);  
                }
            }

        }

        private void Logout()
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Redirect to Login Form
                this.Hide();
                LoginForm loginForm = new LoginForm(_supabaseService);
                loginForm.ShowDialog();
                this.Close();
            }
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logout();
        }

        private async void LoadAppointments()
        {
            try
            {
                allAppointments = await _supabaseService.GetAppointmentsAsync(); // Fetch all appointments

                // Convert patient_id to patient_name for display
                var formattedAppointments = allAppointments.Select(a => new
                {
                    ID = a.id,
                    Patient = a.patient_name,  // ✅ Replacing patient_id with patient_name
                    Doctor = a.doctor_name,
                    Appointment_Date = a.appointment_date.ToString("MM/dd/yyyy h:mm tt"),
                    Time = a.time,
                    Notes = a.notes
                }).ToList();

                // Update DataGridView
                appointmentsGrid.DataSource = null;
                appointmentsGrid.DataSource = formattedAppointments;


                FilterAppointmentsByDate("day");
                UpdateFilterButtonStyles(dayFilterBtn); // Highlight "Day" button
                // Update appointment count label
                appointmentCountLabel.Text = $"Total Appointments: {formattedAppointments.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading appointments: {ex.Message}");
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Text == "Calendar")
            {
                LoadAppointments();
            }
        }

        private void addAppointmentBtn_Click(object sender, EventArgs e)
        {
            AddAppointmentForm addForm = new AddAppointmentForm(_supabaseService);
            addForm.ShowDialog();
            LoadAppointments(); // Refresh DataGridView after adding
        }

        private void editAppointmentMenuItem_Click(object sender, EventArgs e)
        {
            if (appointmentsGrid.SelectedRows.Count > 0)
            {
                var selectedAppointment = (Appointment)appointmentsGrid.SelectedRows[0].DataBoundItem;
                AddAppointmentForm editForm = new AddAppointmentForm(_supabaseService, selectedAppointment);
                editForm.ShowDialog();
                LoadAppointments(); // Refresh DataGridView after edit
            }
        }

        private async void deleteAppointmentMenuItem_Click(object sender, EventArgs e)
        {
            if (appointmentsGrid.SelectedRows.Count > 0)
            {
                var selectedAppointment = (Appointment)appointmentsGrid.SelectedRows[0].DataBoundItem;

                var confirmResult = MessageBox.Show("Are you sure you want to delete this appointment?",
                                                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirmResult == DialogResult.Yes)
                {
                    await _supabaseService.DeleteAppointmentAsync(selectedAppointment.id);
                    MessageBox.Show("Appointment deleted successfully!");
                    LoadAppointments(); // Refresh DataGridView after deletion
                }
            }
        }

        private void FilterAppointmentsByDate(string filterType)
        {
            DateTime today = DateTime.Today;
            List<Appointment> filteredAppointments = new List<Appointment>();

            switch (filterType.ToLower())
            {
                case "day":
                    filteredAppointments = allAppointments
                        .Where(a => a.appointment_date.Date == today).ToList();
                    break;

                case "week":
                    DateTime startOfWeek = today.AddDays(-(int)today.DayOfWeek); // Start of week (Sunday)
                    DateTime endOfWeek = startOfWeek.AddDays(6); // End of week (Saturday)
                    filteredAppointments = allAppointments
                        .Where(a => a.appointment_date.Date >= startOfWeek && a.appointment_date.Date <= endOfWeek).ToList();
                    break;

                case "month":
                    filteredAppointments = allAppointments
                        .Where(a => a.appointment_date.Month == today.Month && a.appointment_date.Year == today.Year).ToList();
                    break;
            }

            // Force UI to refresh the table
            appointmentsGrid.DataSource = null;
            appointmentsGrid.DataSource = filteredAppointments;

            // Update appointment count label
            appointmentCountLabel.Text = $"Total Appointments: {filteredAppointments.Count}";

        }

        private void dayFilterBtn_Click(object sender, EventArgs e)
        {
            FilterAppointmentsByDate("day");
            UpdateFilterButtonStyles(dayFilterBtn);
        }

        private void weekFilterBtn_Click(object sender, EventArgs e)
        {
            FilterAppointmentsByDate("week");
            UpdateFilterButtonStyles(weekFilterBtn);
        }

        private void monthFilterBtn_Click(object sender, EventArgs e)
        {
            FilterAppointmentsByDate("month");
            UpdateFilterButtonStyles(monthFilterBtn);
        }

        private void UpdateFilterButtonStyles(Button selectedButton)
        {
            // Reset all buttons to default color
            dayFilterBtn.BackColor = Color.LightGray;
            dayFilterBtn.ForeColor = Color.Black;
            weekFilterBtn.BackColor = Color.LightGray;
            weekFilterBtn.ForeColor = Color.Black;
            monthFilterBtn.BackColor = Color.LightGray;
            monthFilterBtn.ForeColor = Color.Black;

            // Change the selected button color
            selectedButton.BackColor = Color.SteelBlue;
            selectedButton.ForeColor = Color.White; // Optional: Change text color for better contrast
        }
    }
}
