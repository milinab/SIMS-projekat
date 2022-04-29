using System.Collections.ObjectModel;
using Hospital.Model;

namespace Hospital.Repository
{
   public class AppointmentRepository
   {
        private ObservableCollection<Appointment> _appointments;
        private readonly Serializer<Appointment> _serializer;

        public AppointmentRepository()
        {
            _serializer = new Serializer<Appointment>("appointments.csv");
            _appointments = new ObservableCollection<Appointment>();
        }

        public ObservableCollection<Appointment> Read()
        {
            _appointments = _serializer.Read();
            return _appointments;
        }

        public Appointment ReadById(int id)
        {
            foreach (Appointment appointment in _appointments)
            {
                if (appointment.Id.Equals(id))
                {
                    return appointment;
                }
            }
            return null;
        }

        public void Create(Appointment newAppointment)
        {
            _appointments.Add(newAppointment);
            Write();
        }

        public void Edit(Appointment editAppointment)
        {
            foreach (Appointment appointment in _appointments)
            {
                if (editAppointment.Id.Equals(appointment.Id))
                {
                    appointment.Date = editAppointment.Date;
                    appointment.Duration = editAppointment.Duration;
                }
            }
            Write();
        }

        public void Delete(int id)
        {
            for (int i = _appointments.Count - 1; i >= 0; i--)
            {
                if (_appointments[i].Id.Equals(id))
                {
                    _appointments.Remove(_appointments[i]);
                }
            }
            Write();
        }

        public void Write()
        {
            _serializer.Write(_appointments);
        }
   }
}