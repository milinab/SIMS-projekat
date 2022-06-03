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
    /// Interaction logic for BookAnAppointment.xaml
    /// </summary>
    public partial class BookAnAppointment : Page
    {
        private App app;
        private readonly object _content;
        private readonly PatientWindow _patientWindow;
        private readonly AppointmentController _appointmentController;
        private readonly UserController _userController;

        public ObservableCollection<Doctor> Doctors
        {
            get;
            set;
        }

        public BookAnAppointment(PatientWindow patientWindow, AppointmentController appointmentController, UserController userController)
        {
            InitializeComponent();
            app = Application.Current as App;
            _content = Content;
            this.DataContext = this;
            dataGridAppointments.ItemsSource = patientWindow.dataGridAppointments.ItemsSource;
            _patientWindow = patientWindow;
            _appointmentController = appointmentController;
            _userController = userController;
            Doctors = new ObservableCollection<Doctor>();
            Doctors = app._doctorController.Read();
            doctorsComboBox.ItemsSource = Doctors;

        }

        public BookAnAppointment(PatientWindow patientWindow)
        {
            InitializeComponent();
            app = Application.Current as App;
            _content = Content;
            this.DataContext = this;
            dataGridAppointments.ItemsSource = patientWindow.dataGridAppointments.ItemsSource;
            _patientWindow = patientWindow;
            Doctors = new ObservableCollection<Doctor>();
            Doctors = app._doctorController.Read();
            doctorsComboBox.ItemsSource = Doctors;

        }

        public BookAnAppointment(UserController userController)
        {
            _userController = userController;
        }

        private bool Validate()
        {
         
            if(DoctorPriority.IsChecked == false && DatePriority.IsChecked == false)
            {
                MessageBox.Show("You need to select a priority.", "Warning");
                return false;
            }
            return false;
        }

        private void AddAppointment_Click(object sender, RoutedEventArgs e)
        {

            int DoctorId = Int32.Parse(((Model.User)doctorsComboBox.SelectedItem).Id.ToString());
            
            DateTime date = myCalendar.SelectedDate.Value;

            if (DoctorPriority.IsChecked == true)
            {
                Page doctorPriority = new DoctorPriorityDateAvailable(DoctorId, date, this, _patientWindow);
                this.frame.Navigate(doctorPriority);
            }
            if (DatePriority.IsChecked == true)
            {
                Page datePriority = new DatePriority(DoctorId, date, this, _patientWindow);
                this.frame.Navigate(datePriority);
            }
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

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            _patientWindow.BackToPatientWindow();
        }

        public void BackToBookAnAppointmentWindow()
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
