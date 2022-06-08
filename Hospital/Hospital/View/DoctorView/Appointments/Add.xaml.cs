using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Hospital.Model;

namespace Hospital.View.DoctorView.Appointments {
    /// <summary>
    /// Interaction logic for Create.xaml
    /// </summary>
    public partial class Add
    {
        private App _app;
        private Patient _patient;
        private ObservableCollection<Room> _rooms;
        
        public Add(Patient patient)
        {
            _app = Application.Current as App;
            InitializeComponent();
            DatePicker.SelectedDate = DateTime.Now;
            var rooms = _app._roomController.Read();
            _rooms = new ObservableCollection<Room>(rooms);
            ObservableCollection<String> roomNames = new ObservableCollection<string>();
            foreach (var room in _rooms)
            {
                roomNames.Add(room.Name);
            }

            _patient = patient;
            RoomListBox.ItemsSource = roomNames;
            //equipmentListBox.ItemsSource =
        }
        private void RoomClick(object sender, RoutedEventArgs e) {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e) {

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {

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

            Appointment appointment = new Appointment(date, duration, tempDoctor, tempPatient, tempRoom);

            _app._appointmentController.Create(appointment);
            MainWindow.MainFrame.GoBack();
        }

        private void Cancel(object sender, RoutedEventArgs e) {
            MainWindow.MainFrame.GoBack();
        }
    }
}