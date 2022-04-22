using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Hospital.Model
{
    public class AppointmentService
    {
        public readonly AppointmentRepository _appointmentRepository;

        private readonly ObservableCollection<Appointment> _appointments;

        public AppointmentService(AppointmentRepository appointmentRepository)
        {
            _appointments = new ObservableCollection<Appointment>();
            _appointmentRepository = appointmentRepository;
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
        }

        public void Edit(Appointment newAppointment)
        {
            DateTime _date = newAppointment.Date;
            TimeSpan _duration = newAppointment.Duration;
            Console.WriteLine(_duration);
            foreach (Appointment appointment in _appointments)
            {
                if (newAppointment.Id.Equals(appointment.Id))
                {
                    appointment.Date = _date;
                    appointment.Duration = _duration;
                }
            }
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
        }

        public ObservableCollection<Appointment> ReadAll()
        {
            return _appointments;
        }
    }
}