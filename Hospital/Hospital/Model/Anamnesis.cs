using System.Runtime.Serialization;

namespace Hospital.Model
{
    [DataContract]
    public class Anamnesis
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Diagnosis { get; set; }
        public Therapy Therapy { get; set; }
        [DataMember]
        public int TherapyId { get; set; }
        public Appointment Appointment { get; set; }
        [DataMember]
        public int AppointmentId { get; set; }
        [DataMember]
        public bool Referral { get; set; }

        public Anamnesis()
        {
        }
    }
}