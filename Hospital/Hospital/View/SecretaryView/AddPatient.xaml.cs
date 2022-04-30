using Hospital.Model;
using System;
using System.Windows;
using Hospital.Controller;
using System.Windows.Controls;

namespace Hospital.View.SecretaryView
{
    /// <summary>
    /// Interaction logic for AddPatient.xaml
    /// </summary>


    public partial class AddPatient : Page
    {
        private readonly SecretaryWindow _secretaryWindow;
        private readonly PatientController _patientController;
        public AddPatient(SecretaryWindow secretaryWindow, PatientController patientController)
        {

            InitializeComponent();
            _secretaryWindow = secretaryWindow;
            _patientController = patientController;
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
                MedicalRecord = new MedicalRecord
                {
                    ChronicalDiseases = chronicalDiseaseText.Text
                },
                Address = new Address()
                {
                City = new City()
                {
                Country = new Country()
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
            _patientController.Create(newUser);
            _secretaryWindow.BackToSecretaryWindow();
        }

        private void CancelPatientOnClick(Object sender, RoutedEventArgs e)
        {
            _secretaryWindow.BackToSecretaryWindow();
        }

    }
}
