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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Hospital.Model;

namespace Hospital.View.PatientView
{
    /// <summary>
    /// Interaction logic for Surveys.xaml
    /// </summary>
    /// 
   
    public partial class Surveys : Page
    {

        private App app;
        private readonly object _content;
        private readonly PatientWindow _patientWindow;
        private List<int> answers;

        ObservableCollection<QuestionAndRatingStarsName> questionAndRatingStarsNames;
        public Surveys(PatientWindow patientWindow)
        {
            InitializeComponent();
            app = Application.Current as App;
            _content = Content;
            this.DataContext = this;
            _patientWindow = patientWindow;
            this.DataContext = this;
            answers = new List<int>();
            questionAndRatingStarsNames = new ObservableCollection<QuestionAndRatingStarsName>();
            initializeData();
        }

        public class QuestionAndRatingStarsName
        {

            public string QuestionText
            {
                get;
                set;
            }
            public String RatingStarName
            {
                get;
                set;
            }

        }

        private void initializeData()
        {

            ObservableCollection<Question> questions = app._questionController.Read();


            for (int i = 0; i < questions.Count; i++)
            {
                QuestionAndRatingStarsName qrs = new QuestionAndRatingStarsName();
                if (questions[i].SurveyId == 1)
                {
                    qrs.QuestionText = questions[i].QuestionText;
                    questionAndRatingStarsNames.Add(qrs);
                }
            }
            icTodoList.ItemsSource = questionAndRatingStarsNames;
        }


        private void Discard_Click(object sender, RoutedEventArgs e)
        {
            Page profilePage = new Profile(_patientWindow);
            this.frame.Navigate(profilePage);
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

        private void SendAnswers_Click(object sender, RoutedEventArgs e)
        {
            answers.Add(this.Pitanje1.Value);
            answers.Add(this.Pitanje2.Value);
            answers.Add(this.Pitanje3.Value);
            answers.Add(this.Pitanje4.Value);
            answers.Add(this.Pitanje5.Value);

            int sum = answers.Sum();
            int avrgGrade = answers.Sum() / answers.Count;

            HospitalSurveyResponse hsr = new HospitalSurveyResponse();
            //ovde treba da izvucem survay na osnovu Id ankete na koju sam kliknula i da nju prosledim umesto da pravim novu
            Survey s = new Survey();
            s.Id = 1;
            hsr.HS = s;
            hsr.UserId = 1; // takodje i ovde treba da setujem aktivnog pacijenta
            hsr.Date = DateTime.Now;
            hsr.Grade = avrgGrade; // ovo mozda da promenim u double?
            app._hospitalSurveyResponseController.Create(hsr);
            _patientWindow.BackToPatientWindow();

        }
    }
}
