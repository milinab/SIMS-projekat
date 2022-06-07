using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public ObservableCollection<Appointment> Read()
        {
            return _service.Read();
        }

        public ObservableCollection<Appointment> ReadPastAppointments()
        {
            return _service.ReadPastAppointments();
        }
        

        public ObservableCollection<Appointment> ReadByDoctorId(int doctorId)
        {
            return _service.ReadByDoctorId(doctorId);
        }
        public ObservableCollection<Appointment> ReadByDateAndNotDoctor(int doctorId, DateTime date)
        {
            return _service.ReadByDateAndNotDoctor(doctorId, date);
        }

        public ObservableCollection<Appointment> ReadFutureAppointments(int patientId)
        {
            return _service.ReadFutureAppointments(patientId);
        }

        public ObservableCollection<Appointment> FindAvailableAppointments(Doctor selectedDoctor, DateTime _date, string DoctorName, ObservableCollection<Appointment> DoctorsAppointments,
            List<TimeSpan> hospitalWorkingHours, List<TimeSpan> hospitalWorkingHoursListForCalculation, DateTime date)
        {
            return _service.FindAvailabeAppointments(selectedDoctor, _date, DoctorName, DoctorsAppointments, hospitalWorkingHours, hospitalWorkingHoursListForCalculation, date);
        }
    }
}