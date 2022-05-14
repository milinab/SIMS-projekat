using System;
using System.Collections.ObjectModel;
using System.Windows;
using Hospital.Model;

namespace Hospital.View.SecretaryView
{
    /// <summary>
    /// Interaction logic for Edit.xaml
    /// </summary>
    public partial class EditAppointment : Window
    {

        private App _app;
        private AppointmentPage _appointmentPage;
        private Appointment _appointment;

        public EditAppointment(Appointment appo, AppointmentPage appointmentPage)
        {
            Appointment appointment = appo;
            _appointment = appointment;
            _app = Application.Current as App;
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            _appointmentPage = appointmentPage;
            ObservableCollection<Room> rooms = _app._roomController.Read();
            ObservableCollection<string> roomNames = new ObservableCollection<string>();
            foreach (var room in rooms)
            {
                roomNames.Add(room.Name);
            }
            ObservableCollection<Doctor> doctors = _app._doctorController.Read();
            ObservableCollection<Patient> patients = _app._patientController.Read();
            ObservableCollection<string> patientNames = new ObservableCollection<string>();
            ObservableCollection<string> doctorNames = new ObservableCollection<string>();
            foreach (var doctor in doctors)
            {
                doctorNames.Add(doctor.Id + ", dr " + doctor.LastName);
            }
            foreach (var patient in patients)
            {
                patientNames.Add(patient.Id + ", " + patient.Name + " " + patient.LastName);
            }

            PatientListBox.ItemsSource = patientNames;
            DoctorListBox.ItemsSource = doctorNames;
            RoomListBox.ItemsSource = roomNames;


            DatePicker.SelectedDate = appointment.Date;
            TimePicker.Value = appointment.Date;
            Duration.Value = appointment.Duration;
            RoomListBox.SelectedItem = appointment.Room.Name;
            PatientListBox.SelectedItem = appointment.Patient.Id + ", " + appointment.Patient.Name + " " + appointment.Patient.LastName;
            DoctorListBox.SelectedItem = appointment.Doctor.Id + ", dr " + appointment.Doctor.LastName;



        }

        private void ListBox_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }



        private void RoomClick(object sender, RoutedEventArgs e)
        {

        }

        private void Confirm(object sender, RoutedEventArgs e)
        {
        
            DateTime date = DatePicker.SelectedDate.Value;
            string time = TimePicker.Text;
            string[] timeParts = time.Split(':');
            date += new TimeSpan(int.Parse(timeParts[0]), int.Parse(timeParts[1]), 0);
            string dur = Duration.Text;
            string[] durationParts = dur.Split(':');
            TimeSpan duration = new TimeSpan(int.Parse(durationParts[0]), int.Parse(durationParts[1]), 0);
            ObservableCollection<Doctor> doctors = _app._doctorController.Read();
            Doctor tempDoctor = new Doctor();

            string[] temp = (DoctorListBox.SelectedItem).ToString().Split(',');

            foreach (var doctor in doctors)
            {
                if (doctor.Id == int.Parse(temp[0]))
                {
                    tempDoctor = doctor;
                }
            }

            ObservableCollection<Patient> patients = _app._patientController.Read();
            Patient tempPatient = new Patient();

            string[] temp2 = PatientListBox.SelectedItem.ToString().Split(',');
            foreach (var patient in patients)
            {
                if (patient.Id == int.Parse(temp2[0]))
                {
                    tempPatient = patient;
                    
                }
            }

            string roomName = RoomListBox.SelectedItem.ToString();
            ObservableCollection<Room> rooms = _app._roomController.Read();
            Room tempRoom = new Room();
            foreach (var room in rooms)
            {
                if (room.Name.Equals(roomName))
                {
                    tempRoom = room;
                }
            }
            Appointment appointment = new Appointment(_appointment.Id, date, duration, tempDoctor, tempPatient, tempRoom);
            _app._appointmentController.Edit(appointment);
            AppointmentPage appointmentPage = new AppointmentPage();
            appointmentPage.Show();
            this.Close();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            SecretaryWindow secretaryWindow = new SecretaryWindow();
            secretaryWindow.Show();
            Close();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            AppointmentPage appointmentPage = new AppointmentPage();
            appointmentPage.Show();
            Close();
        }
        private void Cancel(object sender, RoutedEventArgs e)
        {
            AppointmentPage appointmentPage = new AppointmentPage();
            appointmentPage.Show();
            Close();
        }

        private void SignOut_Click(object sender, RoutedEventArgs e)
        {
            LogIn logIn = new LogIn();
            logIn.Show();
            Close();
        }
    }
}
    
