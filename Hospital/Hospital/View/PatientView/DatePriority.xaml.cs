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
using Hospital.Controller;
using Hospital.Model;
using System.Collections.ObjectModel;


namespace Hospital.View.PatientView
{
    /// <summary>
    /// Interaction logic for DatePriority.xaml
    /// </summary>
    public partial class DatePriority : Page
    {

        private readonly BookAnAppointment _bookAnAppointment;
        private readonly PatientWindow _patientWindow;
        private readonly AppointmentController _appointmentController;
        private ObservableCollection<String> availableAppointments;
        public DatePriority(PatientWindow patientWindow, BookAnAppointment bookAnAppointment, AppointmentController appointmentController)
        {
            InitializeComponent();
            _bookAnAppointment = bookAnAppointment;
            _patientWindow = patientWindow;
            _appointmentController = appointmentController;
            availableAppointments = new ObservableCollection<string>(new List<String>() { "08:00", "08:30", "17:00"});
        }
        

        private void ConfirmAppointment_Click(object sender, RoutedEventArgs e)
        {
        }

        private void MyAppointments_Click(object sender, RoutedEventArgs e)
        {
            _patientWindow.BackToPatientWindow();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            _bookAnAppointment.BackToBookAnAppointmentWindow();
        }

        private void checkAvailableAppointmantsForDoctor(Doctor doctor)
        {
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            LogIn logIn = new LogIn();
            logIn.Show();
            _patientWindow.Close();
        }
    }
}
