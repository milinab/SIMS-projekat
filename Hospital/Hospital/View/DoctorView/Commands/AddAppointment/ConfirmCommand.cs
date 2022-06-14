using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using Hospital.Exceptions;
using Hospital.Model;
using Hospital.View.DoctorView.Validation;
using Hospital.View.DoctorView.ViewModel;

namespace Hospital.View.DoctorView.Commands.AddAppointment
{
    public class ConfirmCommand : CommandBase
    {
        private App _app;
        private AddAppointmentViewModel _addAppointmentViewModel;
        private AppointmentValidation _currentAppointmentValidation;
        public ConfirmCommand(AddAppointmentViewModel addAppointmentViewModel, AppointmentValidation appointmentValidation)
        {
            _app = Application.Current as App;
            _currentAppointmentValidation = appointmentValidation;
            _addAppointmentViewModel = addAppointmentViewModel;
        }
        
        public override void Execute(object parameter)
        {
            try
            {
                _addAppointmentViewModel.AppointmentValidationText = "";
                _currentAppointmentValidation.Validate();
                if (!_currentAppointmentValidation.IsValid) return;
                var date = _addAppointmentViewModel.Date;
                var timeString = _addAppointmentViewModel.Time;
                var time = TimeSpan.ParseExact(timeString, "c", CultureInfo.InvariantCulture);
                date += time;
                var duration = _addAppointmentViewModel.Duration;
                var doctor = _addAppointmentViewModel.Doctor;
                var patient = _addAppointmentViewModel.Patient;
                var roomName = _addAppointmentViewModel.Room;
                var room = new Room();
                foreach (var r in _app._roomController.Read().Where(r => r.Name.Equals(roomName)))
                {
                    room = r;
                }

                Appointment appointment = new Appointment(date, duration, doctor, patient, room);

                _app._appointmentController.Create(appointment);
                MainWindow.MainFrame.GoBack();
            }
            catch (AppointmentException e)
            {
                switch (e.Message)
                {
                    case "AlreadyExists":
                        _addAppointmentViewModel.AppointmentValidationText = "There is already an appointment at the selected time.";
                        break;
                    case "StartDateBeforeEndDate":
                        _addAppointmentViewModel.AppointmentValidationText = "Start date must be before end date.";
                        break;
                }
            }
        }
    }
}