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

        public MedicalRecord()
        {
        }

        public MedicalRecord(string chronicalDisease)
        {
            this.ChronicalDiseases = chronicalDisease;
        }
        

        public MedicalRecord(string chronicalDisease, string allergies)
        {
            this.ChronicalDiseases = chronicalDisease;
            this.Allergies = allergies;
        }
    }
}