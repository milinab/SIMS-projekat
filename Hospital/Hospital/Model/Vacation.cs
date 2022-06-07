using System;
using System.Runtime.Serialization;
using Hospital.Enums;

namespace Hospital.Model
{
    [DataContract]
    public class Vacation
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public DateTime StartDate { get; set; }
        [DataMember]
        public DateTime EndDate { get; set; }
        [DataMember]
        public string Reason { get; set; }
        [DataMember]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        [DataMember]
        public VacationState State { get; set; }
        
        public Vacation(DateTime startDate, DateTime endDate, string reason, Doctor doctor, VacationState state)
        {
            StartDate = startDate;
            EndDate = endDate;
            Reason = reason;
            Doctor = doctor;
            DoctorId = doctor.Id;
            State = state;
        }

        public bool IsStartDateBefore(DateTime dateTime)
        {
            return StartDate < dateTime;
        }
        
        public bool IsEndDateBefore(DateTime dateTime)
        {
            return EndDate < dateTime;
        }
    }
}