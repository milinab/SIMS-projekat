using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Hospital.Model;

namespace Hospital.View.PatientView
{
    /// <summary>
    /// Interaction logic for DoctorPriorityDateAvailable.xaml
    /// </summary>
    public partial class DoctorPriorityDateAvailable : Page
    {
        private App app;
        private readonly BookAnAppointment _bookAnAppointment;
        private readonly PatientWindow _patientWindow;
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

        public DoctorPriorityDateAvailable(int doctorId, DateTime date, BookAnAppointment bookAnAppointment, PatientWindow patientWindow)
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
            dataGridDoctorPriority.ItemsSource = AvailableAppointments;
            patient = app._patientController.ReadById(LogIn.LoggedUser.Id);
            dataGridAppointments.ItemsSource = app._appointmentController.ReadFutureAppointments(patient.Id);
            selectedDoctor = this.doctor;
            
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
                DateTime tommorow = date.AddDays(1);
                _date = tommorow;
                PopupNotification.SendPopupNotification("Warning", "Sorry to inform, but there is no available appointments for chosen date. In the following list, we are gonna show You available appointments for the next available day.");
                var availableAppointmentsNoDate = app._appointmentController.FindAvailableAppointments(selectedDoctor, _date, DoctorsAppointments, hospitalWorkingHours, hospitalWorkingHoursListForCalculation, tommorow);
                AvailableAppointments = new ObservableCollection<Appointment>(availableAppointmentsNoDate);
            }
        }

        private bool Validate()
        {
            if(dataGridDoctorPriority.SelectedItem == null)
            {
                PopupNotification.SendPopupNotification("Warning", "You need to select an appointment.");
                return false;
            }
            return true;
        }


        private void ConfirmAppointment_Click(object sender, RoutedEventArgs e)
        {
            if(Validate())
            {
                var viewModel = this.dataGridDoctorPriority.DataContext as Appointment;
                var SelectedItem = dataGridDoctorPriority.SelectedItem as Appointment;

                Patient patient = new Patient();
                patient.Id = _patientWindow.patient.Id;
                Room room = new Room();
                room.Id = 2;
                var date = SelectedItem.Date;

                Appointment appointment = new Appointment(date, new TimeSpan(0, 30, 00), doctor, patient, room);
                try
                {
                    app._appointmentController.Create(appointment);
                }
                catch (Exception AppointmentException)
                {

                }
                _patientWindow.BackToPatientWindow();
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Page page = new BookAnAppointment(_patientWindow);
            PatientWindow.getInstance().frame.Navigate(page);

            _bookAnAppointment.BackToBookAnAppointmentWindow();
        }

    }
}
