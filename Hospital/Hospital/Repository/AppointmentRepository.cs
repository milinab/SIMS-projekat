using System;
using System.Collections.Generic;
using Hospital.Repository;

namespace Hospital.Model
{
   public class AppointmentRepository
   {
        private readonly string _path;
        private List<Appointment> _appointments;
        private Serializer<Appointment> _appointmentSerializer;

        public AppointmentRepository(string path) 
        {
            _path = path;
        }

        public List<Appointment> Read()
        {
            _appointments = _appointmentSerializer.fromCSV("appointments.txt");
            return _appointments;
        }
      
        public void Write()
        {
            _appointmentSerializer = new Serializer<Appointment>();
            _appointmentSerializer.toCSV("appointments.txt", _appointments);
        }
   }
}