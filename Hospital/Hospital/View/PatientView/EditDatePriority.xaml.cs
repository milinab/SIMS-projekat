using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Hospital.Model;
using System.Collections.ObjectModel;

namespace Hospital.View.PatientView
{
    /// <summary>
    /// Interaction logic for EditDatePriority.xaml
    /// </summary>
    public partial class EditDatePriority : Page
    {
        private App app;
        private readonly EditAnAppointment _editAnAppointment;
        private readonly PatientWindow _patientWindow;
        private int _doctorId;
        private DateTime _date;
        private Doctor doctor;
        private int _appointmentId;
        private Doctor selectedDoctor;
        public Patient patient;


        ObservableCollection<Appointment> DoctorsAppointments { get; set; }

        ObservableCollection<Appointment> AvailableAppointments { get; set; }

        public EditDatePriority(int doctorId, DateTime date, EditAnAppointment editAnAppointment, PatientWindow patientWindow, int appointmentId)
        {
            InitializeComponent();
            app = Application.Current as App;

            _editAnAppointment = editAnAppointment;
            _patientWindow = patientWindow;
            _doctorId = doctorId;
            _date = date;
            _appointmentId = appointmentId;
            DoctorsAppointments = new ObservableCollection<Appointment>();
            AvailableAppointments = new ObservableCollection<Appointment>();
            InitializeData(doctorId, date);
            dataGridDatePriority.ItemsSource = AvailableAppointments;
            patient = app._patientController.ReadById(LogIn.LoggedUser.Id);
            dataGridAppointments.ItemsSource = app._appointmentController.ReadFutureAppointments(patient.Id);
            selectedDoctor = this.doctor;
            
        }

        private void InitializeData(int doctorId, DateTime date)
        {
            Doctor doctor = app._doctorController.ReadById(doctorId);
            this.doctor = doctor;
            this.ChosenDate.Text = _date.ToString("d.M.yyyy");

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

            //DoctorsAppointments = new ObservableCollection<Appointment>();
            //DoctorsAppointments = app._appointmentController.ReadByDoctorId(doctorId);
            var availableAppointments = app._appointmentController.FindAvailableAppointments(selectedDoctor, _date, DoctorsAppointments, hospitalWorkingHours, hospitalWorkingHoursListForCalculation, date);

            AvailableAppointments = new ObservableCollection<Appointment>(availableAppointments);

            if (AvailableAppointments.Count == 0)
            {
                DoctorsAppointments.Clear();
                DoctorsAppointments = app._appointmentController.ReadByDateAndNotDoctor(doctorId, date);
                PopupNotification.SendPopupNotification("Warning", "Sorry to inform, but there is no available appointments for chosen date. In the following list, we are gonna show You available appointments for the next available doctor.");
                var availableAppointmentsNoDoctor = app._appointmentController.FindAvailableAppointments(selectedDoctor, _date, DoctorsAppointments, hospitalWorkingHours, hospitalWorkingHoursListForCalculation, date);
                AvailableAppointments = new ObservableCollection<Appointment>(availableAppointmentsNoDoctor);
            }
        }

        private void ConfirmAppointment_Click(object sender, RoutedEventArgs e)
        {
            //var viewModel = this.dataGridDatePriority.DataContext as Appointment;
            var SelectedItem = dataGridDatePriority.SelectedItem as Appointment;

            Patient patient = new Patient();
            patient.Id = _patientWindow.patient.Id;
            Room room = new Room();
            room.Id = 2;
            var a = SelectedItem.Date;

            Appointment appointment = new Appointment(_appointmentId, a, new TimeSpan(0, 30, 00), doctor, patient, room);
            app._appointmentController.Edit(appointment);

            TrollSystem ts = new TrollSystem(_patientWindow, app);
            ts.Troll();
            PatientWindow.getInstance().BackToPatientWindow();
        }
       
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            PatientWindow.getInstance().BackToPatientWindow();
        }

    }
}
