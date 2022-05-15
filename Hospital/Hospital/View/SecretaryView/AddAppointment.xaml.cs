using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Hospital.Model;
using Xceed.Wpf.Toolkit;
using MessageBox = Xceed.Wpf.Toolkit.MessageBox;

namespace Hospital.View.SecretaryView
{
    /// <summary>
    /// Interaction logic for Create.xaml
    /// </summary>
    public partial class AddAppointment : Window
    {

        private App _app;
        private readonly object _content;

        public AddAppointment(AppointmentPage appointmentPage)
        {
            _app = Application.Current as App;
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
           
            ObservableCollection<Room> rooms = _app._roomController.Read();
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
            ObservableCollection<String> roomNames = new ObservableCollection<string>();
            foreach (var room in rooms)
            {
                roomNames.Add(room.Name);
            }

            RoomListBox.ItemsSource = roomNames;
            
            //equipmentListBox.ItemsSource =
        }
        private void RoomClick(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
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

            Appointment appointment = new Appointment(date, duration, tempDoctor, tempPatient, tempRoom);
            _app._appointmentController.Create(appointment);
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