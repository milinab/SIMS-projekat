using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Hospital.Model
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

        public void Edit(Appointment newAppointment)
        {
            _service.Edit(newAppointment);
        }

        public void Delete(int id)
        {
            _service.Delete(id);
        }

        public ObservableCollection<Appointment> ReadAll()
        {
            return _service.ReadAll();
        }
    }
}