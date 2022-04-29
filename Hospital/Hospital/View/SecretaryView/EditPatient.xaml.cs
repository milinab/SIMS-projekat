using Hospital.Model;
using System;
using System.Windows;
using Hospital.Controller;

namespace Hospital.View.SecretaryView
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class EditPatient : Window
    {
        public Patient patient1 { get; set; }
        private PatientController _patientController;
        public EditPatient(Patient patient, SecretaryWindow secretaryWindow, PatientController patientController)
        {
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            _patientController = patientController;


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

        }
        private void CancelPatientOnClick(Object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void EditPatientOnClick(Object sender, RoutedEventArgs e)
        {

            Patient NewPatient = new Patient
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
            _patientController.Edit(NewPatient);
            DialogResult = true;
        }
    }
}
