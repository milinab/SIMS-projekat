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

        public PatientWindow()
        {
            InitializeComponent();
            app = Application.Current as App;
            _content = Content;
            this.DataContext = this;
            dataGridAppointments.ItemsSource = app._appointmentController.Read();

            Appointments = new ObservableCollection<Appointment>();
            Doctors = new ObservableCollection<Doctor>();
            Appointments = app._appointmentController.Read();
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
            } else
            {
                MessageBox.Show("Select an appointment You want to cancel.", "Warning");
            }
        }

        private void MyAppointments_Click(object sender, RoutedEventArgs e)
        {
            Content = _content;
        }

        private void Surveys_Click(object sender, RoutedEventArgs e)
        {
            var takeSurvey = new Surveys(this);
            Content = takeSurvey;
        }

        private void Notes_Click(object sender, RoutedEventArgs e)
        {
            var lookNotes = new Notes(this);
            Content = lookNotes;
        }

        public void BackToPatientWindow()
        {
            Content = _content;
            refresh();
        }
        public void refresh()
        {
            dataGridAppointments.ItemsSource = app._appointmentController.Read();
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            LogIn logIn = new LogIn();
            logIn.Show();
            this.Close();
        }
    }
}