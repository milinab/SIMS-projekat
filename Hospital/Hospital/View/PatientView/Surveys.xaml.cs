using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
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
        public Patient patient;

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
            InitializeData();
            patient = app._patientController.ReadById(LogIn.LoggedUser.Id);
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

        private void InitializeData()
        {
            List<Question> questionList = app._questionController.Read();
            ObservableCollection<Question> questions =new ObservableCollection<Question>(questionList);

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
            PatientWindow.getInstance().frame.Navigate(profilePage);
        }
       

        private void SurveyInfo_Click(object sender, RoutedEventArgs e)
        {
            Page surveyInfoPage = new SurveyGraph(_patientWindow);
            PatientWindow.getInstance().frame.Navigate(surveyInfoPage);
        }

        private void SendAnswers_Click(object sender, RoutedEventArgs e)
        {
            answers.Add(this.Pitanje1.Value);
            answers.Add(this.Pitanje2.Value);
            answers.Add(this.Pitanje3.Value);
            answers.Add(this.Pitanje4.Value);
            answers.Add(this.Pitanje5.Value);

            int avrgGrade = answers.Sum() / answers.Count;

            HospitalSurveyResponse hsr = new HospitalSurveyResponse();
            Survey s = new Survey();
            s.Id = 1;
            hsr.HS = s;
            hsr.UserId = patient.Id;
            hsr.Date = DateTime.Now;
            hsr.Grade = avrgGrade;
            app._hospitalSurveyResponseController.Create(hsr);
            _patientWindow.BackToPatientWindow();

        }
    }
}
