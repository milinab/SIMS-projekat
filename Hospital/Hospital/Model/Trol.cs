using System;
using System.Runtime.Serialization;

namespace Hospital.Model
{
    [DataContract]
    public class Trol
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int PatientId { get; set; }
        [DataMember]
        public DateTime StartDate { get; set; }
        [DataMember]
        public int NumberOfCancellations { get; set; }

        public Trol()
        {
        }


        public Trol(int patientId, DateTime startDate,  int numberOfCancellations)
        {
            PatientId = patientId;
            StartDate = startDate;
            NumberOfCancellations = numberOfCancellations;
        }
    }
}