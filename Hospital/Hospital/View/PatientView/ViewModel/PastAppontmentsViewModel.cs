using Hospital.Model;
using Hospital.View.PatientView.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Hospital.View.PatientView.ViewModel
{
    internal class PastAppointmentsViewModel : ViewModelPatient
    {

        private ObservableCollection<Appointment> _pastAppointments;
        private Patient patient;

        public Appointment SelectedAppointment { get; set; }

        public ObservableCollection<Appointment> PastAppointments
        {
            get { return _pastAppointments; }
            set { _pastAppointments = value; OnPropertyChanged("pastAppointments"); }
        }
        public CommandPatient FillOutSurvayCommand { get; set; }
        public CommandPatient ViewInfoCommand { get; set; }

        public PastAppointmentsViewModel()
        {
            App app = Application.Current as App;
            patient = app._patientController.ReadById(LogIn.LoggedUser.Id);

            _pastAppointments = new ObservableCollection<Appointment>();            //PROVERITI OVO DA NISAM ZZABRLJALA ZBOG LIST I OBS COL

            List<Appointment> pastAppointments = app._appointmentController.ReadPastAppointments(patient.Id);
            foreach (Appointment appointment in pastAppointments)
            {
                _pastAppointments.Add(appointment);
            }

            FillOutSurvayCommand = new CommandPatient(Execute_FillOutSurvayCommand, CanExecute_FillOutSurvayCommand);
            ViewInfoCommand = new CommandPatient(Execute_ViewInfoCommand, CanExecute_ViewInfoCommand);

        }

        public void Execute_FillOutSurvayCommand(object obj)
        {
            Page page = new SurveysForDoctor(PatientWindow.getInstance(), SelectedAppointment);
            PatientWindow.getInstance().frame.Navigate(page);
        }

        public bool CanExecute_FillOutSurvayCommand(object obj)
        {
            return true;
        }

        public void Execute_ViewInfoCommand(object obj)
        {

            Page page = new AppointmentInfo(PatientWindow.getInstance(), SelectedAppointment);
            PatientWindow.getInstance().frame.Navigate(page);

        }

        public bool CanExecute_ViewInfoCommand(object obj)
        {
            return true;
        }

    }
}
