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
        public Patient patient;
        public Note notifyNote;
        DispatcherTimer liveDateTime = new DispatcherTimer();

        public static PatientWindow instance = null;

        public static PatientWindow getInstance()
        {
            if (instance == null)
            {
                instance = new PatientWindow();
            }
            return instance;
        }

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
            frame.Content = new StartScreenPagexaml(this);
            this.DataContext = this;

            app = Application.Current as App;
            
            patient = app._patientController.ReadById(LogIn.LoggedUser.Id);

            List<Therapy> therapiesList = app._therapyController.ReadBypatientId(patient.Id);
            Therapies = new ObservableCollection<Therapy>(therapiesList);

            List<Note> noteList = app._noteController.ReadByPatientId(patient.Id);
            Notes = new ObservableCollection<Note>(noteList);

            GetTherapyTime();
            GetNoteNotificationTime();

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

        /*private void BookAnAppointmentClick(object sender, RoutedEventArgs e)
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
        }*/

        private void HomePage_Click(object sender, RoutedEventArgs e)
        {
            HomePage homePagePage = new HomePage(this);
            frame.Content = homePagePage;
        }
        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Profile(this));
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
            frame.Navigate(medicalRecordPage);
        }
        private void MyAppointments_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new StartScreenPagexaml(this));
        }

        private void PastAppointments_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new PastAppointments());
        }
        private void MyTherapy_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new MyTherapy(this));
        }

        private void Calendar_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Calendar(this));
        }
        private void Notes_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Notes(this));
        }

        private void Surveys_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Surveys(this));
        }
        private void Notification_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Notification(this));
        }

        public void BackToPatientWindow()
        {
            frame.Navigate(new StartScreenPagexaml(this));
        }
        /*public void Refresh()
        {
            dataGridAppointments.ItemsSource = app._appointmentController.ReadFutureAppointments(patient.Id);
        }*/

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            LogIn logIn = new LogIn();
            logIn.Show();
            this.Close();
        }
    }
}