using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Hospital.View.PatientView
{
    /// <summary>
    /// Interaction logic for SurveysForDoctor.xaml
    /// </summary>
    /// 
   
    public partial class SurveysForDoctor : Page
    {

        private App app;
        private readonly object _content;
        private readonly PatientWindow _patientWindow;
        private List<int> answers;
        private Appointment _appointment;
        public Patient patient;

        ObservableCollection<QuestionAndRatingStarsName> questionAndRatingStarsNames;

        public SurveysForDoctor(PatientWindow patientWindow, Appointment appointment)
        {
            InitializeComponent();
            app = Application.Current as App;
            _content = Content;
            this.DataContext = this;
            _patientWindow = patientWindow;
            _appointment = appointment;
            this.DataContext = this;
            answers = new List<int>();  
            questionAndRatingStarsNames = new ObservableCollection<QuestionAndRatingStarsName>();
            InitializeData();
            patient = app._patientController.ReadById(LogIn.LoggedUser.Id);
        }

        public class QuestionAndRatingStarsName { 
                
            public string QuestionText {
                get;
                set;
            }
            public String RatingStarName {
                get;
                set;
            }
        }

        private void InitializeData() {

            List<Question> questionList = app._questionController.Read();
            ObservableCollection<Question> questions = new ObservableCollection<Question>(questionList);

            for (int i = 0; i<questions.Count; i++) {
               QuestionAndRatingStarsName qrs = new QuestionAndRatingStarsName();
                if(questions[i].SurveyId == 2) { 
                    qrs.QuestionText = questions[i].QuestionText;
                    questionAndRatingStarsNames.Add(qrs);
                }
            }
            icTodoList.ItemsSource = questionAndRatingStarsNames;            
        }
 
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            PatientWindow.getInstance().frame.Content = new PastAppointments();
        }

        private void SendAnswers_Click(object sender, RoutedEventArgs e)
        {
            answers.Add(this.Pitanje1.Value);
            answers.Add(this.Pitanje2.Value);
            answers.Add(this.Pitanje3.Value);
            answers.Add(this.Pitanje4.Value);
            answers.Add(this.Pitanje5.Value);

            int avrgGrade = answers.Sum() / answers.Count;

            DoctorSurveyResponse dsr = new DoctorSurveyResponse();
            Survey s = new Survey();
            s.Id = 2;
            dsr.HS = s;
            dsr.UserId = _patientWindow.patient.Id; 
            dsr.Date = DateTime.Now;
            dsr.DoctorId = this._appointment.DoctorId;
            dsr.Grade = avrgGrade; 
            app._doctorSurveyResponseController.Create(dsr);
            _patientWindow.BackToPatientWindow();

        }
    }
}
