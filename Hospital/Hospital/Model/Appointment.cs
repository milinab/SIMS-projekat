using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Hospital.Model
{
    [DataContract]
    public class Appointment 
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public TimeSpan Duration { get; set; }
        [DataMember]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        [DataMember]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        [DataMember]
        public int RoomId { get; set; }
        public Room Room { get; set; }

        public Appointment()
        {
        }

        public Appointment(Room room, DateTime duration)
        {
            Room = room;
            RoomId = room.Id;
            Date = duration;
        }
        public Appointment(Room room, DateTime date, TimeSpan duration)
        {
            Room = room;
            RoomId = room.Id;
            Date = date;
            Duration = duration;
        }

        public Appointment(DateTime date, TimeSpan duration, Doctor doctor, Patient patient, Room room)
        {
            Date = date;
            Duration = duration;
            DoctorId = doctor.Id;
            Doctor = doctor;
            PatientId = patient.Id;
            Patient = patient;
            RoomId = room.Id;
            Room = room;
        }
        
        public Appointment(int id, DateTime date, TimeSpan duration, Doctor doctor, Patient patient, Room room)
        {
            Id = id;
            Date = date;
            Duration = duration;
            Doctor = doctor;
            DoctorId = doctor.Id;
            Patient = patient;
            PatientId = patient.Id;
            Room = room;
            RoomId = room.Id;
        }
    }
}