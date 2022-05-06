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
using Hospital.Model;

namespace Hospital.View.PatientView
{
    /// <summary>
    /// Interaction logic for PastAppointments.xaml
    /// </summary>
    public partial class PastAppointments : Page
    {
        private App app;
        private readonly object _content;
        private readonly PatientWindow _patientWindow;
        public PastAppointments(PatientWindow patientWindow)
        {
            InitializeComponent();
            app = Application.Current as App;
            _content = Content;
            this.DataContext = this;
            _patientWindow = patientWindow;
            dataGridPastAppointments.ItemsSource = app._appointmentController.Read();
        }

        private void FillOutSurveyButtonClick(object sender, RoutedEventArgs e)
        {
            Appointment appointment = dataGridPastAppointments.SelectedValue as Appointment;
           // var DoctorSurveyPage = new DoctorSurvey(appointment, this);
           // Content = DoctorSurveyPage;
        }

        private void MyAppointments_Click(object sender, RoutedEventArgs e)
        {
            _patientWindow.BackToPatientWindow();
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            LogIn logIn = new LogIn();
            logIn.Show();
            _patientWindow.Close();
        }
    }
}
