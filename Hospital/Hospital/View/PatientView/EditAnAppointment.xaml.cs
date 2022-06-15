using System;
using System.Windows;
using System.Windows.Controls;
using Hospital.Model;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace Hospital.View.PatientView
{
    /// <summary>
    /// Interaction logic for EditAnAppointment.xaml
    /// </summary>
    public partial class EditAnAppointment : Page
    {
        private App app;
        private readonly PatientWindow _patientWindow;
        private int _id;
        public Patient patient;

        public ObservableCollection<Doctor> Doctors
        {
            get;
            set;
        }

        public EditAnAppointment(Appointment appointment, PatientWindow patientWindow)
        {
            InitializeComponent();
            app = Application.Current as App;
            patient = app._patientController.ReadById(LogIn.LoggedUser.Id);
            dataGridAppointments.ItemsSource = app._appointmentController.ReadFutureAppointments(patient.Id);
            List<Doctor> doctorList = app._doctorController.Read();
            ObservableCollection<Doctor> Doctors = new ObservableCollection<Doctor>(doctorList);

            //Doctors = new ObservableCollection<Doctor>();
            //Doctors = app._doctorController.Read();

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
                PopupNotification.SendPopupNotification("Warning", "You need to select a priority.");
                return false;
            }

            if (doctorsComboBox.SelectedItem == null)
            {
                PopupNotification.SendPopupNotification("Warning", "You need to select a doctor");
                return false;
            }

            if (myCalendar.SelectedDate.HasValue == false)
            {
                PopupNotification.SendPopupNotification("Warning", "You need to select a date");
                return false;
            }
            return true;
        }

        private void AddAppointment_Click(object sender, RoutedEventArgs e)
        {

            if (Validate())
            {
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
                    PatientWindow.getInstance().frame.Content = new EditDoctorPriority(DoctorId, _date, this, _patientWindow, _id);
                }
                if (DatePriority.IsChecked == true)
                {
                    Page datePriority = new EditDatePriority(DoctorId, _date, this, _patientWindow, _id);
                    PatientWindow.getInstance().frame.Navigate(datePriority);
                }
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            PatientWindow.getInstance().BackToPatientWindow();
        }

    }

    
}
