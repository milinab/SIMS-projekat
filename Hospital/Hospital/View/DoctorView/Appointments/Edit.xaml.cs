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
        private AppointmentsPage _appointmentsPage;
        private Appointment _appointment;
        
        public Edit(Appointment app, AppointmentsPage appointmentsPage)
        {
            _appointment = app;
            _app = Application.Current as App;
            InitializeComponent();
            _appointmentsPage = appointmentsPage;
            ObservableCollection<Room> rooms = _app._roomController.Read();
            ObservableCollection<string> roomNames = new ObservableCollection<string>();
            foreach (var room in rooms)
            {
                roomNames.Add(room.Name);
            }

            RoomListBox.ItemsSource = roomNames;
            
            Appointment appointment = app;
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
            Doctor tempDoctor = _app._doctorController.ReadById(1);
            Patient tempPatient = _app._patientController.ReadById(1);
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

            Appointment app = new Appointment(_appointment.Id, date, duration, tempDoctor, tempPatient, tempRoom);
            _app._appointmentController.Edit(app);
            _appointmentsPage.SwitchPage();
        }

        private void Cancel(object sender, RoutedEventArgs e) {
            _appointmentsPage.SwitchPage();
        }
    }
}
