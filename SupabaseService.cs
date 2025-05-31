using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using VirtualVanguard;

namespace VirtualVanguard
{
    public class SupabaseService
    {
        // get key and url from Supabase API setting
        private static readonly HttpClient _httpClient = new HttpClient();
        private readonly string _supabaseUrl;
        private readonly string _supabaseKey;


        private static string loggedInEmail = null;  // Store logged-in email

        public SupabaseService(string url, string key)
        {
            _supabaseUrl = url;
            _supabaseKey = key;

            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _supabaseKey);
            _httpClient.DefaultRequestHeaders.Add("apikey", _supabaseKey);
        }
        public async Task<List<Patient>> GetPatientsAsync()
        {
            var endpoint = $"{_supabaseUrl}/rest/v1/patientregistration1?select=*";
            var response = await _httpClient.GetAsync(endpoint);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();

                var patients = JsonConvert.DeserializeObject<List<Patient>>(json);
                return patients;
            }

            var errorMessage = await response.Content.ReadAsStringAsync(); // Log this
            throw new Exception($"Failed to fetch patients: {response.StatusCode}, {errorMessage}");
        }

     
        public async Task AddPatientAsync(Patient newPatient)
        {
            var endpoint = $"{_supabaseUrl}/rest/v1/patientregistration1"; // Ensure correct table name

            // ✅ Serialize the Patient object directly
            var json = JsonConvert.SerializeObject(newPatient);
            Console.WriteLine($"DEBUG: Sending JSON Data = {json}"); // Debugging

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(endpoint, content);

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception($"Failed to add patient: {response.StatusCode}, {errorMessage}");
            }
        }
        public async Task UpdatePatientAsync(Patient updatedPatient)
        {
            var endpoint = $"{_supabaseUrl}/rest/v1/patientregistration1?id=eq.{updatedPatient.id}";

            var json = JsonConvert.SerializeObject(updatedPatient);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(new HttpMethod("PATCH"), endpoint)
            {
                Content = content
            };

            var response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception($"Failed to update patient: {response.StatusCode}, {errorMessage}");
            }
        }

        public async Task<bool> LoginAsync(string email, string password)
        {
            var endpoint = $"{_supabaseUrl}/auth/v1/token?grant_type=password";
            var credentials = new { email, password };
            var json = JsonConvert.SerializeObject(credentials);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(endpoint, content);

            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                var authResult = JsonConvert.DeserializeObject<AuthResponse>(responseData);

                // Save token for future API calls
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authResult.AccessToken);

                // Store the logged-in email
                SetCurrentUserEmail(email);

                return true;
            }
            return false;
        }

        // Store the logged-in email
        public static void SetCurrentUserEmail(string email)
        {
            loggedInEmail = email;
        }

        // Retrieve the logged-in user's email
        public static string GetCurrentUserEmail()
        {
            // Handle debug mode without making code unreachable
            if (System.Diagnostics.Debugger.IsAttached)
            {
                return "test@example.com";  // Placeholder email when debugging
            }

            if (!string.IsNullOrEmpty(loggedInEmail))
            {
                return loggedInEmail;  // Return stored email
            }

            return "Unknown User";  // Default fallback
        }


        // Helper class for parsing authentication response
        private class AuthResponse
        {
            [JsonProperty("access_token")]
            public string AccessToken { get; set; }
        }


        // get the appointment to the table
        public async Task<List<Appointment>> GetAppointmentsAsync()
        {
            var endpoint = $"{_supabaseUrl}/rest/v1/appointments?select=id,patient_id,doctor_name,appointment_date,time,notes,patient:patient_id(patientfirstname,patientlastname)";
            var response = await _httpClient.GetAsync(endpoint);

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception($"Failed to fetch appointments: {response.StatusCode}, {errorMessage}");
            }

            var json = await response.Content.ReadAsStringAsync();
            var appointments = JsonConvert.DeserializeObject<List<Appointment>>(json);

            // Convert patient_id to patient_name
            foreach (var appointment in appointments)
            {
                if (appointment.patient != null)
                {
                    appointment.patient_name = $"{appointment.patient.patientfirstname} {appointment.patient.patientlastname}";
                }
            }

            return appointments;
        }

        public async Task AddAppointmentAsync(Appointment appointment)
        {
            var endpoint = $"{_supabaseUrl}/rest/v1/appointments";

            // Ensure correct JSON formatting with "patient_id" instead of "patient"
            var json = JsonConvert.SerializeObject(new
            {
                patient_id = appointment.patient_id,  // ✅ Use correct column name
                doctor_name = appointment.doctor_name,
                appointment_date = appointment.appointment_date,
                time = appointment.time,
                notes = appointment.notes
            });

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(endpoint, content);

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception($"Failed to add appointment: {response.StatusCode}, {errorMessage}");
            }
        }

        public async Task UpdateAppointmentAsync(Appointment updatedAppointment)
        {
            var endpoint = $"{_supabaseUrl}/rest/v1/appointments?id=eq.{updatedAppointment.id}";
            var json = JsonConvert.SerializeObject(updatedAppointment);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(new HttpMethod("PATCH"), new Uri(endpoint))
            {
                Content = content
            };

            var response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception($"Failed to update appointment: {response.StatusCode}, {errorMessage}");
            }
        }

        public async Task DeleteAppointmentAsync(Guid appointmentId)
        {
            var endpoint = $"{_supabaseUrl}/rest/v1/appointments?id=eq.{appointmentId}";
            var request = new HttpRequestMessage(HttpMethod.Delete, endpoint);

            var response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception($"Failed to delete appointment: {response.StatusCode}, {errorMessage}");
            }
        }



    }
}
