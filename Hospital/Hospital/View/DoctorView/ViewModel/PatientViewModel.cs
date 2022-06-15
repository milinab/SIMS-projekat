using System;
using Hospital.Model;

namespace Hospital.View.DoctorView.ViewModel
{
    public class PatientViewModel : ViewModelBase
    {
        private readonly Patient _patient;
        private readonly string _age;

        public string Patient => _patient.Name + " " + _patient.LastName;
        public string Age => _age;
        public string HealthInsuranceId => _patient.HealthInsuranceId;
        public string Gender => _patient.Gender;
        public string BloodType => _patient.BloodType;
        public string Phone => _patient.Phone;

        public PatientViewModel(Patient patient)
        {
            _patient = patient;
            Random r = new Random();
            _age = r.Next(20, 80).ToString(); 
        }
    }
}