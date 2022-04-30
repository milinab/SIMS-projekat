using Hospital.Model;
using System;
using System.Windows;
using Hospital.Controller;
using System.Windows.Controls;

namespace Hospital.View.SecretaryView
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class EditPatient : Page
    {
        private int _id;
        private readonly SecretaryWindow _secretaryWindow;
        private readonly PatientController _patientController;
        public EditPatient(Patient patient,SecretaryWindow secretaryWindow, PatientController patientController)
        {
            
            InitializeComponent();

            _patientController = patientController;
            _secretaryWindow = secretaryWindow;
            this.nameText.Text = patient.Name;
            this.lastNameText.Text = patient.LastName;
            this.usernameText.Text = patient.Username;
            this.passwordText.Text = patient.Password;
            this.genderText.Text = patient.Gender;
            this.idNumberText.Text = patient.IdNumber;
            this.phoneText.Text = patient.Phone;
            this.emailText.Text = patient.Email;
            this.datePicker.SelectedDate = patient.DateOfBirth;
            this.healthInsuranceIdText.Text = patient.HealthInsuranceId;
            this.bloodTypeText.Text = patient.BloodType;
            _id = patient.Id;

        }
        private void CancelPatientOnClick(Object sender, RoutedEventArgs e)
        {
            _secretaryWindow.BackToSecretaryWindow();
        }

        private void EditPatientOnClick(Object sender, RoutedEventArgs e)
        {

            Patient NewPatient = new Patient
            {
                Id = _id,
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
            _patientController.Edit(NewPatient);
            _secretaryWindow.BackToSecretaryWindow();
        }
    }
}
