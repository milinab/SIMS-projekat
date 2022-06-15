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


        private void Surveys_Click(object sender, RoutedEventArgs e)
        {
            Page hospitalSurveyPage = new Surveys(_patientWindow);
            PatientWindow.getInstance().frame.Navigate(hospitalSurveyPage);
        }
    }
}
