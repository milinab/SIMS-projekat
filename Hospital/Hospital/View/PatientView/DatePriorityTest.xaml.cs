using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Hospital.View.PatientView
{
    /// <summary>
    /// Interaction logic for DatePriorityTest.xaml
    /// </summary>
    public partial class DatePriorityTest : Window
    {

        private App app;
        private readonly BookAnAppointment _bookAnAppointment;
        private readonly PatientWindow _patientWindow;
        private readonly AppointmentController _appointmentController;
        private int _doctorId;
        private DateTime _date;
        private String choosenDoctor;
        private Doctor doctor;

        private String DoctorName
        {
            set { choosenDoctor = value; }
            get { return choosenDoctor; }
        }

        public ObservableCollection<Appointment> DoctorsAppointments
        {
            get;
            set;
        }

        public ObservableCollection<Appointment> AvailableAppointments
        {
            get;
            set;
        }


        public DatePriorityTest(PatientWindow patientWindow, BookAnAppointment bookAnAppointment, AppointmentController appointmentController)
        {
            InitializeComponent();
            app = Application.Current as App;
            _bookAnAppointment = bookAnAppointment;
            _patientWindow = patientWindow;
            _appointmentController = appointmentController;
        }

        public DatePriorityTest(int doctorId, DateTime date, BookAnAppointment bookAnAppointment, PatientWindow patientWindow)
        {
            InitializeComponent();
            app = Application.Current as App;
            this.frame.Content = null;
            this.frame.NavigationService.RemoveBackEntry();

            _bookAnAppointment = bookAnAppointment;
            _patientWindow = patientWindow;
            _doctorId = doctorId;
            _date = date;
            DoctorsAppointments = new ObservableCollection<Appointment>();
            AvailableAppointments = new ObservableCollection<Appointment>();
            initializeData(doctorId, date);
            dataGridDatePriority.ItemsSource = AvailableAppointments;


        }

        private void initializeData(int doctorId, DateTime date)
        {
            Doctor doctor = app._doctorController.ReadById(doctorId);
            this.doctor = doctor;
            DoctorName = doctor.Name;
            this.chosenDate.Text = doctor.Name + " " + doctor.LastName;

            // radno vreme bolnice
            List<TimeSpan> allAppointmentTimes = new List<TimeSpan>();
            allAppointmentTimes.Add(new TimeSpan(7, 00, 00));
            allAppointmentTimes.Add(new TimeSpan(7, 30, 00));
            allAppointmentTimes.Add(new TimeSpan(8, 00, 00));
            allAppointmentTimes.Add(new TimeSpan(8, 30, 00));
            allAppointmentTimes.Add(new TimeSpan(9, 00, 00));
            allAppointmentTimes.Add(new TimeSpan(9, 30, 00));
            allAppointmentTimes.Add(new TimeSpan(10, 00, 00));
            allAppointmentTimes.Add(new TimeSpan(10, 30, 00));

            List<TimeSpan> allAppointmentTimesAv = new List<TimeSpan>();
            allAppointmentTimesAv.Add(new TimeSpan(7, 00, 00));
            allAppointmentTimesAv.Add(new TimeSpan(7, 30, 00));
            allAppointmentTimesAv.Add(new TimeSpan(8, 00, 00));
            allAppointmentTimesAv.Add(new TimeSpan(8, 30, 00));
            allAppointmentTimesAv.Add(new TimeSpan(9, 00, 00));
            allAppointmentTimesAv.Add(new TimeSpan(9, 30, 00));
            allAppointmentTimesAv.Add(new TimeSpan(10, 00, 00));
            allAppointmentTimesAv.Add(new TimeSpan(10, 30, 00));



            // pronadji sve appointmente tog lekara, uzmi njigovo pocetno vreme i izbrisi iz liste allAppointmentTImes ako se poklapaju

            DoctorsAppointments = new ObservableCollection<Appointment>();
            DoctorsAppointments = app._appointmentController.ReadByDoctorId(doctorId);

            foreach (Appointment a in DoctorsAppointments)
            {

                var appStartTime = a.Date;
                var appEndTime = a.Date + a.Duration;

                foreach (TimeSpan appTime in allAppointmentTimes)
                {
                    //DateTime dt = new DateTime(date);
                    date = date + appTime;
                    if (DateTime.Compare(date, appStartTime) > 0)
                    {
                        if (DateTime.Compare(date, appEndTime) < 0)
                        {
                            if (allAppointmentTimesAv.Contains(appTime))
                            {
                                allAppointmentTimesAv.Remove(appTime);
                            }

                        }
                        else if (DateTime.Compare(date, appEndTime) == 0)
                        {
                            allAppointmentTimesAv.Remove(appTime);
                        }
                    }
                    else if (DateTime.Compare(date, appStartTime) == 0)
                    {
                        if (DateTime.Compare(date, appEndTime) < 0)
                        {
                            if (allAppointmentTimesAv.Contains(appTime))
                            {
                                allAppointmentTimesAv.Remove(appTime);
                            }
                        }
                    }
                    date = _date;
                }

                /*               if (allAppointmentTimes.Contains(a.Time)) {
                                   allAppointmentTimes.Remove(a.Time);
                               }*/
            }


            /*            foreach(String time in allAppointmentTimes) { 
                           Appointment app = new Appointment();
                            app.Date = date;
                            app.Time = time;
                            AvailableAppointments.Add(app);
                        }*/

            foreach (TimeSpan time in allAppointmentTimesAv)
            {
                Appointment app = new Appointment();
                app.Date = _date + time;

                AvailableAppointments.Add(app);
            }
        }

        private void ConfirmAppointment_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = this.dataGridDatePriority.DataContext as Appointment;
            var SelectedItem = dataGridDatePriority.SelectedItem as Appointment;


            //zameniti za prave vrednosti koje cu dobiti kroz view-e
            Patient patient = new Patient();
            patient.Id = 1;
            Room room = new Room();
            room.Id = 2;
            var a = SelectedItem.Date;

            Appointment appointment = new Appointment(a, new TimeSpan(0, 30, 00), doctor, patient, room);
            app._appointmentController.Create(appointment);
            this.Close();
            _patientWindow.BackToPatientWindow();



        }

        private void MyAppointments_Click(object sender, RoutedEventArgs e)
        {
            _patientWindow.BackToPatientWindow();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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
