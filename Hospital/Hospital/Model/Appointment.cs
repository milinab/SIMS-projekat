using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Hospital.Model
{
    [DataContract]
    public class Appointment: INotifyPropertyChanged 
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

        public Appointment(DateTime date, TimeSpan duration, Doctor doctor, Patient patient, Room room)
        {
            Date = date;
            Duration = duration;
            DoctorId = doctor.Id;
            Doctor = doctor;
            PatientId = patient.Id;
            Patient = patient;
            RoomId = int.Parse(room.Id);
            Room = room;
        }

        private void OnPropertyChanged(string name="") {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public System.Collections.ArrayList appointments;

        public event PropertyChangedEventHandler PropertyChanged;

        public System.Collections.ArrayList GetAppointments() {
            if (appointments == null)
                appointments = new System.Collections.ArrayList();
            return appointments;
        }

        /// <pdGenerated>default setter</pdGenerated>
        public void SetAppointment(System.Collections.ArrayList newAppointment) {
            RemoveAllAppointment();
            foreach (Appointment oAppointment in newAppointment)
                AddAppointment(oAppointment);
        }

        /// <pdGenerated>default Add</pdGenerated>
        public void AddAppointment(Appointment newAppointment) {
            if (newAppointment == null)
                return;
            if (this.appointments == null)
                this.appointments = new System.Collections.ArrayList();
            if (!this.appointments.Contains(newAppointment))
                this.appointments.Add(newAppointment);
        }

        /// <pdGenerated>default Remove</pdGenerated>
        public void RemoveAppointment(Appointment oldAppointment) {
            if (oldAppointment == null)
                return;
            if (this.appointments != null)
                if (this.appointments.Contains(oldAppointment))
                    this.appointments.Remove(oldAppointment);
        }

        /// <pdGenerated>default removeAll</pdGenerated>
        public void RemoveAllAppointment() {
            if (appointments != null)
                appointments.Clear();
        }
    }
}