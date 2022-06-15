using Hospital.Model;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace Hospital.View.PatientView
{
    /// <summary>
    /// Interaction logic for MyTherapy.xaml
    /// </summary>
    public partial class MyTherapy : Page
    {
        private App app;
        private readonly object _content;
        private readonly PatientWindow _patientWindow;
        public Patient patient;
        public MyTherapy(PatientWindow patientWindow)
        {
            InitializeComponent();
            app = Application.Current as App;
            _content = Content;
            this.DataContext = this;
            _patientWindow = patientWindow;
            patient = app._patientController.ReadById(LogIn.LoggedUser.Id);
            
            TherapyCalendar.ItemsSource = app._therapyController.ReadBypatientId(patient.Id);
        }
       
        private void Report_Click(object sender, RoutedEventArgs e)
        {
            TherapyReport therapyReport = new TherapyReport(_patientWindow);
            therapyReport.GenerateReport();
            PopupNotification.SendPopupNotification("Successful!", "You succesfully downloaded PDF therapy report.");
        }

        public void BackToPatientWindow()
        {
            Content = _content;
        }
    }
}
