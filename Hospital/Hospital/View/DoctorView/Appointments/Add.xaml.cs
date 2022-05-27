using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Hospital.Model;

namespace Hospital.View.DoctorView.Appointments {
    /// <summary>
    /// Interaction logic for Create.xaml
    /// </summary>
    public partial class Add : Page
    {

        private App _app;
        
        public Add()
        {
            _app = Application.Current as App;
            InitializeComponent();
            DatePicker.SelectedDate = DateTime.Now;
            ObservableCollection<Room> rooms = _app._roomController.Read();
            ObservableCollection<String> roomNames = new ObservableCollection<string>();
            foreach (var room in rooms)
            {
                roomNames.Add(room.Name);
            }

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
            Doctor tempDoctor = _app._doctorController.ReadById(4);
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

            Appointment appointment = new Appointment(date, duration, tempDoctor, tempPatient, tempRoom);

            _app._appointmentController.Create(appointment);
            MainWindow.MainFrame.GoBack();
        }

        private void Cancel(object sender, RoutedEventArgs e) {
            MainWindow.MainFrame.GoBack();
        }
    }
}