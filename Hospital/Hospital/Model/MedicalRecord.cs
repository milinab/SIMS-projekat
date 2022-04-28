using System;
using System.Runtime.Serialization;

namespace Hospital.Model
{
    [DataContract]
    public class MedicalRecord
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string ChronicalDiseases { get; set; }
        [DataMember]
        public string Allergies { get; set; }
        [DataMember]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public MedicalRecord()
        {
        }
    }
}