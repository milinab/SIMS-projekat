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
            SetDatePicker(appointment);

        }

        private void SetDatePicker(Appointment appointment) { 
            DateTime startTime = appointment.Date.AddDays(-5);
            DateTime endTime = appointment.Date.AddDays(5);

            if (appointment.Date.Date.Equals(DateTime.Now.Date)) {
                startTime = DateTime.Now.Date.AddDays(1);
                myCalendar.DisplayDateStart = startTime;
            }
            if (DateTime.Now.Date > startTime) {
                startTime = DateTime.Now.Date;
            }
            myCalendar.DisplayDateStart = startTime;
            myCalendar.DisplayDateEnd = endTime;
        }

        private bool Validate()
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

            if (DoctorPriority.IsChecked == true)
            {
                Page doctorPriority = new EditDoctorPriority(DoctorId, _date, this, _patientWindow, _id);
                this.frame.Navigate(doctorPriority);
            }
           if (DatePriority.IsChecked == true)
            {
                Page datePriority = new EditDatePriority(DoctorId, _date, this, _patientWindow, _id);
                this.frame.Navigate(datePriority);
            }


/*            Appointment ap = new Appointment(_id, _date, duration, doctor, patient, room);
            app._appointmentController.Edit(ap);
            Trol troll = app._trolController.ReadByPatientId(_patientWindow.patient.Id);
            if(troll == null)
            {
                Trol tr = new Trol(_patientWindow.patient.Id, DateTime.Now, 1);
                app._trolController.Create(tr);
            }
            else
            {
                if((DateTime.Now-troll.StartDate).TotalDays < 30)
                {
                    //ovo je okej, dozvoli
                    troll.NumberOfCancellations += 1;
                    app._trolController.Edit(troll);
                    Trol newTroll = app._trolController.ReadById(troll.Id);
                    if (newTroll.NumberOfCancellations >= 5)
                    {
                        _patientWindow.patient.IsActive = false;
                        
                        app._patientController.Edit(_patientWindow.patient);
                        app._trolController.Delete(troll.Id);
                        MessageBox.Show("Your account is banned due to..");
                        LogIn logIn = new LogIn();
                        logIn.Show();
                        _patientWindow.Close();
                    }
                }
                else
                {
                    app._trolController.Delete(troll.Id);
                    Trol tr = new Trol(_patientWindow.patient.Id, DateTime.Now, 1);
                    app._trolController.Create(tr);
                }
            }*/
            //_patientWindow.BackToPatientWindow();
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

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            LogIn logIn = new LogIn();
            logIn.Show();
            _patientWindow.Close();
        }
    }

    
}
