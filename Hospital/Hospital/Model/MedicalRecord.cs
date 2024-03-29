using System;
using System.Collections.Generic;
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
        public List<int> AllergenIds{ get; set; }

        public MedicalRecord()
        {
        }

        public MedicalRecord(string chronicalDisease)
        {
            this.ChronicalDiseases = chronicalDisease;
        }
        public MedicalRecord(string chronicalDisease,int id)
        {
            this.ChronicalDiseases = chronicalDisease;
            this.Id = id;
        }

        public MedicalRecord(string chronicalDisease, List<int> allergenIds, int id)
        {
            this.ChronicalDiseases = chronicalDisease;
            this.AllergenIds = allergenIds;
            this.Id = id;
        }


        public MedicalRecord(string chronicalDisease, List<int> allergenIds)
        {
            this.ChronicalDiseases = chronicalDisease;
            this.AllergenIds = allergenIds;
        }
    }
}