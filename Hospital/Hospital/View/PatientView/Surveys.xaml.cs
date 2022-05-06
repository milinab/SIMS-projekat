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
    /// Interaction logic for Surveys.xaml
    /// </summary>
    /// 
   
    public partial class Surveys : Page
    {

        private App app;
        private readonly object _content;
        private readonly PatientWindow _patientWindow;
        public Surveys(PatientWindow patientWindow)
        {
            InitializeComponent();
            app = Application.Current as App;
            _content = Content;
            this.DataContext = this;
            _patientWindow = patientWindow;
        }

        private void Surveys_Click(object sender, RoutedEventArgs e)
        {
            Content = _content;
        }

        private void FillTheSurvey(object sender, RoutedEventArgs e)
        {

        }

        private void MyAppointments_Click(object sender, RoutedEventArgs e)
        {
            _patientWindow.BackToPatientWindow();
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
