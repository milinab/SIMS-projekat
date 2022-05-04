using System;
using System.Collections.ObjectModel;
using System.Linq;
using Hospital.Model;
using Hospital.Repository;
using Xceed.Wpf.Toolkit;

namespace Hospital.Service
{
    public class AppointmentService
    {
        private int _id;
        private readonly AppointmentRepository _repository;

        public AppointmentService(AppointmentRepository appointmentRepository)
        {
            _repository = appointmentRepository;
            ObservableCollection<Appointment> appointments = Read();
            if (appointments.Count == 0)
            {
                _id = 0;
            }
            else
            {
                _id = appointments.Last().Id;
            }
        }

        public Appointment ReadById(int id)
        {
            return _repository.ReadById(id);
        }

        public void Create(Appointment newAppointment)
        {
            var appointments = Read();
            foreach (var appointment in appointments)
            {
                var startTime = appointment.Date;
                var tempTime = startTime;
                var endTime = tempTime.AddMinutes(appointment.Duration.Hours * 60 + appointment.Duration.Minutes);

                var appointmentStarTime = newAppointment.Date;
                var appointmentTempTime = appointmentStarTime;
                var appointmentEndTime = appointmentTempTime.AddMinutes(newAppointment.Duration.Hours * 60 +
                                                                        newAppointment.Duration.Minutes);
                
                if (DateTime.Compare(newAppointment.Date, startTime) > 0 && DateTime.Compare(newAppointment.Date, endTime) < 0)
                {
                    MessageBox.Show("There is already an appointment at the selected time!");
                    return;
                }

                if (DateTime.Compare(appointmentEndTime, appointment.Date) > 0 && DateTime.Compare(appointmentEndTime, endTime) < 0)
                {
                    MessageBox.Show("There is already an appointment at the selected time!");
                    return;
                }
            }
            newAppointment.Id = GenerateId();
            _repository.Create(newAppointment);
        }

        public void Edit(Appointment editAppointment)
        {
            _repository.Edit(editAppointment);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public ObservableCollection<Appointment> Read()
        {
            return _repository.Read();
        }
        private int GenerateId()
        {
            return ++_id;
        }
    }
}