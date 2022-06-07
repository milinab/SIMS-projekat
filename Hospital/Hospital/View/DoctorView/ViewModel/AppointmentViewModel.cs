using System;
using Hospital.Model;

namespace Hospital.View.DoctorView.ViewModel
{
    public class AppointmentViewModel : ViewModelBase
    {
        private readonly Appointment _appointment;
        public string AppointmentSubject => _appointment.Patient?.Name + " " + 
                                            _appointment.Patient?.LastName + "\n" + 
                                            "Room: " + _appointment.Room?.Name;

        public DateTime Date => _appointment.Date;
        
        public DateTime End => Date + _appointment.Duration;

        public AppointmentViewModel()
        {
        }

        public AppointmentViewModel(Appointment appointment)
        {
            _appointment = appointment;
        }
    }
}