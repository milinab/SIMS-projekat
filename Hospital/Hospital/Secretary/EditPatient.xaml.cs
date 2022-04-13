using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Hospital.Secretary
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class EditPatient : Window
    {
        public Patient patient1 { get; set; }
        private PatientHandler PatientHandler;
        public EditPatient(Patient patient, SecretaryWindow secretaryWindow, PatientHandler patientHandler)
        {
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            PatientHandler = patientHandler;


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
            this.chronicalDiseaseText.Text = patient.medicalRecord.ChronicalDiseases;
            this.bloodTypeText.Text = patient.BloodType;
            this.countryText.Text = patient.Address.city.country.Name;
            this.cityText.Text = patient.Address.city.Name;
            this.zipText.Text = patient.Address.city.Zip;
            this.streetText.Text = patient.Address.Street;
            this.numberText.Text = patient.Address.Number;

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
            PatientHandler.Edit(NewPatient);
            DialogResult = true;
        }
    }
}
