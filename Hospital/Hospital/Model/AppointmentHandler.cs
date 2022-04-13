using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Hospital.Model
{
    public class AppointmentHandler
    {
        public AppointmentFileHandler appointmentFileHandler;

        private ObservableCollection<Appointment> appointments;

        public AppointmentHandler()
        {
            appointments = new ObservableCollection<Appointment>();
        }

        public Appointment ReadById(int id)
        {
            foreach (Appointment appointment in appointments)
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
            appointments.Add(newAppointment);
        }

        public void Edit(Appointment newAppointment)
        {
            DateTime _date = newAppointment.Date;
            TimeSpan _duration = newAppointment.Duration;
            Console.WriteLine(_duration);
            foreach (Appointment appointment in appointments)
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
            for (int i = appointments.Count - 1; i >= 0; i--)
            {
                if (appointments[i].Id.Equals(id))
                {
                    appointments.Remove(appointments[i]);
                }
            }
        }

        public ObservableCollection<Appointment> ReadAll()
        {
            return appointments;
        }
    }
}