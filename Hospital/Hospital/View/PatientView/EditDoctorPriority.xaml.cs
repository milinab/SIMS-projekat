using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Hospital.Model;

namespace Hospital.View.PatientView
{
    /// <summary>
    /// Interaction logic for EditDoctorPriority.xaml
    /// </summary>
    public partial class EditDoctorPriority : Page
    {
        private App app;
        private readonly PatientWindow _patientWindow;
        private int _doctorId;
        private DateTime _date;
        private String chosenDoctor;
        private Doctor doctor;
        private int _id;
        private Doctor selectedDoctor;
        public Patient patient;

        private String DoctorName
        {
            set { chosenDoctor = value; }
            get { return chosenDoctor; }
        }

        ObservableCollection<Appointment> DoctorsAppointments { get; set; }

        ObservableCollection<Appointment> AvailableAppointments { get; set; }

        public EditDoctorPriority(int doctorId, DateTime date, EditAnAppointment editAnAppointment, PatientWindow patientWindow, int appointmantId)
        {
            InitializeComponent();
            app = Application.Current as App;
            _id = appointmantId;
            _patientWindow = patientWindow;
            _doctorId = doctorId;
            _date = date;
            DoctorsAppointments = new ObservableCollection<Appointment>();
            AvailableAppointments = new ObservableCollection<Appointment>();
            InitializeData(doctorId, date);
            dataGridDoctorPriority.ItemsSource = AvailableAppointments;
            dataGridAppointments.ItemsSource = patientWindow.dataGridAppointments.ItemsSource;
            selectedDoctor = this.doctor;
            patient = app._patientController.ReadById(LogIn.LoggedUser.Id);
        }
        private void InitializeData(int doctorId, DateTime date)
        {
            Doctor doctor = app._doctorController.ReadById(doctorId);
            this.doctor = doctor;
            DoctorName = doctor.Name;
            this.ChosenDoctor.Text = doctor.Name + " " + doctor.LastName;

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

            List<Appointment> appointmentList = app._appointmentController.ReadByDoctorId(doctorId);
            List<Appointment> DoctorsAppointments = new List<Appointment>(appointmentList);

            var availableAppointments = app._appointmentController.FindAvailableAppointments(selectedDoctor, _date, DoctorsAppointments, hospitalWorkingHours, hospitalWorkingHoursListForCalculation, date);
            AvailableAppointments = new ObservableCollection<Appointment>(availableAppointments);

            if (AvailableAppointments.Count == 0)
            {
                DateTime tommorow = date.AddDays(1); //uzmes sutradan
                _date = tommorow;
                PopupNotification.SendPopupNotification("Warning", "Sorry to inform, but there is no available appointments for chosen date. In the following list, we are gonna show You available appointments for the next available day.");
                var availableAppointmentsNoDate = app._appointmentController.FindAvailableAppointments(selectedDoctor, _date, DoctorsAppointments, hospitalWorkingHours, hospitalWorkingHoursListForCalculation, tommorow);
                AvailableAppointments = new ObservableCollection<Appointment>(availableAppointmentsNoDate);
            }
        }
            
        private void ConfirmAppointment_Click(object sender, RoutedEventArgs e)
        {
            var SelectedItem = dataGridDoctorPriority.SelectedItem as Appointment;

            Patient patient = new Patient();
            patient.Id = _patientWindow.patient.Id;
            TimeSpan duration = new TimeSpan(0, 0, 30, 0);
            Room room = new Room();
            room.Id = 2;
            var selectedDate = SelectedItem.Date;

            Appointment ap = new Appointment(_id, selectedDate, duration, doctor, patient, room);
            app._appointmentController.Edit(ap);

            TrollSystem ts = new TrollSystem(_patientWindow, app);
             ts.Troll();
            _patientWindow.BackToPatientWindow();

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
            User user = app._userController.ReadById(patient.Id);
            Address address = app._addressController.ReadById(user.Address.Id);
            City city = app._cityController.ReadById(user.Address.CityId);
            Country country = app._countryController.ReadById(1); //country nije postavljen u address modelu
            Model.MedicalRecord medicalRecord = app._medicalRecordController.ReadById(patient.MedicalRecordId);
            List<Allergen> allergenList = app._allergenController.ReadByIds(medicalRecord.AllergenIds);
            ObservableCollection<Allergen> allergens = new ObservableCollection<Allergen>(allergenList);

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
