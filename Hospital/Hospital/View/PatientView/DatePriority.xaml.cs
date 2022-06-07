using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Hospital.Controller;
using Hospital.Model;
using System.Collections.ObjectModel;
using Tulpep.NotificationWindow;

namespace Hospital.View.PatientView
{
    /// <summary>
    /// Interaction logic for DatePriority.xaml
    /// </summary>
    public partial class DatePriority : Page
    {
        private App app;
        private readonly BookAnAppointment _bookAnAppointment;
        private readonly PatientWindow _patientWindow;
        //private readonly AppointmentController _appointmentController;
        private int _doctorId;
        private DateTime _date;
        private String chosenDoctor;
        private Doctor doctor;
        private Doctor selectedDoctor;
        public Patient patient;

        private String DoctorName
        {
            set { chosenDoctor = value; }
            get { return chosenDoctor; }
        }

        ObservableCollection<Appointment> DoctorsAppointments { get; set; }

        ObservableCollection<Appointment> AvailableAppointments { get; set; }

        /*public DatePriority(PatientWindow patientWindow, BookAnAppointment bookAnAppointment, AppointmentController appointmentController)
        {
            InitializeComponent();
            _bookAnAppointment = bookAnAppointment;
            _patientWindow = patientWindow;
            _appointmentController = appointmentController;
           
        }*/

        public DatePriority(int doctorId, DateTime date, BookAnAppointment bookAnAppointment, PatientWindow patientWindow)
        {
            InitializeComponent();
            app = Application.Current as App;

            _bookAnAppointment = bookAnAppointment;
            _patientWindow = patientWindow;
            _doctorId = doctorId;
            _date = date;
            DoctorsAppointments = new ObservableCollection<Appointment>();
            AvailableAppointments = new ObservableCollection<Appointment>();
            InitializeData(doctorId, date);
            dataGridDatePriority.ItemsSource = AvailableAppointments;
            dataGridAppointments.ItemsSource = patientWindow.Appointments;
            selectedDoctor = this.doctor;
        }

        private void InitializeData(int doctorId, DateTime date)
        {
            Doctor doctor = app._doctorController.ReadById(doctorId);
            this.doctor = doctor;
            this.ChosenDate.Text = _date.ToString("d.M.yyyy");

            // radno vreme bolnice
            List<TimeSpan> hospitalWorkingHours = new List<TimeSpan>
            {
                new TimeSpan(7, 00, 00),
                new TimeSpan(7, 30, 00),
                new TimeSpan(8, 00, 00),
                new TimeSpan(8, 30, 00),
                new TimeSpan(9, 00, 00),
                new TimeSpan(9, 30, 00),
                new TimeSpan(10, 00, 00),
                new TimeSpan(10, 30, 00)
            };

            List<TimeSpan> hospitalWorkingHoursListForCalculation = new List<TimeSpan>(hospitalWorkingHours);

            // pronadji sve appointmente tog lekara, uzmi njigovo pocetno vreme i izbrisi iz liste allAppointmentTImes ako se poklapaju

            DoctorsAppointments = new ObservableCollection<Appointment>();
            DoctorsAppointments = app._appointmentController.ReadByDoctorId(doctorId);

            //FindAvailabeAppointments(DoctorsAppointments, hospitalWorkingHours, hospitalWorkingHoursListForCalculation, date);
            AvailableAppointments =  app._appointmentController.FindAvailableAppointments(selectedDoctor, _date, DoctorName, DoctorsAppointments, hospitalWorkingHours, hospitalWorkingHoursListForCalculation, date);

            if (AvailableAppointments.Count == 0)
            {
                DoctorsAppointments.Clear();
                DoctorsAppointments = app._appointmentController.ReadByDateAndNotDoctor(doctorId, date);
                PopupNotification.sendPopupNotification("Warning", "Sorry to inform, but there is no available appointments for chosen date. In the following list, we are gonna show You available appointments for the next available doctor.");
                //FindAvailabeAppointments(DoctorsAppointments, hospitalWorkingHours, hospitalWorkingHoursListForCalculation, date);
                AvailableAppointments = app._appointmentController.FindAvailableAppointments(selectedDoctor, _date, DoctorName, DoctorsAppointments, hospitalWorkingHours, hospitalWorkingHoursListForCalculation, date);
            }
        }

        private void ConfirmAppointment_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = this.dataGridDatePriority.DataContext as Appointment;
            var SelectedItem = dataGridDatePriority.SelectedItem as Appointment;

            //zameniti za prave vrednosti koje cu dobiti kroz view-e
            Patient patient = new Patient();
            patient.Id = _patientWindow.patient.Id;
            Room room = new Room();
            room.Id = 2;
            var a = SelectedItem.Date;

            Appointment appointment = new Appointment(a, new TimeSpan(0, 30, 00), SelectedItem.Doctor, patient, room);
            app._appointmentController.Create(appointment);
            _patientWindow.BackToPatientWindow();
        }

        /*public void FindAvailabeAppointments(Doctor doctor, ObservableCollection<Appointment> AvailableAppointments, Doctor selectedDoctor, DateTime _date, string DoctorName, ObservableCollection<Appointment> DoctorsAppointments,
            List<TimeSpan> hospitalWorkingHours, List<TimeSpan> hospitalWorkingHoursListForCalculation, DateTime date)
        {

            List<TimeSpan> cloneList = new List<TimeSpan>(hospitalWorkingHoursListForCalculation);
            foreach (Appointment a in DoctorsAppointments)
            {
                DoctorName = a.Doctor.Name + " " + a.Doctor.LastName;
                this.doctor = a.Doctor;
                var appStartTime = a.Date;
                var appEndTime = a.Date + a.Duration;

                foreach (TimeSpan appTime in hospitalWorkingHours)
                {
                    //DateTime dt = new DateTime(date);
                    date += appTime;
                    if (DateTime.Compare(date, appStartTime) > 0)
                    {
                        if (DateTime.Compare(date, appEndTime) < 0)
                        {
                            if (cloneList.Contains(appTime))
                            {
                                cloneList.Remove(appTime);
                            }

                        }
                        else if (DateTime.Compare(date, appEndTime) == 0)
                        {
                            cloneList.Remove(appTime);
                        }
                    }
                    else if (DateTime.Compare(date, appStartTime) == 0)
                    {
                        if (DateTime.Compare(date, appEndTime) < 0)
                        {
                            if (cloneList.Contains(appTime))
                            {
                                cloneList.Remove(appTime);
                            }
                        }
                    }
                    date = _date;
                }
            }

            foreach (TimeSpan time in cloneList)
            {
                Appointment app = new Appointment();
                Doctor newDoctor = new Doctor();
                newDoctor.Name = DoctorName;
                newDoctor.Id = doctor.Id;
                app.Date = _date + time;
                app.Doctor = newDoctor;

                AvailableAppointments.Add(app);
            }
        }*/

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
            User user = app._userController.ReadById(patient.Id);
            Address address = app._addressController.ReadById(user.Address.Id);
            City city = app._cityController.ReadById(user.Address.CityId);
            Country country = app._countryController.ReadById(1); //country nije postavljen u address modelu
            Model.MedicalRecord medicalRecord = app._medicalRecordController.ReadById(patient.MedicalRecordId);
            ObservableCollection<Allergen> allergens = app._allergenController.ReadByIds(medicalRecord.AllergenIds);

            Page medicalRecordPage = new MedicalRecord(_patientWindow, user, patient, address, city, country, medicalRecord, allergens);
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

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Page page = new BookAnAppointment(_patientWindow);
            this.frame.Navigate(page);

            _bookAnAppointment.BackToBookAnAppointmentWindow();
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            LogIn logIn = new LogIn();
            logIn.Show();
            _patientWindow.Close();
        }
    }
}
