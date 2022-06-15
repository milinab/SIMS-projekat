using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using Hospital.Model;
using Hospital.View.DoctorView.Commands;
using Hospital.View.DoctorView.Commands.AddAppointment;
using Hospital.View.DoctorView.Validation;

namespace Hospital.View.DoctorView.ViewModel
{
    public class AddAppointmentViewModel : BindableBase
    {
        private App _app;
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public string Duration { get; set; }
        private ObservableCollection<string> _rooms;
        public IEnumerable<string> Rooms => _rooms;

        public string Room { get; set; }

        private ObservableCollection<string> _equipment;
        public IEnumerable<string> Equipment => _equipment;

        public Doctor Doctor { get; set; }
        
        public Patient Patient { get; set; }
        
        public ConfirmCommand Confirm { get; }
        public CancelCommand Cancel { get; }

        private string _appointmentValidationText;
        public string AppointmentValidationText
        {
            get => _appointmentValidationText;
            set
            {
                _appointmentValidationText = value;
                OnPropertyChanged("AppointmentValidationText");
            }
        }
        
        public ObservableCollection<AppointmentValidation> AppointmentValidations { get; set; }
        private AppointmentValidation _currentAppointmentValidation = new AppointmentValidation();
        
        public AppointmentValidation CurrentAppointmentValidation
        {
            get => _currentAppointmentValidation;
            set
            {
                _currentAppointmentValidation = value;
                OnPropertyChanged("CurrentAppointment");
            }
        }

        public AddAppointmentViewModel(Patient patient)
        {
            Patient = patient;
            Duration = "PT10M";
            InstantiateProperties();
            AppointmentValidations = new ObservableCollection<AppointmentValidation>();

            Confirm = new ConfirmCommand(this, CurrentAppointmentValidation);
            Cancel = new CancelCommand();
        }

        private void InstantiateProperties()
        {
            _app = Application.Current as App;
            _rooms = new ObservableCollection<string>();
            foreach (var room in _app._roomController.Read())
            {
                _rooms.Add(room.Name);
            }

            _equipment = new ObservableCollection<string>();
            foreach (var eq in _app._equipmentController.Read())
            {
                _equipment.Add(eq.Name);
            }
            
            Doctor = _app._doctorController.ReadById(LogIn.LoggedUser.Id);
        }
    }
}