using System;
using System.ComponentModel;
using ClassDiagram.Model;

namespace Hospital.Model
{
   public class Appointment: INotifyPropertyChanged
   {

        private int _id;
        private DateTime _date;

        public Doctor Doctor { get; set; }
        public Patient patient;
        public Room room;

        public Appointment( ) { }

        public Appointment(int id, Doctor doctor, DateTime dateTime)
        {
            _id = id;
            Doctor = doctor;
            _date = dateTime;
        }

        public int Id
        {
          get { return _id; }
          set { _id = value; }
        }

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; OnPropertyChanged(); }
        }

        private void OnPropertyChanged(string name="") {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public TimeSpan Duration 
        {
            get;
            set;
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