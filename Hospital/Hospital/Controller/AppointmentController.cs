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
    }
}