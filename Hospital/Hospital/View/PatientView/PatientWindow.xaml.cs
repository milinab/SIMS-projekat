using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Threading;
using Tulpep.NotificationWindow;

namespace Hospital.View.PatientView
{
    /// <summary>
    /// Interaction logic for PatientWindow.xaml
    /// </summary>
    /// 

    public partial class PatientWindow
    {
        private App app;
        private readonly object _content;
        private Doctor doctor;
        public Patient patient;
        public Note notifyNote;
        DispatcherTimer liveDateTime = new DispatcherTimer();

        public ObservableCollection<Appointment> Appointments
        {
            get;
            set;
        }

        public ObservableCollection<Doctor> Doctors
        {
            get;
            set;
        }

        public ObservableCollection<Therapy> Therapies
        {
            get;
            set;
        }

        public ObservableCollection<Note> Notes
        {
            get;
            set;
        }

        public PatientWindow()
        {
            InitializeComponent();
            app = Application.Current as App;
            _content = Content;
            this.DataContext = this;
            patient = app._patientController.ReadById(LogIn.LoggedUser.Id);
            dataGridAppointments.ItemsSource = app._appointmentController.ReadFutureAppointments(patient.Id);

            List<Appointment> appointmentList = app._appointmentController.ReadFutureAppointments(patient.Id);
            Appointments = new ObservableCollection<Appointment>(appointmentList);
            
            List<Therapy> therapiesList = app._therapyController.ReadBypatientId(patient.Id);
            Therapies = new ObservableCollection<Therapy>(therapiesList);

            List<Note> noteList = app._noteController.ReadByPatientId(patient.Id);
            Notes = new ObservableCollection<Note>(noteList);

            Doctors = new ObservableCollection<Doctor>();

            GetTherapyTime();
            GetNoteNotificationTime();


            foreach (var a in Appointments) {
                doctor = app._doctorController.ReadById(a.DoctorId);
                Doctors.Add(doctor);
            }

        }

        private void GetTherapyTime()
        {
            foreach (var th in Therapies)
            {
                DateTime now = DateTime.Now;

                TimeSpan ts = new TimeSpan(0, 30, 00);
                DateTime newTimespan = th.Time - ts;
                int diffInSeconds = (int)(th.Time - ts - now).TotalSeconds;
                if (diffInSeconds > 0)
                {
                    liveDateTime.Interval = new TimeSpan(0, 0, diffInSeconds);
                    liveDateTime.Tick += TimerTick;
                    liveDateTime.Start();
                }

            }

        }

        private void TimerTick(object sender, EventArgs e)
        {
            PopupNotification.SendPopupNotification("Therapy reminder", "Please, take your therapy in half an hour.");
            Console.WriteLine("Please, take your therapy in half an hour.");
            liveDateTime.Stop();

        }
        private void GetNoteNotificationTime()
        {
            foreach (var note in Notes)
            {
                notifyNote = note;
                DateTime now = DateTime.Now;
                DateTime notificationTime = note.NotificationDate;
                int diffInSeconds = (int)(note.NotificationDate - now).TotalSeconds;
                if (diffInSeconds > 0)
                {
                    liveDateTime.Interval = new TimeSpan(0, 0, diffInSeconds);
                    liveDateTime.Tick += TimerTickForNotes;
                    liveDateTime.Start();
                }
            }
        }

        private void TimerTickForNotes(object sender, EventArgs e)
        {

            PopupNotification.SendPopupNotification(this.notifyNote.Name, this.notifyNote.NoteText);
            Console.WriteLine("Note notification");
            liveDateTime.Stop();
        }

        private void BookAnAppointmentClick(object sender, RoutedEventArgs e)
        {

            BookAnAppointment bookAnAppointmentPage = new BookAnAppointment(this);
            Content = bookAnAppointmentPage;
            
        }

        private void EditButtonClick(object sender, RoutedEventArgs e)
        {
            Appointment appointment = dataGridAppointments.SelectedValue as Appointment;
            var editAnAppointmentPage = new EditAnAppointment(appointment, this);
            Content = editAnAppointmentPage;
        }

        private void CancelAnAppointmentClick(object sender, RoutedEventArgs e)
        {
            if(dataGridAppointments.SelectedItem != null)
            {
                Appointment appointment = (Appointment)dataGridAppointments.SelectedItem;
                app._appointmentController.Delete(appointment.Id);

                TrollSystem ts = new TrollSystem(this, app);
                ts.Troll();
                this.BackToPatientWindow();
            }
            else
            {
                PopupNotification.SendPopupNotification("Warning", "Please, select an appointment You want to cancel.");
            }
        }

        private void HomePage_Click(object sender, RoutedEventArgs e)
        {
            HomePage homePagePage = new HomePage(this);
            Content = homePagePage;
        }
        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            Profile profilePage = new Profile(this);
            Content = profilePage;
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

            var medicalRecordPage = new MedicalRecord(this, user, patient, address, city, country, medicalRecord, allergens);
            Content = medicalRecordPage;
        }

        private void MyAppointments_Click(object sender, RoutedEventArgs e)
        {
            PastAppointments pastAppointmentsPage = new PastAppointments(this);
            Content = pastAppointmentsPage;
        }
        private void MyTherapy_Click(object sender, RoutedEventArgs e)
        {
            MyTherapy myTherapyPage = new MyTherapy(this);
            Content = myTherapyPage;
        }

        private void Calendar_Click(object sender, RoutedEventArgs e)
        {
            Calendar calendarPage = new Calendar(this);
            Content = calendarPage;
        }
        private void Notes_Click(object sender, RoutedEventArgs e)
        {
            var lookNotes = new Notes(this);
            Content = lookNotes;
        }

        private void Surveys_Click(object sender, RoutedEventArgs e)
        {
            var takeSurvey = new Surveys(this);
            Content = takeSurvey;
        }
        private void Notification_Click(object sender, RoutedEventArgs e)
        {
            Notification notificationPage = new Notification(this);
            Content = notificationPage;
        }

        public void BackToPatientWindow()
        {
            Content = _content;
            Refresh();
        }
        public void Refresh()
        {
            dataGridAppointments.ItemsSource = app._appointmentController.ReadFutureAppointments(patient.Id);
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            LogIn logIn = new LogIn();
            logIn.Show();
            this.Close();
        }
    }
}