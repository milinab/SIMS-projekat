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
        public string Specialization { get; set; }
        [DataMember]
        public VacationState State { get; set; }
        
        public Vacation(DateTime startDate, DateTime endDate, string reason, string specialization, VacationState state)
        {
            StartDate = startDate;
            EndDate = endDate;
            Reason = reason;
            Specialization = specialization;
            State = state;
        }

        public bool IsStartDateBeforeDate(DateTime dateTime)
        {
            return StartDate < dateTime;
        }
        
        public bool IsEndDateBeforeDate(DateTime dateTime)
        {
            return EndDate < dateTime;
        }
    }
}