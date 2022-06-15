using System.Collections.ObjectModel;
using Hospital.Model;

namespace Hospital.View.DoctorView.ViewModel
{
    public class PatientsViewModel : ViewModelBase
    {
        public ObservableCollection<PatientViewModel> Patients { get; set; }

        public PatientsViewModel()
        {
            Patients = new ObservableCollection<PatientViewModel>();
            Patients.Add(new PatientViewModel(new Patient
                {
                    Name = "Pero",
                    LastName = "Peric",
                    HealthInsuranceId = "123456",
                    Gender = "Male",
                    BloodType = "O+",
                    Phone = "0615125122"
                }
            ));
            Patients.Add(new PatientViewModel(new Patient
                {
                    Name = "Milica",
                    LastName = "Milic",
                    HealthInsuranceId = "123456",
                    Gender = "Female",
                    BloodType = "AB+",
                    Phone = "0641665152"
                }
            ));
            Patients.Add(new PatientViewModel(new Patient
                {
                    Name = "Stefan",
                    LastName = "Stefanovic",
                    HealthInsuranceId = "123456",
                    Gender = "Male",
                    BloodType = "B-",
                    Phone = "0661512512"
                }
            ));
        }
    }
}