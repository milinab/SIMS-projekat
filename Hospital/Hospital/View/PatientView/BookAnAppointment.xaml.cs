using System;
using System.Windows;
using System.Windows.Controls;
using Hospital.Model;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace Hospital.View.PatientView
{
    /// <summary>
    /// Interaction logic for BookAnAppointment.xaml
    /// </summary>
    public partial class BookAnAppointment : Page
    {
        private App app;
        private readonly object _content;
        private readonly PatientWindow _patientWindow;
        public Patient patient;

        public ObservableCollection<Doctor> Doctors
        {
            get;
            set;
        }

        public BookAnAppointment(PatientWindow patientWindow)
        {
            InitializeComponent();
            app = Application.Current as App;
            _content = Content;
            this.DataContext = this;
            dataGridAppointments.ItemsSource = patientWindow.dataGridAppointments.ItemsSource;
            patient = app._patientController.ReadById(LogIn.LoggedUser.Id);
            _patientWindow = patientWindow;

            List<Doctor> doctorList = app._doctorController.Read();
            ObservableCollection<Doctor> Doctors = new ObservableCollection<Doctor>(doctorList);

            doctorsComboBox.ItemsSource = Doctors;
            myCalendar.DisplayDateStart = DateTime.Now.AddDays(1);
        }

        private bool Validate()
        {
         
            if(DoctorPriority.IsChecked == false && DatePriority.IsChecked == false)
            {
                PopupNotification.SendPopupNotification("Warning", "You need to select a priority.");
                return false;
            }
            
            if(doctorsComboBox.SelectedItem==null)
            {
                PopupNotification.SendPopupNotification("Warning", "You need to select a doctor");
                return false;
            }

            if(myCalendar.SelectedDate.HasValue==false)
            {
                PopupNotification.SendPopupNotification("Warning", "You need to select a date");
                return false;
            }
            return true;
        }

        private void AddAppointment_Click(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {
                int DoctorId = Int32.Parse(((Model.User)doctorsComboBox.SelectedItem).Id.ToString());

                DateTime date = myCalendar.SelectedDate.Value;

                if (DoctorPriority.IsChecked == true)
                {
                    Page doctorPriority = new DoctorPriorityDateAvailable(DoctorId, date, this, _patientWindow);
                    this.frame.Navigate(doctorPriority);
                }
                if (DatePriority.IsChecked == true)
                {
                    Page datePriority = new DatePriority(DoctorId, date, this, _patientWindow);
                    this.frame.Navigate(datePriority);
                }
            }            
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
            User user = app._userController.ReadById(patient.Id);
            Address address = app._addressController.ReadById(user.Address.Id);
            City city = app._cityController.ReadById(user.Address.CityId);
            Country country = app._countryController.ReadById(1); //country nije postavljen u address modelu
            Model.MedicalRecord medicalRecord = app._medicalRecordController.ReadById(patient.MedicalRecordId);
            List<Allergen> allergenList = app._allergenController.ReadByIds(medicalRecord.AllergenIds);
            ObservableCollection<Allergen> allergens = new ObservableCollection<Allergen>(allergenList);

            Page medicalRecordPage = new MedicalRecord(_patientWindow, user, patient, address, city, country, medicalRecord, allergens);
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

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            _patientWindow.BackToPatientWindow();
        }

        public void BackToBookAnAppointmentWindow()
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
