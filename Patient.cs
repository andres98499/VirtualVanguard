using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace VirtualVanguard
{
    public class Patient
    {

        // detail of patient
        public string patientlastname { get; set; }
        public string patientfirstname { get; set; }
        public Guid id { get; set; }
        public DateTime registrationdate { get; set; }

        [JsonProperty("dateofbirth")]
        public DateTime DateOfBirth { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("maritalstatus")]
        public string MaritalStatus { get; set; }

        public string spousename { get; set; }
        public string spousephone { get;set; }

        [JsonProperty("homeaddress")]
        public string HomeAddress { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("zip")]
        public string Zip { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        public string driverlicenseno { get; set; }
        public string occupation {  get; set; }
        public string employedby { get; set; }
        public string businessaddress { get; set; }
        public string businesscity { get; set; }
        public string businesszip { get; set; }

        [JsonProperty("primarydoctor")]
        public string PrimaryDoctor { get; set; }

        public string primarydoctorphone { get; set; }

        [JsonProperty("insuranceco")]
        public string Insuranceco {  get; set; }

        [JsonProperty("policyno")]
        public string Policyno { get; set; }


        // health info
        [JsonProperty("weight")]
        public string Weight { get; set; }

        [JsonProperty("height")]
        public string Height { get; set; }

        public string bloodpressure { get; set; }
        public string doctordiagnosis { get; set; }
    
        public string treatment1 { get; set; }
        public DateTime? treatmentdate1 { get; set; }
        public string treatmentresult1 { get; set; }
        public string healthissuedescription { get; set; }
        public string healthissueduration { get; set; }

        [JsonProperty("medications")]
        public string Medications { get; set; }
    }
}
