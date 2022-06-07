using System.Runtime.Serialization;

namespace Hospital.Model
{
    [DataContract]
    public class Referral
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int PatientId { get; set; }
        [DataMember]
        public string Specialization { get; set; }
        [DataMember]
        public int DoctorId { get; set; }
        [DataMember]
        public string Reason { get; set; }

        public Referral()
        {
            
        }

        public Referral(int patientId, string specialization, int doctorId, string reason)
        {
            PatientId = patientId;
            Specialization = specialization;
            DoctorId = doctorId;
            Reason = reason;
        }
    }
}