using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Hospital.Model
{
    public class AppointmentService
    {
        private int _id;
        public readonly AppointmentRepository _appointmentRepository;

        private readonly ObservableCollection<Appointment> _appointments;

        public AppointmentService(AppointmentRepository appointmentRepository)
        {
            _appointments = new ObservableCollection<Appointment>();
            if (_appointments.Count == 0)
            {
                _id = 0;
            }
            else
            {
                _id = _appointments.Last().Id;
            }
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
            newAppointment.Id = GenerateID();
            _appointments.Add(newAppointment);
            Console.WriteLine(_appointments.Last().Id);
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
        private int GenerateID()
        {
            return ++_id;
        }
    }
}