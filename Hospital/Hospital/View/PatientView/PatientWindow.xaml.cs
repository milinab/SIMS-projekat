using Hospital.Model;
using Prism.Commands;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Hospital.Controller;
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

        public PatientWindow(Patient p)
        {
            InitializeComponent();
            app = Application.Current as App;
            _content = Content;
            this.DataContext = this;
            patient = p;
            dataGridAppointments.ItemsSource = app._appointmentController.ReadFutureAppointments();

            Appointments = new ObservableCollection<Appointment>();
            Doctors = new ObservableCollection<Doctor>();
            Appointments = app._appointmentController.ReadFutureAppointments();
            Therapies = app._therapyController.ReadBypatientId(1);
            getTherapyTime();


            foreach (var a in Appointments) {
                doctor = app._doctorController.ReadById(a.DoctorId);
                Doctors.Add(doctor);
            }

        }

        private void getTherapyTime()
        {
            foreach (var th in Therapies)
            {
                DateTime now = DateTime.Now;

                TimeSpan ts = new TimeSpan(0, 30, 00);
                DateTime newTimespan = th.Time - ts;
                int diffInSeconds = (int)(th.Time - ts - now).TotalSeconds;
                //liveDateTime.Interval = newTimespan.TimeOfDay; // specify interval time as you want
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
            //MessageBox.Show("Please, take your therapy in half an hour..", "Therapy reminder");
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.notification;
            popup.TitleText = "Therapy reminder";
            popup.ContentText = "Please, take your therapy in half an hour.";
            popup.Popup();
            Console.WriteLine("Za pola sata je vreme da uzmes terapiju!");
            liveDateTime.Stop();

        }
        private void getNoteNotificationTime()
        {
            foreach (var note in Notes)
            {
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
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.notification;
            popup.TitleText = "Note notification";
            popup.ContentText = "ovde ce da ide tekst od notesa";
            popup.Popup();
            Console.WriteLine("ovde ce da ide tekst od notesa");
            liveDateTime.Stop();
        }

        private void BookAnAppointmentClick(object sender, RoutedEventArgs e)
        {

            BookAnAppointment bookAnAppointmentPage = new BookAnAppointment(this, app._appointmentController, app._userController);
            Content = bookAnAppointmentPage;
            
        }

        private void EditAnAppointmentClick(object sender, RoutedEventArgs e)
        {
            if (dataGridAppointments.SelectedItem != null)
            {
                Appointment appointment = (Appointment)dataGridAppointments.SelectedItem;
                //editAnAppointment.Show();
            }
            else
            {
                MessageBox.Show("Select an appointment You want to edit.", "Warning");
            }
        }

        private void EditButtonClick(object sender, RoutedEventArgs e)
        {
            Appointment appointment = dataGridAppointments.SelectedValue as Appointment;
            //int appointmentId = app._appointmentController.ReadById(appointment.Id);
            var editAnAppointmentPage = new EditAnAppointment(appointment, this);
            Content = editAnAppointmentPage;
        }

        private void CancelAnAppointmentClick(object sender, RoutedEventArgs e)
        {
            if(dataGridAppointments.SelectedItem != null)
            {
                Appointment appointment = (Appointment)dataGridAppointments.SelectedItem;
                app._appointmentController.Delete(appointment.Id);

                Trol troll = app._trolController.ReadByPatientId(this.patient.Id);
                if (troll == null)
                {
                    Trol tr = new Trol(this.patient.Id, DateTime.Now, 1);
                    app._trolController.Create(tr);
                }
                else
                {
                    if ((DateTime.Now - troll.StartDate).TotalDays < 30)
                    {
                        //ovo je okej, dozvoli
                        troll.NumberOfCancellations += 1;
                        app._trolController.Edit(troll);
                        Trol newTroll = app._trolController.ReadById(troll.Id);
                        if (newTroll.NumberOfCancellations >= 5)
                        {
                            this.patient.IsActive = false;

                            app._patientController.Edit(this.patient);
                            app._trolController.Delete(troll.Id);
                            MessageBox.Show("Your account is banned due to..");
                            LogIn logIn = new LogIn();
                            logIn.Show();
                            this.Close();
                        }
                    }
                    else
                    {
                        app._trolController.Delete(troll.Id);
                        Trol tr = new Trol(this.patient.Id, DateTime.Now, 1);
                        app._trolController.Create(tr);
                    }
                }


            } else
            {
                MessageBox.Show("Select an appointment You want to cancel.", "Warning");
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
            var medicalRecordPage = new MedicalRecord(this);
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
            refresh();
        }
        public void refresh()
        {
            dataGridAppointments.ItemsSource = app._appointmentController.ReadFutureAppointments();
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            LogIn logIn = new LogIn();
            logIn.Show();
            this.Close();
        }
    }
}