using AutoMapper;
using Hospital.Model;
using Hospital.View.PatientView.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace Hospital.View.PatientView.ViewModel
{
    internal class MyTherapyViewModel : ViewModelPatient
    {
        private Patient patient;

        private ObservableCollection<TherapyShowViewModel> _therapies;
        public IEnumerable<TherapyShowViewModel> Therapies => _therapies;
        public CommandPatient ReportCommand { get; set; }

        public MyTherapyViewModel()
        {
            App app = Application.Current as App;
            patient = app._patientController.ReadById(LogIn.LoggedUser.Id);

            SetTherapies(app);

            ReportCommand = new CommandPatient(Execute_ReportCommand, CanExecute_ReportCommand);

        }

        private void SetTherapies(App app)
        {
            if (app?._therapyController == null) return;

            _therapies = new ObservableCollection<TherapyShowViewModel>();
            foreach (var therapy in app._therapyController.ReadBypatientId(patient.Id))
            {
                var config = new MapperConfiguration(
                    cfg => cfg.CreateMap<Therapy, TherapyShowViewModel>().ConstructUsing(
                        x => new TherapyShowViewModel(therapy)));
                _therapies.Add(new Mapper(config).Map<TherapyShowViewModel>(therapy));
            }
        }

        public void Execute_ReportCommand(object obj)
        {
            TherapyReport therapyReport = new TherapyReport();
            therapyReport.GenerateReport();
            PopupNotification.SendPopupNotification("Successful!", "You succesfully downloaded PDF therapy report to Your desktop.");
        }

        public bool CanExecute_ReportCommand(object obj)
        {
            return true;
        }

    }
}
