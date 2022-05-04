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
    /// Interaction logic for EditAnAppointment.xaml
    /// </summary>
    public partial class EditAnAppointment : Page
    {
        private App app;
        private readonly object _content;
        private readonly PatientWindow _patientWindow;
        private readonly UserController _userController;
        private readonly DoctorController _doctorController;
        private int _id;
        private DateTime Date;

        public ObservableCollection<Doctor> Doctors
        {
            get;
            set;
        }

        public EditAnAppointment(Appointment appointment, PatientWindow patientWindow)
        {
            InitializeComponent();
            app = Application.Current as App;
            dataGridAppointments.ItemsSource = patientWindow.dataGridAppointments.ItemsSource;
            Doctors = new ObservableCollection<Doctor>();
            Doctors = app._doctorController.Read();
            doctorsComboBox.ItemsSource = Doctors;
            _patientWindow = patientWindow;
            _id = appointment.Id;
            myCalendar.SelectedDate = appointment.Date;
            DateTime startTime = appointment.Date.AddDays(-5);
            DateTime endTime = appointment.Date.AddDays(5);
            myCalendar.DisplayDateStart = startTime;
            myCalendar.DisplayDateEnd = endTime;
        }

        private bool validate()
        {


            if (DoctorPriority.IsChecked == false && DatePriority.IsChecked == false)
            {
                MessageBox.Show("You need to select a priority.", "Warning");
                return false;
            }
            return false;
        }

        private void AddAppointment_Click(object sender, RoutedEventArgs e)
        {

            //if (!validate())
            //{
            //    return;
            //}

            //if (DoctorPriority.IsChecked == true)
            //{
            //DoctorPriorityDateAvailable DoctorPriorityDateAvailablePage = new DoctorPriorityDateAvailable(_patientWindow ,this,app._appointmentController);
            //Content = DoctorPriorityDateAvailablePage;
            //}
            // if (DatePriority.IsChecked == true)
            //{
            //BookAnAppointment bookAnAppointmentPage = new BookAnAppointment(this, app._appointmentController);
            //Content = bookAnAppointmentPage;

            // }

            //doctorsComboBox.ItemsSource = app._userController.ReadAll();


            int DoctorId = Int32.Parse(((Model.User)doctorsComboBox.SelectedItem).Id.ToString());

            DateTime _date = myCalendar.SelectedDate.Value;

            TimeSpan duration = new TimeSpan(0, 0, 30, 0);

            Doctor doctor = new Doctor();
            doctor.Id = DoctorId;
            Patient patient = new Patient();
            patient.Id = 1;

            Room room = new Room();
            patient.Id = 1;


            Appointment ap = new Appointment(_id, _date, duration, doctor, patient, room);
            app._appointmentController.Edit(ap);
            _patientWindow.BackToPatientWindow();
        }

        private void MyAppointments_Click(object sender, RoutedEventArgs e)
        {
            _patientWindow.BackToPatientWindow();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
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
