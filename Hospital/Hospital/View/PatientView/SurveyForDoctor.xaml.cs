﻿using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
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
            initializeData();
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

        private void initializeData() {

            ObservableCollection<Question> questions = app._questionController.Read();


            for (int i = 0; i<questions.Count; i++) {
               QuestionAndRatingStarsName qrs = new QuestionAndRatingStarsName();
                if(questions[i].SurveyId == 2) { 
                    qrs.QuestionText = questions[i].QuestionText;
                    questionAndRatingStarsNames.Add(qrs);
                }
            }
            icTodoList.ItemsSource = questionAndRatingStarsNames;            
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
            Page medicalRecordPage = new MedicalRecord(_patientWindow);
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

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Page pastAppointmentsPage = new PastAppointments(_patientWindow);
            this.frame.Navigate(pastAppointmentsPage);
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

            DoctorSurveyResponse dsr = new DoctorSurveyResponse();
            //ovde treba da izvucem survay na osnovu Id ankete na koju sam kliknula i da nju prosledim umesto da pravim novu
            Survey s = new Survey();
            s.Id = 2;
            dsr.HS = s;
            dsr.UserId = _patientWindow.patient.Id; // takodje i ovde treba da setujem aktivnog pacijenta
            dsr.Date = DateTime.Now;
            dsr.DoctorId = this._appointment.DoctorId;
            dsr.Grade = avrgGrade; // ovo mozda da promenim u double?
            app._doctorSurveyResponseController.Create(dsr);
            _patientWindow.BackToPatientWindow();

        }
    }
}
