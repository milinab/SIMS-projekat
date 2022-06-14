using Hospital.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Hospital.View.PatientView
{
    /// <summary>
    /// Interaction logic for SurveyGraph.xaml
    /// </summary>
    public partial class SurveyGraph : Page
    {
        private App app;
        private readonly object _content;
        private readonly PatientWindow _patientWindow;
        public Patient patient;
        public SurveyGraph(PatientWindow patientWindow)
        {
            InitializeComponent();
            app = Application.Current as App;
            _content = Content;
            this.DataContext = this;
            _patientWindow = patientWindow;
            patient = app._patientController.ReadById(LogIn.LoggedUser.Id);
            List<HospitalSurveyResponse> hospitalSurveyResponsesList = app._hospitalSurveyResponseController.Read();
            ObservableCollection<HospitalSurveyResponse> hospitalSurveyResponses = new ObservableCollection<HospitalSurveyResponse>(hospitalSurveyResponsesList);

            int grade1 = 0;
            int grade2 = 0;
            int grade3 = 0;
            int grade4 = 0;
            int grade5 = 0;
            
            double avg;
            double sum = 0;
            foreach (HospitalSurveyResponse hospitalSurveyResponseItem in hospitalSurveyResponses)
            {
                hospitalSurveyInfo.Series[0].Points.Add(hospitalSurveyResponseItem.Grade).AxisLabel = "";

                if (hospitalSurveyResponseItem.Grade == 1)
                    grade1++;
                if (hospitalSurveyResponseItem.Grade == 2)
                    grade2++;
                if (hospitalSurveyResponseItem.Grade == 3)
                    grade3++;
                if (hospitalSurveyResponseItem.Grade == 4)
                    grade4++;
                if (hospitalSurveyResponseItem.Grade == 5)
                    grade5++;
                sum += hospitalSurveyResponseItem.Grade;
            }
            avg = sum / hospitalSurveyResponsesList.Count;

            this.oneHospital.Text = grade1.ToString();
            this.twoHospital.Text = grade2.ToString();
            this.threeHospital.Text = grade3.ToString();
            this.fourHospital.Text = grade4.ToString();
            this.fiveHospital.Text = grade5.ToString();
            this.averageHospital.Text = avg.ToString("n2");

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
