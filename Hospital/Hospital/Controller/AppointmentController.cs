using System;
using System.Collections.Generic;
using Hospital.Model;
using Hospital.Service;

namespace Hospital.Controller
{
    public class AppointmentController
    {
        private readonly AppointmentService _service;

        public AppointmentController(AppointmentService service)
        {
            _service = service;
        }

        public Appointment ReadById(int id)
        {
            return _service.ReadById(id);
        }

        public void Create(Appointment newAppointment)
        {

            _service.Create(newAppointment);
        }

        public void Edit(Appointment editAppointment)
        {
            _service.Edit(editAppointment);
        }

        public void Delete(int id)
        {
            _service.Delete(id);
        }

        public List<Appointment> Read()
        {
            return _service.Read();
        }

        public List<Appointment> ReadPastAppointments(int patientId)
        {
            return _service.ReadPastAppointments(patientId);
        }

        public List<Appointment> ReadByDoctorId(int doctorId)
        {
            return _service.ReadByDoctorId(doctorId);
        }
        public List<Appointment> ReadByDateAndNotDoctor(int doctorId, DateTime date)
        {
            return _service.ReadByDateAndNotDoctor(doctorId, date);
        }

        public List<Appointment> ReadFutureAppointments(int patientId)
        {
            return _service.ReadFutureAppointments(patientId);
        }

        public List<Appointment> ReadAllAppointments(int patientId)
        {
            return _service.ReadAllAppointments(patientId);
        }

        public List<Appointment> FindAvailableAppointments(Doctor selectedDoctor, DateTime _date, List<Appointment> DoctorsAppointments,
            List<TimeSpan> hospitalWorkingHours, List<TimeSpan> hospitalWorkingHoursListForCalculation, DateTime date)
        {
            return _service.FindAvailableAppointments(selectedDoctor, _date, DoctorsAppointments, hospitalWorkingHours, hospitalWorkingHoursListForCalculation, date);
        }
    }
}