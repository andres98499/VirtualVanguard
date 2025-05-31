using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualVanguard
{
    public class Appointment
    {
        public Guid id { get; set; }
        public Guid patient_id { get; set; }
        public string doctor_name { get; set; }
        public DateTime appointment_date { get; set; }
        public string time { get; set; }
        public string notes { get; set; }

        //  New property to store patient name
        public string patient_name { get; set; }

        // Nested object to fetch patient data from Supabase
        public Patient patient { get; set; }
    }
}
