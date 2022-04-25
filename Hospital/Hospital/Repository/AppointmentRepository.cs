using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Hospital.Repository;

namespace Hospital.Model
{
   public class AppointmentRepository
   {
        private readonly string _path;
        private ObservableCollection<Appointment> _appointments;
        private Serializer<Appointment> _appointmentSerializer;

        public AppointmentRepository(string path) 
        {
            _path = path;
        }

        public ObservableCollection<Appointment> Read()
        {
            _appointments = _appointmentSerializer.FromCSV("appointments.txt");
            return _appointments;
        }
      
        public void Write()
        {
            _appointmentSerializer = new Serializer<Appointment>();
            _appointmentSerializer.ToCSV("appointments.txt", _appointments);
        }
   }
}