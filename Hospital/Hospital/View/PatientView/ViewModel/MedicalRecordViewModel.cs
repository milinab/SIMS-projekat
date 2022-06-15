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
    internal class MedicalRecordViewModel : ViewModelPatient
    {
        private NavigationService _navigationService;
        private string firstName;
        private string lastName;
        public string date;
        public string jmbg;
        public string email;
        public string phoneNumber;
        public string gender;
        public string streetName;
        public string streetNumber;
        public string city;
        public string postalCode;
        public string healthInsuranceID;
        public string bloodType;
        public string country;
        public string chronicalDisease;
        public string allergies;


        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        public string Date
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
                OnPropertyChanged(nameof(Date));
            }
        }

        public string Jmbg
        {
            get
            {
                return jmbg;
            }
            set
            {
                jmbg = value;
                OnPropertyChanged(nameof(Jmbg));
            }
        }

        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }
            set
            {
                phoneNumber = value;
                OnPropertyChanged(nameof(PhoneNumber));
            }
        }

        public string Gender
        {
            get
            {
                return gender;
            }
            set
            {
                gender = value;
                OnPropertyChanged(nameof(Gender));
            }
        }

        public string StreetName
        {
            get
            {
                return streetName;
            }
            set
            {
                streetName = value;
                OnPropertyChanged(nameof(StreetName));
            }
        }

        public string StreetNumber
        {
            get
            {
                return streetNumber;
            }
            set
            {
                streetNumber = value;
                OnPropertyChanged(nameof(StreetNumber));
            }
        }

        public string City
        {
            get
            {
                return city;
            }
            set
            {
                city = value;
                OnPropertyChanged(nameof(City));
            }
        }

        public string PostalCode
        {
            get
            {
                return postalCode;
            }
            set
            {
                postalCode = value;
                OnPropertyChanged(nameof(PostalCode));
            }
        }

        public string HealthInsuranceID
        {
            get
            {
                return healthInsuranceID;
            }
            set
            {
                healthInsuranceID = value;
                OnPropertyChanged(nameof(HealthInsuranceID));
            }
        }

        public string BloodType
        {
            get
            {
                return bloodType;
            }
            set
            {
                bloodType = value;
                OnPropertyChanged(nameof(BloodType));
            }
        }

        public string Country
        {
            get
            {
                return country;
            }
            set
            {
                country = value;
                OnPropertyChanged(nameof(Country));
            }
        }

        public string ChronicalDisease
        {
            get
            {
                return chronicalDisease;
            }
            set
            {
                chronicalDisease = value;
                OnPropertyChanged(nameof(ChronicalDisease));
            }
        }

        public string Allergies
        {
            get
            {
                return allergies;
            }
            set
            {
                allergies = value;
                OnPropertyChanged(nameof(Allergies));
            }
        }

        public CommandPatient PastAppointmentsCommand { get; set; }
        public CommandPatient CancelCommand { get; set; }



        public MedicalRecordViewModel(NavigationService navigationService, User user, Address address, City city, Country country, Model.MedicalRecord medicalRecord, ObservableCollection<Allergen> allergens)
        {
            this._navigationService = navigationService;
            App app = Application.Current as App;
            Patient patient = app._patientController.ReadById(LogIn.LoggedUser.Id);

            FirstName = user.Name;
            LastName = user.LastName;
            Date = user.DateOfBirth.ToString("d.M.yyyy");
            Jmbg = user.IdNumber;
            Email = user.Email;
            PhoneNumber = user.Phone;
            Gender = patient.Gender;
            StreetName = address.Street;
            StreetNumber = address.Number;
            City = city.Name;
            PostalCode = city.Zip;
            HealthInsuranceID = patient.HealthInsuranceId;
            BloodType = patient.BloodType;
            Country = country.Name;
            ChronicalDisease = medicalRecord.ChronicalDiseases;
            Allergies = ShowAllergens(allergens);

            PastAppointmentsCommand = new CommandPatient(Execute_PastAppointmentsCommand, CanExecute_PastAppointmentsCommand);
            CancelCommand = new CommandPatient(Execute_CancelCommand, CanExecute_CancelCommand);
        }

        private string ShowAllergens(ObservableCollection<Allergen> allergens)
        {
            var patientAllergens = new StringBuilder();
            foreach (Allergen a in allergens)
            {
                if (allergens.Count == 1)
                {
                    patientAllergens.AppendLine(a.Name).ToString();
                }
                else
                {
                    patientAllergens.AppendLine(a.Name).ToString();
                }
            }
            return patientAllergens.ToString();
        }

        public void Execute_PastAppointmentsCommand(object obj)
        {
            _navigationService.Navigate(PatientWindow.getInstance().frame.Content = new PastAppointments());
        }

        public bool CanExecute_PastAppointmentsCommand(object obj)
        {
            return true;
        }

        public void Execute_CancelCommand(object obj)
        {
            _navigationService.Navigate(PatientWindow.getInstance().frame.Content = new StartScreenPagexaml(PatientWindow.getInstance()));

        }

        public bool CanExecute_CancelCommand(object obj)
        {
            return true;

        }
    }
}
