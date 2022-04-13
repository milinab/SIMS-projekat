using Hospital.Model;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace Hospital.Secretary
{
    /// <summary>
    /// Interaction logic for AddPatient.xaml
    /// </summary>


    public partial class AddPatient : Window
    {
        private PatientHandler PatientHandler;
        private Patient Patient;
        public AddPatient(SecretaryWindow secretaryWindow, PatientHandler patientHandler)
        {
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            PatientHandler = patientHandler;
        }

        private void AddPatientOnClick(object sender, RoutedEventArgs e)
        {
            
            Patient newUser = new Patient
            { 
                
                Name = nameText.Text,
                LastName = lastNameText.Text,
                Username = usernameText.Text,
                Password = passwordText.Text,
                Gender = genderText.Text,
                IdNumber = idNumberText.Text,
                Phone = phoneText.Text,
                Email = emailText.Text,
                DateOfBirth = (DateTime)datePicker.SelectedDate,
                AccountType = "Patient",
                HealthInsuranceId = healthInsuranceIdText.Text,
                BloodType = bloodTypeText.Text,
                medicalRecord = new MedicalRecord
                {
                    ChronicalDiseases = chronicalDiseaseText.Text
                },
                Address = new Address()
                {
                city = new City()
                {
                country = new Country()
                {
                Name = countryText.Text
                },
                Name = cityText.Text,
                Zip = zipText.Text
                },
                Street = streetText.Text,
                Number = numberText.Text
                }
               
                

            };
            PatientHandler.Create(newUser);
            DialogResult = true;
        }

        private void CancelPatientOnClick(Object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

    }
}
