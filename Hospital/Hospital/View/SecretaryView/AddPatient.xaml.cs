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
        private App _app;
        private readonly SecretaryWindow _secretaryWindow;
        public AddPatient(SecretaryWindow secretaryWindow)
        {
            _app = Application.Current as App;
            InitializeComponent();
            _secretaryWindow = secretaryWindow;
        }

        private void AddPatientOnClick(object sender, RoutedEventArgs e)
        {
            Country tempCountry = new Country(countryText.Text);
            _app._countryController.Create(tempCountry);
            City tempCity = new City(cityText.Text, zipText.Text, tempCountry);
            _app._cityController.Create(tempCity);
            Address tempAddress = new Address(streetText.Text, numberText.Text, tempCity);
            _app._addressController.Create(tempAddress);
            User user = new User(nameText.Text, lastNameText.Text, idNumberText.Text, usernameText.Text,
                passwordText.Text, tempAddress, phoneText.Text, emailText.Text, "patient", 
                (DateTime)datePicker.SelectedDate);
            _app._userController.Create(user);
            MedicalRecord record = new MedicalRecord(chronicalDiseaseText.Text);
            _app._medicalRecordController.Create(record);
            Patient patient = new Patient(user, genderText.Text, bloodTypeText.Text, healthInsuranceIdText.Text, record);
            _app._patientController.Create(patient);
            _secretaryWindow.BackToSecretaryWindow();
        }

        private void CancelPatientOnClick(Object sender, RoutedEventArgs e)
        {
            _secretaryWindow.BackToSecretaryWindow();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            _secretaryWindow.BackToSecretaryWindow();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            AppointmentPage appointmentPage = new AppointmentPage(_secretaryWindow);
            Content = appointmentPage;
        }

        private void SignOut_Click(object sender, RoutedEventArgs e)
        {
            LogIn logIn = new LogIn();
            logIn.Show();
            _secretaryWindow.Close();
        }
    }
}
