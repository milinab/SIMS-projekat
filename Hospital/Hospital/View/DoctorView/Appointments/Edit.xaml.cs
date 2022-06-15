using System;
using System.Collections.ObjectModel;
using System.Windows;
using Hospital.Model;

namespace Hospital.View.DoctorView.Appointments {
    /// <summary>
    /// Interaction logic for Edit.xaml
    /// </summary>
    public partial class Edit
    {

        private App _app;
        private Appointment _appointment;
        private Patient _patient;
        private ObservableCollection<Room> _rooms;

        public Edit(Appointment app)
        {
            _appointment = app;
            _app = Application.Current as App;
            InitializeComponent();
            var rooms = _app._roomController.Read();
            _rooms = new ObservableCollection<Room>(rooms);
            ObservableCollection<string> roomNames = new ObservableCollection<string>();
            foreach (var room in _rooms)
            {
                roomNames.Add(room.Name);
            }

            RoomListBox.ItemsSource = roomNames;
            
            Appointment appointment = app;
            _patient = app.Patient;
            DatePicker.SelectedDate = appointment.Date;
            TimePicker.Value = appointment.Date;
            Duration.Value = appointment.Duration;
            RoomListBox.SelectedItem = appointment.Room.Name;
        }

        private void RoomClick(object sender, RoutedEventArgs e) {

        }
        
        private void Confirm(object sender, RoutedEventArgs e) {
            DateTime date = DatePicker.SelectedDate.Value;
            string time = TimePicker.Text;
            string[] timeParts = time.Split(':');
            date += new TimeSpan(int.Parse(timeParts[0]), int.Parse(timeParts[1]), 0);
            string dur = Duration.Text;
            string[] durationParts = dur.Split(':');
            TimeSpan duration = new TimeSpan(int.Parse(durationParts[0]), int.Parse(durationParts[1]), 0);
            Doctor tempDoctor = _app._doctorController.ReadById(LogIn.LoggedUser.Id);
            Patient tempPatient = _patient;
            string roomName = RoomListBox.SelectedItem.ToString();
            Room tempRoom = new Room();
            foreach (var room in _rooms)
            {
                if (room.Name.Equals(roomName))
                {
                    tempRoom = room;
                }
            }

            Appointment app = new Appointment(_appointment.Id, date, duration, tempDoctor, tempPatient, tempRoom);
            _app._appointmentController.Edit(app);
            MainWindow.MainFrame.Navigate(new AppointmentsPage());
        }

        private void Cancel(object sender, RoutedEventArgs e) {
            MainWindow.MainFrame.GoBack();
        }

        private void PatientInformationClick(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrame.Navigate(new PatientInformationPage(_appointment));
        }
    }
}
