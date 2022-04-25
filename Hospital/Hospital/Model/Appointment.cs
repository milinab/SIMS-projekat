using System;
using System.ComponentModel;
using ClassDiagram.Model;
using Hospital.Repository;

namespace Hospital.Model
{
   public class Appointment: Serializable, INotifyPropertyChanged 
   {

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Duration { get; set; }
        public Doctor Doctor { get; set; }
        public int DoctorId { get; set; }
        public Patient Patient { get; set; }
        public int PatientId { get; set; }
        public Room Room { get; set; }
        public int RoomId { get; set; }

        public Appointment( ) { }

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

        public string[] ToCSV() 
        {
            string[] csvValues =
            {
                Id.ToString(),
                Date.ToString(),
                Duration.ToString(),
                DoctorId.ToString(),
                PatientId.ToString(),
                RoomId.ToString()
            };
            return csvValues;
        }

        public void FromCSV(string[] values)
        {
            Id = int.Parse(values[0]);
            Date = Convert.ToDateTime(values[1]);
            Duration = TimeSpan.Parse(values[2]);
            DoctorId = int.Parse(values[3]);
            PatientId = int.Parse(values[4]);
            RoomId = int.Parse(values[5]);
        }
    }
}