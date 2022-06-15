using Hospital.Model;
using System.Windows;
using System.Collections.ObjectModel;

using System.Windows.Controls;
using System.Collections.Generic;

namespace Hospital.View.PatientView
{
    /// <summary>
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : Page
    {
        private App app;
        private readonly object _content;
        private readonly PatientWindow _patientWindow;
        public Patient patient;
        public Profile(PatientWindow patientWindow)
        {
            InitializeComponent();
            app = Application.Current as App;
            _content = Content;
            this.DataContext = this;
            _patientWindow = patientWindow;
            patient = app._patientController.ReadById(LogIn.LoggedUser.Id);
            this.profileName.Text = patient.Name;
        }
        

        private void MyAppointments_Click(object sender, RoutedEventArgs e)
        {
            PatientWindow.getInstance().frame.Content = new StartScreenPagexaml(_patientWindow);
        }
       
        private void Notes_Click(object sender, RoutedEventArgs e)
        {
            PatientWindow.getInstance().frame.Content = new Notes(_patientWindow);
        }

        private void PastAppointments_Click(object sender, RoutedEventArgs e)
        {
            PatientWindow.getInstance().frame.Content = new PastAppointments();
        }
        private void AccountSettings_Click(object sender, RoutedEventArgs e)
        {
            PatientWindow.getInstance().frame.Content = new AccountSettings(_patientWindow);
        }
        private void AppointmentsGraph_Click(object sender, RoutedEventArgs e)
        {
            PatientWindow.getInstance().frame.Content = new AppointmentsGraph(_patientWindow);
        }

     
    }
}
