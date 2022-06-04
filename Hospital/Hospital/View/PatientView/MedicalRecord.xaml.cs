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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hospital.View.PatientView
{
    /// <summary>
    /// Interaction logic for MedicalRecord.xaml
    /// </summary>
    public partial class MedicalRecord : Page
    {
        private App app;
        private readonly object _content;
        private readonly PatientWindow _patientWindow;

        public MedicalRecord(PatientWindow patientWindow, User user, Patient patient, Address address, City city, Country country, Model.MedicalRecord medicalRecord, Allergen allergen)
        {
            InitializeComponent();
            app = Application.Current as App;
            _content = Content;
            this.DataContext = this;
            _patientWindow = patientWindow;

            this.firstName.Text = user.Name;
            this.lastName.Text = user.LastName;
            this.dateOfBirth.Text = user.DateOfBirth.ToString("d.M.yyyy");
            this.jmbg.Text = user.IdNumber;
            this.email.Text = user.Email;
            this.phoneNumber.Text = user.Phone;
            this.gender.Text = patient.Gender;
            this.streetName.Text = address.Street;
            this.streetNumber.Text = address.Number;
            this.city.Text = city.Name;
            this.postalCode.Text = city.Zip;
            this.healthInsuranceID.Text = patient.HealthInsuranceId;
            this.bloodType.Text = patient.BloodType;
            this.country.Text = country.Name;
            this.chronicalDisease.Text = medicalRecord.ChronicalDiseases;
            this.allergies.Text = medicalRecord.AllergenIds.ToString();

        }

        private void HomePage_Click(object sender, RoutedEventArgs e)
        {
            Page homePage = new HomePage(_patientWindow);
            this.frame.Navigate(homePage);
        }

        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            Page profilePage = new Profile(_patientWindow);
            this.frame.Navigate(profilePage);
        }

        private void MedicalRecord_Click(object sender, RoutedEventArgs e)
        {
            User user = app._userController.ReadById(1);
            Patient patient = app._patientController.ReadById(1);
            Address address = app._addressController.ReadById(1);
            City city = app._cityController.ReadById(1);
            Country country = app._countryController.ReadById(1);
            Model.MedicalRecord medicalRecord = app._medicalRecordController.ReadById(1);
            Allergen allergen = app._allergenController.ReadById(1);
            Page medicalRecordPage = new MedicalRecord(_patientWindow, user, patient, address, city, country, medicalRecord, allergen);
            this.frame.Navigate(medicalRecordPage);
        }

        private void MyAppointments_Click(object sender, RoutedEventArgs e)
        {
            _patientWindow.BackToPatientWindow();
        }
        private void MyTherapy_Click(object sender, RoutedEventArgs e)
        {
            Page myTherapyPage = new MyTherapy(_patientWindow);
            this.frame.Navigate(myTherapyPage);
        }

        private void Calendar_Click(object sender, RoutedEventArgs e)
        {
            Page calendarPage = new Calendar(_patientWindow);
            this.frame.Navigate(calendarPage);
        }
        private void Notes_Click(object sender, RoutedEventArgs e)
        {
            Page notesPage = new Notes(_patientWindow);
            this.frame.Navigate(notesPage);
        }

        private void Surveys_Click(object sender, RoutedEventArgs e)
        {
            Page hospitalSurveyPage = new Surveys(_patientWindow);
            this.frame.Navigate(hospitalSurveyPage);
        }
        private void Notification_Click(object sender, RoutedEventArgs e)
        {
            Page notificationPage = new Notification(_patientWindow);
            this.frame.Navigate(notificationPage);
        }

        public void BackToPatientWindow()
        {
            Content = _content;
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            LogIn logIn = new LogIn();
            logIn.Show();
            _patientWindow.Close();
        }
    }
}
